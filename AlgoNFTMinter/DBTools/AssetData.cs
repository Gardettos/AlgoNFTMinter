using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoNFTMinter.DBTools
{
    [Table("AssetData")]
    class AssetData
    {
        [PrimaryKey, AutoIncrement]
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("unitName")]
        public string UnitName { get; set; }

        [Column("total")]
        public string Total { get; set; }

        [Column("decimals")]
        public string Decimals { get; set; }

        [Column("url")]
        public string URL { get; set; }

        [Column("metaDataHash")]
        public string MetaDataHash { get; set; }
    }
}
