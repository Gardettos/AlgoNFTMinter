using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Algorand;
using Algorand.Algod.Model;
using Algorand.Algod.Api;
using Account = Algorand.Account;


using System.IO;
using Ipfs.Http;

using Microsoft.Extensions.Configuration;
using AlgoNFTMinter.DBTools;
using AlgoNFTMinter.ASATools;
namespace AlgoNFTMinter
{
    public partial class MintAssets : UserControl
    {
        AlgodApi algodApiInstance;
        Account acct1;
        string account1_mnemonic;
        public MintAssets()
        {
            InitializeComponent();
            account1_mnemonic = Program.config["account1_mnemonic"];
        }

        private void btnMint_Click(object sender, EventArgs e)
        {
           
            var results = Program.db.RetrieveData(dbSP.GetAssetsToMint);
            if (results.Count > 0)
            {

                MintTools.CreateAsset(account1_mnemonic, results, algodApiInstance, acct1);


                foreach (AssetData a in results)
                    Program.db.UpdateRecord(a);


            }
        }

        private void btnInitialize_Click(object sender, EventArgs e)
        {
            try
            {
                acct1 = new Account(account1_mnemonic);
                //Initialize instance to node
                algodApiInstance = new AlgodApi(Program.config["ALGOD_API_ADDR"], Program.config["ALGOD_API_TOKEN"]);

                var transParams = algodApiInstance.TransactionParams();

                //TODO:Add something that checks for no issues with connections

            }
            catch (Exception) { }
        }
    }
}
