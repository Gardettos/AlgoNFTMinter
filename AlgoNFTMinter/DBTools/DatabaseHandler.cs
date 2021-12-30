using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AlgoNFTMinter.DBTools
{
    class DatabaseHandler
    {
        private SQLiteConnection _db;
        public DatabaseHandler()
        {
            var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "MyData.db");
            _db = new SQLiteConnection(databasePath);
            _db.CreateTable<AssetData>();
           
        }

        public void AddRecord(AssetData data)
        {
            _db.Insert(data);
        }

        public List<AssetData> RetrieveData(String sqlString)
        {
            return _db.Query<DBTools.AssetData>(sqlString);           
        }
    }
}
