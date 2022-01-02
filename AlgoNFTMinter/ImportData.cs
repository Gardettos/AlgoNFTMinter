using AlgoNFTMinter.DBTools;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AlgoNFTMinter
{
    public partial class ImportData : UserControl
    {
 
        public ImportData()
        {
            InitializeComponent();
 
        }

        private void btnImport_Click(object sender, EventArgs e)
        {

            if (File.Exists(Program.config["csvPath"]))
            {
                ImportCSVFile(Program.config["csvPath"]);
                            
            }
            else
            {
                //throw error
                MessageBox.Show("CSV File Missing");
                
            }

        }

        private void ImportCSVFile(String filePath)
        {
            using (StreamReader sr = new StreamReader(filePath))
            {
                string headerLine = sr.ReadLine();
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    List<string> lineValues = line.Split(',').ToList();

                    var Asset = new DBTools.AssetData
                    {
                        Name = lineValues[0].ToString(),
                        UnitName = lineValues[1].ToString(),
                        Total = lineValues[2].ToString(),
                        Decimals = lineValues[3].ToString(),
                        URL = lineValues[4].ToString(),
                        MetaDataHash = lineValues[5].ToString()
                    };

                    Program.db.AddRecord(Asset);
                                
                }
            }
        }

        private void btnGetData_Click(object sender, EventArgs e)
        {
            var results = Program.db.RetrieveData(dbSP.GetAllData);
            dgMain.DataSource = results;
           
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Program.db.TruncateTable();

        }
    }
}
