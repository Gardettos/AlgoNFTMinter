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
        IConfiguration config;
      

        public ImportData()
        {
            InitializeComponent();
            config = new ConfigurationBuilder()
              .AddJsonFile("appsettings.json", true, true)
              .Build();
        }

        private void btnImport_Click(object sender, EventArgs e)
        {

            if (File.Exists(config["csvPath"]))
            {
                ImportCSVFile(config["csvPath"]);
                            
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

            foreach (var r in results)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(String.Format("{0}, {1}, {2}, {3}, {4}, {5}",
                                            r.Name.ToString(),
                                            r.UnitName.ToString(),
                                            r.Total.ToString(),
                                            r.Decimals.ToString(),
                                            r.URL.ToString(),
                                            r.MetaDataHash.ToString()));
                listBox.Items.Add(sb);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Program.db.TruncateTable();

            listBox.Items.Clear();


        }
    }
}
