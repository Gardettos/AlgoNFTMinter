using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using AlgoNFTMinter.DBTools;
using Microsoft.Extensions.Configuration;

namespace AlgoNFTMinter
{
    static class Program
    {
        public static DatabaseHandler db;
        public static IConfiguration config;
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException);
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            config = new ConfigurationBuilder()
              .AddJsonFile("appsettings.json", true, true)
              .Build();

            db = new DatabaseHandler();
            Application.Run(new MainForm());
        }

        private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            var ErrorHandler = new ErrorHandler("AlgoNFTMinter");
            ErrorHandler.ProcessError(e.Exception);

        }
        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs args)
        {
            var ErrorHandler = new ErrorHandler("AlgoNFTMinter");
            ErrorHandler.ProcessError((Exception) args.ExceptionObject);
        }

    }
}
