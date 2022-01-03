using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoNFTMinter.DBTools
{
    [Table("NewAssetData")]
    class NewAssetData
    {
        [PrimaryKey, AutoIncrement]
        [Column("id")]
        public int Id { get; set; }

        [Column("clawback")]
        public string Clawback { get; set; }

        [Column("decimals")]
        public string Decimals { get; set; }

        [Column("defaultFrozen")]
        public string DefaultFrozen { get; set; }

        [Column("freeze")]
        public string Freeze { get; set; }

        [Column("manager")]
        public string Manager { get; set; }

        [Column("metaDataHash")]
        public string MetaDataHash { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("reserve")]
        public string Reserve { get; set; }

        [Column("total")]
        public string Total { get; set; }

        [Column("unitName")]
        public string UnitName { get; set; }

        [Column("url")]
        public string URL { get; set; }

        [Column("mintAssetFlag")]
        public bool MintAssetFlag { get; set; } = false;

        [Column("assetId")]
        public string AssetID { get; set; }


    }
}
