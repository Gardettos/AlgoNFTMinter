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
            var databasePath = Path.Combine(Program.config["databaseLocation"], "MyData.db");
            _db = new SQLiteConnection(databasePath);
            _db.CreateTable<NewAssetData>();
            _db.CreateTable<MessageData>();
        }

        public void RunQuery(String query, string paramOne = "", string paramTwo = "")
        {
            if (!paramOne.Equals("") && paramOne.Equals("")) _db.Execute(query, paramOne);
            else if(!paramOne.Equals("") && !paramOne.Equals("")) _db.Execute(query, paramOne, paramTwo);
            else _db.Execute(query);
        }

        public void AddRecord(NewAssetData data)
        {
            _db.Insert(data);
        }

        public void AddRecord(MessageData data)
        {
            _db.Insert(data);
        }

        public void UpdateRecord(NewAssetData data)
        {
            _db.Update(data);
        }

        public void UpdateRecord(MessageData data)
        {
            _db.Update(data);
        }

        public void TruncateTable(String tableName)
        {
            switch (tableName)
            {
                case "NewAssetData":
                    _db.DeleteAll<NewAssetData>();
                    break;

                case "MessageData":
                    _db.DeleteAll<MessageData>();
                    break;
            }

            
        }

        public void DropTable(String tableName)
        {
            _db.Execute(String.Format(dbSP.DropTable, tableName));
        }

        public List<NewAssetData> RetrieveData(String sqlString)
        {
            return _db.Query<DBTools.NewAssetData>(sqlString);           
        }

        public List<MessageData> RetrieveMessageData(String sqlString)
        {
            return _db.Query<DBTools.MessageData>(sqlString);
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
