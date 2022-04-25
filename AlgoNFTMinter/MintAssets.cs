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
            RefreshGrid();
        }

        private async void btnMint_Click(object sender, EventArgs e)
        {
            var results = Program.db.RetrieveData(dbSP.GetAssetsToMint);
            if (results.Count > 0)
            {
                SetEnvironment();                        
                Account acct1 = new Account(Program.config["account1_mnemonic"]);
                var httpClient = HttpClientConfigurator.ConfigureHttpClient(ALGOD_API_ADDR, Program.config["ALGOD_API_TOKEN"]);
         
                var algodApiInstance = new DefaultApi(httpClient) { BaseUrl = ALGOD_API_ADDR };

                foreach (NewAssetData a in results)
                {
                    var transParams = await algodApiInstance.ParamsAsync();

                    var ap = new AssetParams()
                    {
 
                        Clawback = String.IsNullOrEmpty(a.Clawback) ? null : a.Clawback,
                        Creator = a.Creator,
                        Decimals = (int)Convert.ToInt64(a.Decimals), 
                        DefaultFrozen = a.DefaultFrozen, 
                        Freeze = String.IsNullOrEmpty(a.Freeze) ? null : a.Freeze,
                        Manager = a.Manager,
                        MetadataHash = Encoding.ASCII.GetBytes(a.MetaDataHash.Substring(0, 32)),
                        Name = a.Name,
                        Reserve = a.Reserve,
                        Total = (ulong?)Convert.ToInt64(a.Total),
                        UnitName = a.UnitName,                                                           
                        Url = a.URL, 
                    };
                    
                   var tx = Utils.GetCreateAssetTransaction(ap, transParams, a.ArcJson);
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

                MessageBox.Show("Minting complete!");
                RefreshGrid();
            }
            else
            {
                MessageBox.Show("Select assets to mint!");
            }
        }

        private void ImportCSVFile()
        {//TODO: finish additioal arc69 updates
            string filePath = String.Empty;
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Select A File";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = openFileDialog.FileName;
                }
            }


            using (var reader = new StreamReader(filePath)) {
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    var records = csv.GetRecords<dynamic>();
                    var recordList = Enumerable.ToList(records);

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
            }

            //Set account number as default value for these fields
            string account1_mnemonic = Program.config["account1_mnemonic"];
            Account acct1 = new Account(account1_mnemonic);
            var address = acct1.Address.ToString();
            Program.db.RunQuery("UPDATE NewAssetData SET creator = ?", address);
            Program.db.RunQuery("UPDATE NewAssetData SET manager = ?", address);
            Program.db.RunQuery("UPDATE NewAssetData SET reserve = ?", address);
            MessageBox.Show("Import Complete!");
            RefreshGrid();
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
            switch (dgMain.Columns[e.ColumnIndex].Name)
            {
                case "Clawback":
                    Program.db.RunQuery(dbSP.UpdateClawback,
                    dgMain.Rows[e.RowIndex].Cells["clawback"].Value.ToString(),
                    dgMain.Rows[e.RowIndex].Cells["id"].Value.ToString());
                    break;
                case "Creator":
                    Program.db.RunQuery(dbSP.UpdateCreator,
                    dgMain.Rows[e.RowIndex].Cells["creator"].Value.ToString(),
                    dgMain.Rows[e.RowIndex].Cells["id"].Value.ToString());
                    break;
                case "Decimals":
                    Program.db.RunQuery(dbSP.UpdateDecimals,
                    dgMain.Rows[e.RowIndex].Cells["decimals"].Value.ToString(),
                    dgMain.Rows[e.RowIndex].Cells["id"].Value.ToString());
                    break;
                case "Freeze":
                    Program.db.RunQuery(dbSP.UpdateFreeze,
                    dgMain.Rows[e.RowIndex].Cells["freeze"].Value.ToString(),
                    dgMain.Rows[e.RowIndex].Cells["id"].Value.ToString());
                    break;
                case "Manager":
                    Program.db.RunQuery(dbSP.UpdateManager,
                    dgMain.Rows[e.RowIndex].Cells["manager"].Value.ToString(),
                    dgMain.Rows[e.RowIndex].Cells["id"].Value.ToString());
                    break;
                case "MetaDataHash":
                    Program.db.RunQuery(dbSP.UpdateMetaDataHash,
                    dgMain.Rows[e.RowIndex].Cells["metaDataHash"].Value.ToString(),
                    dgMain.Rows[e.RowIndex].Cells["id"].Value.ToString());
                    break;
                case "Name":
                    Program.db.RunQuery(dbSP.UpdateName,
                    dgMain.Rows[e.RowIndex].Cells["name"].Value.ToString(),
                    dgMain.Rows[e.RowIndex].Cells["id"].Value.ToString());
                    break;
                case "Reserve":
                    Program.db.RunQuery(dbSP.UpdateReserve,
                    dgMain.Rows[e.RowIndex].Cells["reserve"].Value.ToString(),
                    dgMain.Rows[e.RowIndex].Cells["id"].Value.ToString());
                    break;
                case "Total":
                    Program.db.RunQuery(dbSP.UpdateTotal,
                    dgMain.Rows[e.RowIndex].Cells["total"].Value.ToString(),
                    dgMain.Rows[e.RowIndex].Cells["id"].Value.ToString());
                    break;
                case "UnitName":
                    Program.db.RunQuery(dbSP.UpdateUnitName,
                    dgMain.Rows[e.RowIndex].Cells["unitName"].Value.ToString(),
                    dgMain.Rows[e.RowIndex].Cells["id"].Value.ToString());
                    break;
                case "URL":
                    Program.db.RunQuery(dbSP.UpdateUrl,
                    dgMain.Rows[e.RowIndex].Cells["url"].Value.ToString(),
                    dgMain.Rows[e.RowIndex].Cells["id"].Value.ToString());
                    break;
                case "ArcJson":
                    Program.db.RunQuery(dbSP.UpdateArcJson,
                    dgMain.Rows[e.RowIndex].Cells["arcJson"].Value.ToString(),
                    dgMain.Rows[e.RowIndex].Cells["id"].Value.ToString());
                    break;
                case "FileLocation":
                    Program.db.RunQuery(dbSP.UpdateFileLocation,
                    dgMain.Rows[e.RowIndex].Cells["fileLocation"].Value.ToString(),
                    dgMain.Rows[e.RowIndex].Cells["id"].Value.ToString());
                    break;
                case "PinataFlag":
                    Program.db.RunQuery(dbSP.UpdatePinataStatus,
                    dgMain.Rows[e.RowIndex].Cells["PinataFlag"].Value.Equals(false) ? "0" : "1",
                    dgMain.Rows[e.RowIndex].Cells["id"].Value.ToString());
                    break;
                case "MintAssetFlag":
                    Program.db.RunQuery(dbSP.UpdateMintStatus,
                    dgMain.Rows[e.RowIndex].Cells["MintAssetFlag"].Value.Equals(false) ? "0" : "1",
                    dgMain.Rows[e.RowIndex].Cells["id"].Value.ToString());
                    break;
                case "OptInFlag":
                    Program.db.RunQuery(dbSP.UpdateOptInStatus,
                    dgMain.Rows[e.RowIndex].Cells["OptInFlag"].Value.Equals(false) ? "0" : "1",
                    dgMain.Rows[e.RowIndex].Cells["id"].Value.ToString());
                    break;
                case "TransferFlag":
                    Program.db.RunQuery(dbSP.UpdateTransferStatus,
                    dgMain.Rows[e.RowIndex].Cells["TransferFlag"].Value.Equals(false) ? "0" : "1",
                    dgMain.Rows[e.RowIndex].Cells["id"].Value.ToString());
                    break;
                case "DefaultFrozen":
                    Program.db.RunQuery(dbSP.UpdateDefaultFrozen,
                    dgMain.Rows[e.RowIndex].Cells["DefaultFrozen"].Value.Equals(false) ? "0" : "1",
                    dgMain.Rows[e.RowIndex].Cells["id"].Value.ToString());
                    break;
            }
        }

        private async void btnOptIn_ClickAsync(object sender, EventArgs e)
        {

            var results = Program.db.RetrieveData(dbSP.GetAssetsToOptIn);
            if (results.Count > 0)
            {
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
                MessageBox.Show("Opt in complete!");
            }
            else
            {
                MessageBox.Show("Select assets to Opt into!");
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
                MessageBox.Show("Transfer complete!");
            }
            else
            {
                MessageBox.Show("Select assets to transfer!");
            }
        }


        private async void btnPinata_ClickAsync(object sender, EventArgs e)
        {

            var results = Program.db.RetrieveData(dbSP.GetFilesToProcess);
            if (results.Count > 0)
            {

                var config = new Config
                {
                    ApiKey = Program.config["ipfsKey"],
                    ApiSecret = Program.config["ipfsSecret"]
                };

                var client = new PinataClient(config);

                foreach (NewAssetData asset in results)
                {
                    var file = asset.FileLocation;
                    var response = await client.Pinning.PinFileToIpfsAsync(content =>
                    {
                        var fl = new System.Net.Http.ByteArrayContent(System.IO.File.ReadAllBytes(@file));
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
                        asset.MetaDataHash = cid;
                        asset.URL = string.Concat("ipfs://", cid);
                        Program.db.UpdateRecord(asset);
                    }
                }
                MessageBox.Show("Upload Complete!");
                RefreshGrid();
            }
            else MessageBox.Show("No assets flagged to be uploaded to Pinata!");
        }

        private void btnRefreshTable_Click(object sender, EventArgs e)
        {
            RefreshGrid();
        }

        private void RefreshGrid()
        {
            dgMain.DataSource = Program.db.RetrieveData(dbSP.GetAllData);
            dgMain.Columns[0].Visible = false; //Hide database ID column
            dgMain.Columns[1].Visible = false; //Hide clawback column
            dgMain.Columns[4].Visible = false; //Hide defaultFrozen column
            dgMain.Columns[5].Visible = false; //Hide freeze column
        }

        private void addBlankRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var Asset = new DBTools.NewAssetData
            {

            };

            Program.db.AddRecord(Asset);
            MessageBox.Show("Record Added!");
            RefreshGrid();
        }

        private void setAllTrueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.db.RunQuery(dbSP.UpdateAllMintStatus, "1");
            RefreshGrid();
        }

        private void setAllFalseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.db.RunQuery(dbSP.UpdateAllMintStatus, "0");
            RefreshGrid();
        }

        private void setAllTrueToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Program.db.RunQuery(dbSP.UpdateAllOptInStatus, "1");
            RefreshGrid();
        }

        private void setAllFalseToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Program.db.RunQuery(dbSP.UpdateAllOptInStatus, "0");
            RefreshGrid();
        }

        private void setAllTrueToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Program.db.RunQuery(dbSP.UpdateAllTransferStatus, "1");
            RefreshGrid();
        }

        private void setAllFalseToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Program.db.RunQuery(dbSP.UpdateAllTransferStatus, "0");
            RefreshGrid();
        }

        private void refreshGridToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RefreshGrid();
        }

        private void clearTablesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to clear the table?", "Clear Table", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Program.db.TruncateTable("NewAssetData");
                RefreshGrid();
            }
            else return;
        }

        private void deleteHighlightedRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you delete the highlighted record?", "Delete Record", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                var id = dgMain.Rows[dgMain.CurrentCell.RowIndex].Cells["id"].Value.ToString();
                Program.db.DeleteRecord(id);
                MessageBox.Show("Record Deleted!");
                RefreshGrid();
            }
            else return;
        }

        private void importCSVTraitDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (txtbxUnitName.Text.Length < 1)
            {
                MessageBox.Show("Enter Unit Name");
                return;
            }
            if (txtboxAssetName.Text.Length < 1)
            {
                MessageBox.Show("Enter Asset Name");
                return;
            }

            ImportCSVFile();
        }

        private void selectImageFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var results = Program.db.RetrieveData(dbSP.GetFileLocation);
            if (results.Count > 0)
            {
                string filePath = String.Empty;
                using (FolderBrowserDialog openFolderDialog = new FolderBrowserDialog())
                {
                    DialogResult dialogResult = openFolderDialog.ShowDialog();
                    if (dialogResult == DialogResult.OK)
                    {
                        filePath = openFolderDialog.SelectedPath;
                    }
                    else return;
                }
                var filesToProcess = System.IO.Directory.GetFiles(filePath, "*.png");
                if (results.Count != filesToProcess.Length) { MessageBox.Show("File count does not match trait count. Please review!"); return; }
                int i = 0;
                foreach (NewAssetData asset in results)
                {
                    asset.FileLocation = filesToProcess[i];
                    Program.db.UpdateRecord(asset);
                    i++;
                }
                MessageBox.Show("Complete!");
                RefreshGrid();
            }
        }

        private void setAllTrueToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Program.db.RunQuery(dbSP.UpdateAllPinataStatus, "1");
            RefreshGrid();
        }

        private void setAllFalseToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Program.db.RunQuery(dbSP.UpdateAllPinataStatus, "0");
            RefreshGrid();
        }
    }
}
