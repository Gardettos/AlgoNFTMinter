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
                string account1_mnemonic = Program.config["account1_mnemonic"];                         
                Account acct1 = new Account(account1_mnemonic);
                var httpClient = HttpClientConfigurator.ConfigureHttpClient(Program.config["ALGOD_API_ADDR"], Program.config["ALGOD_API_TOKEN"]);
                var algodApiInstance = new DefaultApi(httpClient) { BaseUrl = Program.config["ALGOD_API_ADDR"] };


                var accountInfo = await algodApiInstance.AccountsAsync(acct1.Address.ToString(), null);
                Console.WriteLine(string.Format("Account Balance: {0} microAlgos", accountInfo.Amount));

                var transParams = await algodApiInstance.ParamsAsync();
                foreach (NewAssetData a in results)
                {
                    var ap = new AssetParams()
                    {
                        Creator = acct1.Address.ToString(),
                        Name = a.Name,
                        UnitName = a.UnitName,
                        DefaultFrozen = false,
                        Total = (ulong?)Convert.ToInt64(a.Total),
                        Decimals = (int)Convert.ToInt64(a.Decimals),
                        Url = a.URL,
                        MetadataHash = Encoding.ASCII.GetBytes(a.MetaDataHash)
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

                        Console.WriteLine(ex.StackTrace); //Throw error issue sending tran to network
                    }

                    
                   
                   
                }

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
                        Decimals = lineValues[1].ToString(),
                        DefaultFrozen = lineValues[2].ToString(),
                        Freeze = lineValues[3].ToString(),
                        Manager = lineValues[4].ToString(),
                        MetaDataHash = lineValues[5].ToString(),
                        Name = lineValues[6].ToString(),
                        Reserve = lineValues[7].ToString(),
                        Total = lineValues[8].ToString(),
                        UnitName = lineValues[9].ToString(),
                        URL = lineValues[10].ToString()
                    };

                    Program.db.AddRecord(Asset);

                }
            }
        }

    }
}
