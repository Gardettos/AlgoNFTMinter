using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace AlgoNFTMinter.DBTools
{
    [Table("MessageData")]
    class MessageData
    {
        [PrimaryKey, AutoIncrement]
        [Column("id")]
        public int Id { get; set; }

        [Column("assetId")]
        public string AssetID { get; set; }

        [Column("unitName")]
        public string UnitName { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("sendMessageFlag")]
        public bool SendMessageFlag { get; set; } = false;

        [Column("message")]
        public string Message { get; set; }

        [Column("refreshHolderFlag")]
        public bool RefreshHolderFlag { get; set; } = false;

        [Column("holderAddress")]
        public string HolderAddress { get; set; }
    }
}
