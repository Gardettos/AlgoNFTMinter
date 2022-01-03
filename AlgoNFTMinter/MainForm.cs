using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlgoNFTMinter
{
    public partial class MainForm : Form
    {
       
        public MainForm()
        {
            InitializeComponent();    
        }

        private void menuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            panelMain.Controls.Clear();

             if (e.ClickedItem.Text == "Mint Assets")
            {
                panelMain.Controls.Add(new MintAssets());
            }

        }
    }

}
