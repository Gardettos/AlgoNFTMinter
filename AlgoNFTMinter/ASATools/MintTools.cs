using AlgoNFTMinter.DBTools;

using Algorand;
using Account = Algorand.Account;
using Algorand.Algod.Api;
using Algorand.Algod.Model;


using System;
using System.Collections.Generic;
using System.Text;


namespace AlgoNFTMinter.ASATools
{
    static class MintTools
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="creatorAccount"></param>
        /// <param name="assets"></param>
        /// <param name="algodApiInstance"></param>
        public static void CreateAsset(String creatorAccount, List<AssetData> assets, AlgodApi algodApiInstance, Account acct1)
        {            
            var transParams = algodApiInstance.TransactionParams();

            foreach (AssetData a in assets)
            {
                var ap = new AssetParams(
                    creator: creatorAccount,
                    assetname: a.Name, 
                    unitname: a.UnitName, 
                    defaultfrozen: false, 
                    total: (ulong?)Convert.ToInt64(a.Total),
                    url: a.URL,
                    metadatahash: a.MetaDataHash);

                var tx = Utils.GetCreateAssetTransaction(ap, transParams, "asset tx message");
                SignedTransaction signedTx = acct1.SignTransaction(tx);
                var id = Utils.SubmitTransaction(algodApiInstance, signedTx);             
                Utils.WaitTransactionToComplete(algodApiInstance, id.TxId);
                var assetId = algodApiInstance.PendingTransactionInformation(id.TxId).Txresults.Createdasset;
                a.AssetID = assetId.ToString();
            }
        }
    }

    
}
