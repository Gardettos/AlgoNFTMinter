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

        public void UpdateRecord(AssetData data)
        {
            _db.Update(data);
        }

        public void TruncateTable()
        {
            _db.DeleteAll<AssetData>();
        }

        public List<AssetData> RetrieveData(String sqlString)
        {
            //var query = conn.Table<Stock>().Where(v => v.Symbol.StartsWith("A"));
            return _db.Query<DBTools.AssetData>(sqlString);           
        }

        //public void DeleteRecord(string id)
        //{
        //    _db.Delete<AssetData>(id);
        //}

        //public IEnumerable<AssetData> QueryAssets(AssetData asset)
        //{
        //    return _db.Query<AssetData>("select * from AssetData where id = ?", asset.Id);
        //}
    }
}
