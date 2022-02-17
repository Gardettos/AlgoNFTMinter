using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoNFTMinter.DBTools
{
    //Database Stored Procedures
    static class dbSP
    {
        private const string spGetAllData = "SELECT * FROM NewAssetData;";
        public static string GetAllData
        {
            get => spGetAllData;
        }

        private const string spGetAssetsToMint = "SELECT * FROM NewAssetData WHERE mintAssetFlag = True;";
        public static string GetAssetsToMint
        {
            get => spGetAssetsToMint;
        }

        private const string spGetAssetsToOptIn = "SELECT * FROM NewAssetData WHERE optInFlag = True;";
        public static string GetAssetsToOptIn
        {
            get => spGetAssetsToOptIn;
        }

        private const string spGetAssetsToTransfer = "SELECT * FROM NewAssetData WHERE transferFlag = True;";
        public static string GetAssetsToTransfer
        {
            get => spGetAssetsToTransfer;
        }

        private const string spDropTable = "DROP TABLE {0}";
        public static string DropTable
        {
            get => spDropTable;
        }

        private const string spUpdateMintStatus = "UPDATE NewAssetData SET mintAssetFlag = ? WHERE Id = ?;";
        public static string UpdateMintStatus
        {
            get => spUpdateMintStatus;
        }

        private const string spUpdateOptInStatus = "UPDATE NewAssetData SET optInFlag = ? WHERE Id = ?;";
        public static string UpdateOptInStatus
        {
            get => spUpdateOptInStatus;
        }

        private const string spUpdateTransferStatus = "UPDATE NewAssetData SET transferFlag = ? WHERE Id = ?;";
        public static string UpdateTransferStatus
        {
            get => spUpdateTransferStatus;
        }


        private const string spGetAllMessageData = "SELECT * FROM MessageData;";
        public static string GetAllMessageData
        {
            get => spGetAllMessageData;
        }

        private const string spUpdateMessage = "UPDATE MessageData SET message = ? WHERE Id = ?;";
        public static string UpdateMessage
        {
            get => spUpdateMessage;
        }

        private const string spUpdateMessageStatus = "UPDATE MessageData SET sendMessageFlag = ? WHERE Id = ?;";
        public static string UpdateMessageStatus
        {
            get => spUpdateMessageStatus;
        }

        private const string spGetSendMessages = "SELECT * FROM MessageData WHERE sendMessageFlag = True;";
        public static string GetSendMessages
        {
            get => spGetSendMessages;
        }


        private const string spUpdateRefreshStatus = "UPDATE MessageData SET refreshHolderFlag = ? WHERE Id = ?;";
        public static string UpdateRefreshStatus
        {
            get => spUpdateRefreshStatus;
        }

        private const string spGetRefreshHolders = "SELECT * FROM MessageData WHERE refreshHolderFlag = True;";
        public static string GetRefreshHolders
        {
            get => spGetRefreshHolders;
        }

    }
}
