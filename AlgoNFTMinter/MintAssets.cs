using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Algorand;
using Algorand.V2;
using Algorand.V2.Algod;
using Algorand.V2.Algod.Model;
using Account = Algorand.Account;

using System.IO;
using Ipfs.Http;

using Microsoft.Extensions.Configuration;
using AlgoNFTMinter.DBTools;
using System.Linq;

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
                        Console.WriteLine(ex.StackTrace); //TODO: Throw error issue sending tran to network
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
                ImportCSVFile(Program.config["csvPath"]);
            }
            else
            {
                //throw error
                MessageBox.Show("CSV File Missing");
            }
        }

        private void btnGetData_Click(object sender, EventArgs e)
        {
            var results = Program.db.RetrieveData(dbSP.GetAllData);
            dgMain.DataSource = results;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Program.db.TruncateTable();
        }

        private void ImportCSVFile(String filePath)
        {
            using (StreamReader sr = new StreamReader(filePath))
            {
                string headerLine = sr.ReadLine();
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    List<string> lineValues = line.Split(',').ToList();

                    var Asset = new DBTools.NewAssetData
                    {
                        Clawback = lineValues[0].ToString(),
                        Decimals = int.Parse(lineValues[1]),
                        DefaultFrozen = Boolean.Parse(lineValues[2]),
                        Freeze = lineValues[3].ToString(),
                        Manager = lineValues[4].ToString(),
                        MetaDataHash = lineValues[5].ToString(),
                        Name = lineValues[6].ToString(),
                        Reserve = lineValues[7].ToString(),
                        Total = int.Parse(lineValues[8]),
                        UnitName = lineValues[9].ToString(),
                        URL = lineValues[10].ToString()
                    };

                    Program.db.AddRecord(Asset);

                }
            }
        }

        private void SetEnvironment()
        {
            if (radioTest.Checked) ALGOD_API_ADDR = Program.config["ALGOD_API_ADDR_TEST"];
            else if (radioMain.Checked) ALGOD_API_ADDR = Program.config["ALGOD_API_ADDR_MAIN"];
        }

        private void dgMain_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dgMain.Columns[e.ColumnIndex].Name == "MintAssetFlag")
                {
                string status = ""; //DB stores booleans as 0/1
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
                string status = ""; //DB stores booleans as 0/1
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
                string status = ""; //DB stores booleans as 0/1
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

        private void btnPrep_Click(object sender, EventArgs e)
        {
            string account1_mnemonic = Program.config["account1_mnemonic"];
            Account acct1 = new Account(account1_mnemonic);
            var address = acct1.Address.ToString();

            Program.db.RunQuery("UPDATE NewAssetData SET creator = ?", address);
            Program.db.RunQuery("UPDATE NewAssetData SET manager = ?", address);
            Program.db.RunQuery("UPDATE NewAssetData SET reserve = ?", address);

        }
    }
}
