
namespace AlgoNFTMinter
{
    partial class MintAssets
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnClear = new System.Windows.Forms.Button();
            this.btnGetData = new System.Windows.Forms.Button();
            this.btnImport = new System.Windows.Forms.Button();
            this.btnMint = new System.Windows.Forms.Button();
            this.dgMain = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.radioTest = new System.Windows.Forms.RadioButton();
            this.radioMain = new System.Windows.Forms.RadioButton();
            this.btnOptIn = new System.Windows.Forms.Button();
            this.btnTransfer = new System.Windows.Forms.Button();
            this.btnPrep = new System.Windows.Forms.Button();
            this.btnARC = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgMain)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(116, 11);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(86, 24);
            this.btnClear.TabIndex = 8;
            this.btnClear.Text = "Clear Tables";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnGetData
            // 
            this.btnGetData.Location = new System.Drawing.Point(116, 39);
            this.btnGetData.Name = "btnGetData";
            this.btnGetData.Size = new System.Drawing.Size(86, 23);
            this.btnGetData.TabIndex = 7;
            this.btnGetData.Text = "Refresh Table";
            this.btnGetData.UseVisualStyleBackColor = true;
            this.btnGetData.Click += new System.EventHandler(this.btnGetData_Click);
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(26, 39);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(75, 23);
            this.btnImport.TabIndex = 6;
            this.btnImport.Text = "Import CSV";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // btnMint
            // 
            this.btnMint.Location = new System.Drawing.Point(357, 13);
            this.btnMint.Name = "btnMint";
            this.btnMint.Size = new System.Drawing.Size(75, 23);
            this.btnMint.TabIndex = 0;
            this.btnMint.Text = "Mint";
            this.btnMint.UseVisualStyleBackColor = true;
            this.btnMint.Click += new System.EventHandler(this.btnMint_Click);
            // 
            // dgMain
            // 
            this.dgMain.AllowUserToOrderColumns = true;
            this.dgMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgMain.Location = new System.Drawing.Point(0, 0);
            this.dgMain.Name = "dgMain";
            this.dgMain.RowTemplate.Height = 25;
            this.dgMain.Size = new System.Drawing.Size(800, 354);
            this.dgMain.TabIndex = 5;
            this.dgMain.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgMain_CellValueChanged);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.dgMain);
            this.panel1.Location = new System.Drawing.Point(0, 72);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 354);
            this.panel1.TabIndex = 0;
            // 
            // radioTest
            // 
            this.radioTest.AutoSize = true;
            this.radioTest.Checked = true;
            this.radioTest.Location = new System.Drawing.Point(709, 11);
            this.radioTest.Name = "radioTest";
            this.radioTest.Size = new System.Drawing.Size(67, 19);
            this.radioTest.TabIndex = 9;
            this.radioTest.TabStop = true;
            this.radioTest.Text = "Test Net";
            this.radioTest.UseVisualStyleBackColor = true;
            // 
            // radioMain
            // 
            this.radioMain.AutoSize = true;
            this.radioMain.Location = new System.Drawing.Point(709, 37);
            this.radioMain.Name = "radioMain";
            this.radioMain.Size = new System.Drawing.Size(74, 19);
            this.radioMain.TabIndex = 10;
            this.radioMain.Text = "Main Net";
            this.radioMain.UseVisualStyleBackColor = true;
            // 
            // btnOptIn
            // 
            this.btnOptIn.Location = new System.Drawing.Point(455, 11);
            this.btnOptIn.Name = "btnOptIn";
            this.btnOptIn.Size = new System.Drawing.Size(110, 23);
            this.btnOptIn.TabIndex = 11;
            this.btnOptIn.Text = "Opt In (Acct 2)";
            this.btnOptIn.UseVisualStyleBackColor = true;
            this.btnOptIn.Click += new System.EventHandler(this.btnOptIn_ClickAsync);
            // 
            // btnTransfer
            // 
            this.btnTransfer.Location = new System.Drawing.Point(455, 45);
            this.btnTransfer.Name = "btnTransfer";
            this.btnTransfer.Size = new System.Drawing.Size(110, 23);
            this.btnTransfer.TabIndex = 12;
            this.btnTransfer.Text = "Transfer Asset";
            this.btnTransfer.UseVisualStyleBackColor = true;
            this.btnTransfer.Click += new System.EventHandler(this.btnTransfer_ClickAsync);
            // 
            // btnPrep
            // 
            this.btnPrep.Location = new System.Drawing.Point(254, 13);
            this.btnPrep.Name = "btnPrep";
            this.btnPrep.Size = new System.Drawing.Size(75, 23);
            this.btnPrep.TabIndex = 13;
            this.btnPrep.Text = "Prep Data";
            this.btnPrep.UseVisualStyleBackColor = true;
            this.btnPrep.Click += new System.EventHandler(this.btnPrep_Click);
            // 
            // btnARC
            // 
            this.btnARC.Location = new System.Drawing.Point(590, 13);
            this.btnARC.Name = "btnARC";
            this.btnARC.Size = new System.Drawing.Size(75, 23);
            this.btnARC.TabIndex = 14;
            this.btnARC.Text = "ARC69";
            this.btnARC.UseVisualStyleBackColor = true;
            this.btnARC.Click += new System.EventHandler(this.btnARC_Click);
            // 
            // MintAssets
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnARC);
            this.Controls.Add(this.btnPrep);
            this.Controls.Add(this.btnTransfer);
            this.Controls.Add(this.btnOptIn);
            this.Controls.Add(this.radioMain);
            this.Controls.Add(this.radioTest);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnGetData);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.btnMint);
            this.Name = "MintAssets";
            this.Size = new System.Drawing.Size(800, 426);
            ((System.ComponentModel.ISupportInitialize)(this.dgMain)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnMint;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnGetData;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.DataGridView dgMain;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton radioTest;
        private System.Windows.Forms.RadioButton radioMain;
        private System.Windows.Forms.Button btnOptIn;
        private System.Windows.Forms.Button btnTransfer;
        private System.Windows.Forms.Button btnPrep;
        private System.Windows.Forms.Button btnARC;
    }
}
