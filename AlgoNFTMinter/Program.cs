using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using AlgoNFTMinter.DBTools;
namespace AlgoNFTMinter
{
    static class Program
    {
        public static DatabaseHandler db;

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            db = new DatabaseHandler();

            Application.Run(new MainForm());
        }
    }
}
