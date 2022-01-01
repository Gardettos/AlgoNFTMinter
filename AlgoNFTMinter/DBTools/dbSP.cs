using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoNFTMinter.DBTools
{
    //Database Stored Procedures
    static class dbSP
    {
        private const string spGetAllData = "SELECT * FROM AssetData";
        public static string GetAllData
        {
            get => spGetAllData;
        }
    }
}
