using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CsvHelper;

using Algorand;
using Algorand.V2;
using Algorand.V2.Algod;
using Algorand.V2.Algod.Model;
using Account = Algorand.Account;
using Pinata.Client;
using System.IO;

using AlgoNFTMinter.DBTools;
using System.Linq;
using Algorand.V2.Indexer;
using System.Globalization;
using Newtonsoft.Json;

namespace AlgoNFTMinter
{
    public partial class MintAssets : UserControl
    {
        string ALGOD_API_ADDR;
        public MintAssets()
        {
            InitializeComponent();
        }

        private async void btnMint_Click(object sender, EventArgs e)
        {
            var results = Program.db.RetrieveData(dbSP.GetAssetsToMint);
            if (results.Count > 0)
            {
                //Initialize connections 
                SetEnvironment();                        
                Account acct1 = new Account(Program.config["account1_mnemonic"]);
                var httpClient = HttpClientConfigurator.ConfigureHttpClient(ALGOD_API_ADDR, Program.config["ALGOD_API_TOKEN"]);
         
                var algodApiInstance = new DefaultApi(httpClient) { BaseUrl = ALGOD_API_ADDR };

                foreach (NewAssetData a in results)
                {
                    var transParams = await algodApiInstance.ParamsAsync();

                    var ap = new AssetParams()
                    {
                        Clawback = a.Clawback.Equals("") ? null : a.Clawback,
                        Creator = a.Creator,
                        Decimals = (int)Convert.ToInt64(a.Decimals), 
                        DefaultFrozen = a.DefaultFrozen, 
                        Freeze = a.Freeze.Equals("") ? null : a.Freeze,
                        Manager = a.Manager,
                        MetadataHash = Encoding.ASCII.GetBytes(a.MetaDataHash),
                        Name = a.Name,
                        Reserve = a.Reserve,
                        Total = (ulong?)Convert.ToInt64(a.Total),
                        UnitName = a.UnitName,                                                           
                        Url = a.URL, 
                    };
                    
                   var tx = Utils.GetCreateAssetTransaction(ap, transParams, "asset tx message");
                    SignedTransaction signedTx = acct1.SignTransaction(tx);

                    try
                    {
                        var id = await Utils.SubmitTransaction(algodApiInstance, signedTx);
                        var resp = await Utils.WaitTransactionToComplete(algodApiInstance, id.TxId);
                        var ptx = await algodApiInstance.PendingGetAsync(id.TxId, null);
                        a.AssetID =  ptx.AssetIndex.ToString();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Issue minting asset!", ex);
                    }                                                       
                }
                //Update DB record with the new assetID
                foreach (NewAssetData a in results)
                    Program.db.UpdateRecord(a);

            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            if (File.Exists(Program.config["csvPath"]))
            {       
                if(txtboxAssetName.Text.Length < 1) throw new Exception("Enter Asset Name");
                if (txtbxUnitName.Text.Length < 1) throw new Exception("Enter Unit Name");
                ImportCSVFile(Program.config["csvPath"]);
            }
            else
            {
                throw new Exception("Cannot locate csv");
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Program.db.TruncateTable();
        }
        /// <summary>
        /// This method reads the csv file containing all trait data and formats each row as arc69 json.
        /// </summary>
        /// <param name="filePath"></param>
        private void ImportCSVFile(String filePath)
        {
            using (var reader = new StreamReader(filePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {        
                var records = csv.GetRecords<dynamic>();
                var recordList  = Enumerable.ToList(records);

                int i = 1;
                foreach (var line in recordList)
                {
                    var meta_data = "{\"standard\":\"arc69\", \"properties\":" + JsonConvert.SerializeObject(line) + "}";
                    var Asset = new DBTools.NewAssetData
                    {
                        Name = String.Concat(txtboxAssetName.Text, i.ToString()),
                        UnitName = String.Concat(txtbxUnitName.Text, i.ToString()),
                        ArcJson = meta_data,

                    };

                    Program.db.AddRecord(Asset);
                    i++;
                }
            }

            //Set account number as default value for these fields
            string account1_mnemonic = Program.config["account1_mnemonic"];
            Account acct1 = new Account(account1_mnemonic);
            var address = acct1.Address.ToString();
            Program.db.RunQuery("UPDATE NewAssetData SET creator = ?", address);
            Program.db.RunQuery("UPDATE NewAssetData SET manager = ?", address);
            Program.db.RunQuery("UPDATE NewAssetData SET reserve = ?", address);

        }

        private void SetEnvironment(bool indexer = false)
        {
            if (radioTest.Checked) {
                if(indexer) ALGOD_API_ADDR = Program.config["ALGOD_INDX_ADDR_TEST"];
                else ALGOD_API_ADDR = Program.config["ALGOD_API_ADDR_TEST"]; 
            }
            else if (radioMain.Checked) {
                if (indexer) ALGOD_API_ADDR = Program.config["ALGOD_INDX_ADDR_MAIN"];
                else ALGOD_API_ADDR = Program.config["ALGOD_INDX_ADDR_MAIN"];
            }

        }

        private void dgMain_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //TODO: Clean up this function
            string status = string.Empty; //DB stores booleans as 0/1
            if (dgMain.Columns[e.ColumnIndex].Name == "MintAssetFlag")
                {
                switch (dgMain.Rows[e.RowIndex].Cells["MintAssetFlag"].Value)
                {
                    case false:
                        status = "0";
                        break;
                    case true:
                        status = "1";
                        break;
                }

                Program.db.RunQuery(dbSP.UpdateMintStatus,
                    status,
                    dgMain.Rows[e.RowIndex].Cells["id"].Value.ToString());
            }

            else if (dgMain.Columns[e.ColumnIndex].Name == "OptInFlag")
            {
                switch (dgMain.Rows[e.RowIndex].Cells["OptInFlag"].Value)
                {
                    case false:
                        status = "0";
                        break;
                    case true:
                        status = "1";
                        break;
                }

                Program.db.RunQuery(dbSP.UpdateOptInStatus,
                    status,
                    dgMain.Rows[e.RowIndex].Cells["id"].Value.ToString());
            }

            else if (dgMain.Columns[e.ColumnIndex].Name == "TransferFlag")
            {
                switch (dgMain.Rows[e.RowIndex].Cells["TransferFlag"].Value)
                {
                    case false:
                        status = "0";
                        break;
                    case true:
                        status = "1";
                        break;
                }

                Program.db.RunQuery(dbSP.UpdateTransferStatus,
                    status,
                    dgMain.Rows[e.RowIndex].Cells["id"].Value.ToString());
            }

        }

        private async void btnOptIn_ClickAsync(object sender, EventArgs e)
        {

            var results = Program.db.RetrieveData(dbSP.GetAssetsToOptIn);
            if (results.Count > 0)
            {
                //Initialize connections 
                SetEnvironment();
                Account acct2 = new Account(Program.config["account2_mnemonic"]);
                var httpClient = HttpClientConfigurator.ConfigureHttpClient(ALGOD_API_ADDR, Program.config["ALGOD_API_TOKEN"]);
                var algodApiInstance = new DefaultApi(httpClient) { BaseUrl = ALGOD_API_ADDR };
                foreach (NewAssetData a in results)
                {
                    var transParams = await algodApiInstance.ParamsAsync();
                    var tx = Utils.GetAssetOptingInTransaction(acct2.Address, ulong.Parse(a.AssetID), transParams, "opt in transaction");
                    var signedTx = acct2.SignTransaction(tx);
                    string mytx; //TODO: store data like this in other table?

                    try
                    {
                        var id = await Utils.SubmitTransaction(algodApiInstance, signedTx);
                        var wait = await Utils.WaitTransactionToComplete(algodApiInstance, id.TxId);
                        mytx = id.TxId;
                        Console.WriteLine(wait);
                    }
                    catch (Exception ex) { }
                }                
            }
        }

        private async void btnTransfer_ClickAsync(object sender, EventArgs e)
        {
            var results = Program.db.RetrieveData(dbSP.GetAssetsToTransfer);
            if (results.Count > 0)
            {
                SetEnvironment();
                var httpClient = HttpClientConfigurator.ConfigureHttpClient(ALGOD_API_ADDR, Program.config["ALGOD_API_TOKEN"]);
                var algodApiInstance = new DefaultApi(httpClient) { BaseUrl = ALGOD_API_ADDR };
                Account acct1 = new Account(Program.config["account1_mnemonic"]);
                Account acct2 = new Account(Program.config["account2_mnemonic"]);

                foreach (NewAssetData a in results)
                {
                    var transParams = await algodApiInstance.ParamsAsync();
                    var tx = Utils.GetTransferAssetTransaction(acct1.Address, acct2.Address, ulong.Parse(a.AssetID), (ulong)a.Total, transParams, null, "transfer message");
                    var signedTx = acct1.SignTransaction(tx);
                    string mytx;

                    try
                    {
                        var id = await Utils.SubmitTransaction(algodApiInstance, signedTx);
                        var wait = await Utils.WaitTransactionToComplete(algodApiInstance, id.TxId);
                        mytx = id.TxId;
                        Console.WriteLine(wait);
                    }
                    catch (Exception ex){}
                }
            }
        }


        private async void btnPinata_ClickAsync(object sender, EventArgs e)
        {
            //TODO: Get image locations from db field
            var config = new Config
            {
                ApiKey = Program.config["ipfsKey"],
                ApiSecret = Program.config["ipfsSecret"]
            };

            var client = new PinataClient(config);

            var filesToProcess = System.IO.Directory.GetFiles(Program.config["imageDirectory"], "*.png");

            foreach (string filePath in filesToProcess)
            {
                var response = await client.Pinning.PinFileToIpfsAsync(content =>
                {
                    var fl = new System.Net.Http.ByteArrayContent(System.IO.File.ReadAllBytes(@filePath));
                    fl.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("image/png");
                    var fldata = new
                    {
                        filepath = $"fileName"
                    };

                    content.AddPinataFile(fl, fldata.filepath);
                });

                if (response.IsSuccess)
                {
                    //File uploaded to Pinata Cloud and can be accessed on IPFS!
                    var cid = response.IpfsHash;
                    Console.WriteLine(cid);
                }
            }
        }

        private void btnRefreshTable_Click(object sender, EventArgs e)
        {
            var results = Program.db.RetrieveData(dbSP.GetAllData);
            dgMain.DataSource = results;
        }
    }
}
