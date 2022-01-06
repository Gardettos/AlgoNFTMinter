using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace AlgoNFTMinter
{
    class ErrorHandler
    {

        public string ErrorMessage { get; set; }
        public bool ShowMessageBox { get; set; }
        public string ProgramName { get; set; }
        public ErrorHandler(string _programName)
        {
            this.ShowMessageBox = true;
            this.ProgramName = _programName;
        }

        public void ProcessError(System.Exception ex)
        {
            StringBuilder ErrorInfo = new StringBuilder();
            ErrorInfo.Append(string.Format("Program: {0}{1}", this.ProgramName, Environment.NewLine));
            string FileName = string.Empty;
            string MethodName = string.Empty;
            string LineNumber = string.Empty;

            System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(ex, true);
            int sfCount = 0;
            ErrorInfo.Append(string.Format("Error Message: {0}{1}", ex.Message, Environment.NewLine));
            foreach (System.Diagnostics.StackFrame sf in st.GetFrames())
            {
                if (sf.GetFileLineNumber() > 0)
                {
                    sfCount += 1;
                    ErrorInfo.Append(string.Format("Stackframe: {0}<br>", sfCount));
                    ErrorInfo.Append(string.Format("File: {0}<br>", System.IO.Path.GetFileName(sf.GetFileName())));
                    ErrorInfo.Append(string.Format("Method: {0}<br>", sf.GetMethod().Name));
                    ErrorInfo.Append(string.Format("Line: {0}<br><br>", sf.GetFileLineNumber()));

                    if (string.IsNullOrEmpty(FileName))
                    {
                        FileName = System.IO.Path.GetFileName(sf.GetFileName());
                        MethodName = sf.GetMethod().Name;
                        LineNumber = sf.GetFileLineNumber().ToString();
                    }
                }
            }
            this.ErrorMessage = ErrorInfo.ToString();

            if (this.ShowMessageBox)
                MessageBox.Show(string.Format("{0}{1}{1}{2}", this.ErrorMessage, Environment.NewLine, ErrorInfo), this.ProgramName, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

    }
}
