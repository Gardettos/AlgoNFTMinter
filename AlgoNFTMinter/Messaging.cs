using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AlgoNFTMinter.DBTools;


using Algorand;
using Algorand.V2;
using Algorand.V2.Algod;
using Algorand.V2.Indexer;
using Algorand.V2.Algod.Model;
using Account = Algorand.Account;

namespace AlgoNFTMinter
{
    public partial class Messaging : UserControl
    {
        string ALGOD_API_ADDR;
        public Messaging()
        {
            InitializeComponent();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Program.db.TruncateTable("MessageData");
        }


        private void SetEnvironment(bool indexer = false)
        {
            if (radioTest.Checked)
            {
                if (indexer) ALGOD_API_ADDR = Program.config["ALGOD_INDX_ADDR_TEST"];
                else ALGOD_API_ADDR = Program.config["ALGOD_API_ADDR_TEST"];
            }
            else if (radioMain.Checked)
            {
                if (indexer) ALGOD_API_ADDR = Program.config["ALGOD_INDX_ADDR_MAIN"];
                else ALGOD_API_ADDR = Program.config["ALGOD_INDX_ADDR_MAIN"];
            }

        }

        private void btnLoadGrid_Click(object sender, EventArgs e)
        {
            var results = Program.db.RetrieveMessageData(dbSP.GetAllMessageData);
            dgMain.DataSource = results;
        }

        private async void btnAddASA_Click(object sender, EventArgs e)
        {
            //56582613
            SetEnvironment(true);
            var httpClient = HttpClientConfigurator.ConfigureHttpClient(ALGOD_API_ADDR, Program.config["ALGOD_API_TOKEN"]);
            LookupApi lookupApi = new LookupApi(httpClient) { BaseUrl = ALGOD_API_ADDR };
            var assetInfo = await lookupApi.AssetsAsync(Int32.Parse(txtBxASA.Text), null);
            var assetName = assetInfo.Asset.Params.Name;
            var assetUnitName = assetInfo.Asset.Params.UnitName;

            var balance = await lookupApi.BalancesAsync(include_all: false, limit: 100, next: null, round: null, currency_greater_than: null, currency_less_than: null, asset_id: Int32.Parse(txtBxASA.Text));

            foreach(Algorand.V2.Indexer.Model.MiniAssetHolding a in balance.Balances)
            {
                if((int) a.Amount > 0)
                {
                
                    var MessageRecord = new DBTools.MessageData
                    {
                        AssetID = txtBxASA.Text,
                        Name = assetName,
                        UnitName = assetUnitName,
                        HolderAddress = a.Address,

                    };

                    Program.db.AddRecord(MessageRecord);

                }
                
            }
        }

        private void dgMain_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //TODO: Clean up this function
            string status = string.Empty; //DB stores booleans as 0/1
            if (dgMain.Columns[e.ColumnIndex].Name == "SendMessageFlag")
            {
                switch (dgMain.Rows[e.RowIndex].Cells["SendMessageFlag"].Value)
                {
                    case false:
                        status = "0";
                        break;
                    case true:
                        status = "1";
                        break;
                }

                Program.db.RunQuery(dbSP.UpdateMessageStatus,
                    status,
                    dgMain.Rows[e.RowIndex].Cells["id"].Value.ToString());
            }

            else if (dgMain.Columns[e.ColumnIndex].Name == "RefreshHolderFlag")
            {
                switch (dgMain.Rows[e.RowIndex].Cells["RefreshHolderFlag"].Value)
                {
                    case false:
                        status = "0";
                        break;
                    case true:
                        status = "1";
                        break;
                }

                Program.db.RunQuery(dbSP.UpdateRefreshStatus,
                    status,
                    dgMain.Rows[e.RowIndex].Cells["id"].Value.ToString());
            }

            else if (dgMain.Columns[e.ColumnIndex].Name == "Message")
            {

                Program.db.RunQuery(dbSP.UpdateMessage,
                    dgMain.Rows[e.RowIndex].Cells["message"].Value.ToString(),
                    dgMain.Rows[e.RowIndex].Cells["id"].Value.ToString());
            }

        }

        private async void btnSendMessage_Click(object sender, EventArgs e)
        {
            var results = Program.db.RetrieveMessageData(dbSP.GetAllMessageData);
            if (results.Count > 0)
            {
                //Initialize connections 
                SetEnvironment();
                Account acct1 = new Account(Program.config["account1_mnemonic"]);
                var httpClient = HttpClientConfigurator.ConfigureHttpClient(ALGOD_API_ADDR, Program.config["ALGOD_API_TOKEN"]);

                var algodApiInstance = new DefaultApi(httpClient) { BaseUrl = ALGOD_API_ADDR };

                foreach (MessageData a in results)
                {
                    
                    try
                    {
                        var transParams = await algodApiInstance.ParamsAsync();
                        var tx = Utils.GetPaymentTransaction(acct1.Address, new Address(a.HolderAddress), 0, a.Message, transParams);
                        var signedTx = acct1.SignTransaction(tx);
                        var id = await Utils.SubmitTransaction(algodApiInstance, signedTx);
                        var resp = await Utils.WaitTransactionToComplete(algodApiInstance, id.TxId);

                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Issue sending message!", ex);
                    }
                }
             
            }
        }
    }
}
