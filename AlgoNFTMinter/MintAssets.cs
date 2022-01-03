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
                string account1_mnemonic = Program.config["account1_mnemonic"];                         
                Account acct1 = new Account(account1_mnemonic);
                var httpClient = HttpClientConfigurator.ConfigureHttpClient(ALGOD_API_ADDR, Program.config["ALGOD_API_TOKEN"]);
                var algodApiInstance = new DefaultApi(httpClient) { BaseUrl = ALGOD_API_ADDR };

                var transParams = await algodApiInstance.ParamsAsync();
                foreach (NewAssetData a in results)
                {
                    var ap = new AssetParams()
                    {
                        //Clawback = a.Clawback,
                        Creator = acct1.Address.ToString(),
                        Decimals = (int)Convert.ToInt64(a.Decimals),
                        DefaultFrozen = a.DefaultFrozen,
                        //Freeze = a.Freeze,
                        //Manager = a.Manager,
                        MetadataHash = Encoding.ASCII.GetBytes(a.MetaDataHash),
                        Name = a.Name,
                        //Reserve = a.Reserve,
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
                        a.AssetID = ptx.AssetIndex.ToString();
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

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            Program.db.RunQuery(dbSP.UpdateMintStatus);
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
                        Decimals = lineValues[1],
                        DefaultFrozen = Boolean.Parse(lineValues[2]),
                        Freeze = lineValues[3].ToString(),
                        Manager = lineValues[4].ToString(),
                        MetaDataHash = lineValues[5].ToString(),
                        Name = lineValues[6].ToString(),
                        Reserve = lineValues[7].ToString(),
                        Total = lineValues[8],
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
    }
}
