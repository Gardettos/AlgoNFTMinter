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

        private const string spDropTable = "DROP TABLE {0}";
        public static string DropTable
        {
            get => spDropTable;
        }

    }
}
