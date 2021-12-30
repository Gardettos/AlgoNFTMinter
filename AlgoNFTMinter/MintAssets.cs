using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Algorand;
using Algorand.V2;


using Algorand.Client;

using Account = Algorand.Account;
using System.IO;
using Ipfs.Http;
using Algorand.Algod.Api;
using Microsoft.Extensions.Configuration;

namespace AlgoNFTMinter
{
    public partial class MintAssets : UserControl
    {
        AlgodApi algodApiInstance;

        public MintAssets()
        {
            InitializeComponent();

            //TODO: Add checks to make sure nothing is blank
            IConfiguration config = new ConfigurationBuilder()
              .AddJsonFile("appsettings.json", true, true)
              .Build();

            try
            {
                //Initialize instance to node
                algodApiInstance = new AlgodApi(config["ALGOD_API_ADDR"], config["ALGOD_API_TOKEN"]);
            }
            catch (Exception e)
            {

            }


        }

        private void btnMint_Click(object sender, EventArgs e)
        {

        }
    }
}
