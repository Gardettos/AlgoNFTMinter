using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoNFTMinter.DBTools
{
    //Database Stored Procedures
    static class dbSP
    {
        #region mintSps
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

        private const string spUpdateAllMintStatus = "UPDATE NewAssetData SET mintAssetFlag = ?;";
        public static string UpdateAllMintStatus
        {
            get => spUpdateAllMintStatus;
        }

        private const string spUpdateOptInStatus = "UPDATE NewAssetData SET optInFlag = ? WHERE Id = ?;";
        public static string UpdateOptInStatus
        {
            get => spUpdateOptInStatus;
        }

        private const string spUpdateAllOptInStatus = "UPDATE NewAssetData SET optInFlag = ?;";
        public static string UpdateAllOptInStatus
        {
            get => spUpdateAllOptInStatus;
        }

        private const string spUpdateTransferStatus = "UPDATE NewAssetData SET transferFlag = ? WHERE Id = ?;";
        public static string UpdateTransferStatus
        {
            get => spUpdateTransferStatus;
        }

        private const string spUpdateAllTransferStatus = "UPDATE NewAssetData SET transferFlag = ?;";
        public static string UpdateAllTransferStatus
        {
            get => spUpdateAllTransferStatus;
        }

        private const string spUpdateClawback = "UPDATE NewAssetData SET clawback = ? WHERE Id = ?;";
        public static string UpdateClawback
        {
            get => spUpdateClawback;
        }

        private const string spUpdateCreator = "UPDATE NewAssetData SET creator = ? WHERE Id = ?;";
        public static string UpdateCreator
        {
            get => spUpdateCreator;
        }

        private const string spUpdateDecimals = "UPDATE NewAssetData SET decimals = ? WHERE Id = ?;";
        public static string UpdateDecimals
        {
            get => spUpdateDecimals;
        }

        private const string spUpdateDefaultFrozen = "UPDATE NewAssetData SET defaultFrozen = ? WHERE Id = ?;";
        public static string UpdateDefaultFrozen
        {
            get => spUpdateDefaultFrozen;
        }

        private const string spUpdateFreeze = "UPDATE NewAssetData SET freeze = ? WHERE Id = ?;";
        public static string UpdateFreeze
        {
            get => spUpdateFreeze;
        }

        private const string spUpdateManager = "UPDATE NewAssetData SET manager = ? WHERE Id = ?;";
        public static string UpdateManager
        {
            get => spUpdateManager;
        }

        private const string spUpdateMetaDataHash = "UPDATE NewAssetData SET metaDataHash = ? WHERE Id = ?;";
        public static string UpdateMetaDataHash
        {
            get => spUpdateMetaDataHash;
        }

        private const string spUpdateName = "UPDATE NewAssetData SET name = ? WHERE Id = ?;";
        public static string UpdateName
        {
            get => spUpdateName;
        }


        private const string spUpdateReserve = "UPDATE NewAssetData SET reserve = ? WHERE Id = ?;";
        public static string UpdateReserve
        {
            get => spUpdateReserve;
        }

        private const string spUpdateTotal = "UPDATE NewAssetData SET total = ? WHERE Id = ?;";
        public static string UpdateTotal
        {
            get => spUpdateTotal;
        }

        private const string spUpdateUnitName = "UPDATE NewAssetData SET unitName = ? WHERE Id = ?;";
        public static string UpdateUnitName
        {
            get => spUpdateUnitName;
        }

        private const string spUpdateUrl = "UPDATE NewAssetData SET url = ? WHERE Id = ?;";
        public static string UpdateUrl
        {
            get => spUpdateUrl;
        }

        private const string spUpdateArcJson = "UPDATE NewAssetData SET arcJson = ? WHERE Id = ?;";
        public static string UpdateArcJson
        {
            get => spUpdateArcJson;
        }

        private const string spUpdateFileLocation = "UPDATE NewAssetData SET fileLocation = ? WHERE Id = ?;";
        public static string UpdateFileLocation
        {
            get => spUpdateFileLocation;
        }

        private const string spGetFileLocation = "SELECT * FROM NewAssetData WHERE fileLocation is null;";
        public static string GetFileLocation
        {
            get => spGetFileLocation;
        }

        private const string spGetFilesToProcess = "SELECT * FROM NewAssetData WHERE fileLocation not null;";
        public static string GetFilesToProcess
        {
            get => spGetFilesToProcess;
        }

        #endregion mintSps

        #region MessageSPs
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
        #endregion MessageSPs
    }
}
