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
            _db.CreateTable<NewAssetData>();
        }

        public void AddRecord(NewAssetData data)
        {
            _db.Insert(data);
        }

        public void UpdateRecord(NewAssetData data)
        {
            _db.Update(data);
        }

        public void TruncateTable()
        {
            _db.DeleteAll<NewAssetData>();
        }

        public void DropTable(String tableName)
        {
            _db.Execute(String.Format(dbSP.DropTable, tableName));
        }

        public List<NewAssetData> RetrieveData(String sqlString)
        {
            //var query = conn.Table<Stock>().Where(v => v.Symbol.StartsWith("A"));
            return _db.Query<DBTools.NewAssetData>(sqlString);           
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
