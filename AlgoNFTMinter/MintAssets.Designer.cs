
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
            this.btnMint = new System.Windows.Forms.Button();
            this.dgMain = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.radioTest = new System.Windows.Forms.RadioButton();
            this.radioMain = new System.Windows.Forms.RadioButton();
            this.btnOptIn = new System.Windows.Forms.Button();
            this.btnTransfer = new System.Windows.Forms.Button();
            this.btnPinata = new System.Windows.Forms.Button();
            this.lblUnit = new System.Windows.Forms.Label();
            this.txtbxUnitName = new System.Windows.Forms.TextBox();
            this.txtboxAssetName = new System.Windows.Forms.TextBox();
            this.lblAsset = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.operationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addBlankRecordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteHighlightedRecordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshGridToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearTablesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.runProcessToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importCSVTraitDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectImageFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateStatusFlagsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mintStatusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setAllTrueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setAllFalseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optInStatusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setAllTrueToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.setAllFalseToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.transferStatusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setAllTrueToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.setAllFalseToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.pinataStatusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setAllTrueToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.setAllFalseToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgMain)).BeginInit();
            this.panel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnMint
            // 
            this.btnMint.Location = new System.Drawing.Point(573, 47);
            this.btnMint.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnMint.Name = "btnMint";
            this.btnMint.Size = new System.Drawing.Size(171, 75);
            this.btnMint.TabIndex = 0;
            this.btnMint.Text = "Mint Assets";
            this.btnMint.UseVisualStyleBackColor = true;
            this.btnMint.Click += new System.EventHandler(this.btnMint_Click);
            // 
            // dgMain
            // 
            this.dgMain.AllowUserToOrderColumns = true;
            this.dgMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgMain.Location = new System.Drawing.Point(0, 0);
            this.dgMain.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgMain.Name = "dgMain";
            this.dgMain.RowHeadersWidth = 62;
            this.dgMain.RowTemplate.Height = 25;
            this.dgMain.Size = new System.Drawing.Size(2458, 961);
            this.dgMain.TabIndex = 5;
            this.dgMain.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgMain_CellValueChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgMain);
            this.panel1.Location = new System.Drawing.Point(0, 141);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(2458, 961);
            this.panel1.TabIndex = 0;
            // 
            // radioTest
            // 
            this.radioTest.AutoSize = true;
            this.radioTest.Checked = true;
            this.radioTest.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.radioTest.Location = new System.Drawing.Point(1148, 47);
            this.radioTest.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.radioTest.Name = "radioTest";
            this.radioTest.Size = new System.Drawing.Size(127, 36);
            this.radioTest.TabIndex = 9;
            this.radioTest.TabStop = true;
            this.radioTest.Text = "Test Net";
            this.radioTest.UseVisualStyleBackColor = true;
            // 
            // radioMain
            // 
            this.radioMain.AutoSize = true;
            this.radioMain.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.radioMain.Location = new System.Drawing.Point(1148, 86);
            this.radioMain.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.radioMain.Name = "radioMain";
            this.radioMain.Size = new System.Drawing.Size(139, 36);
            this.radioMain.TabIndex = 10;
            this.radioMain.Text = "Main Net";
            this.radioMain.UseVisualStyleBackColor = true;
            // 
            // btnOptIn
            // 
            this.btnOptIn.Location = new System.Drawing.Point(753, 47);
            this.btnOptIn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnOptIn.Name = "btnOptIn";
            this.btnOptIn.Size = new System.Drawing.Size(171, 75);
            this.btnOptIn.TabIndex = 11;
            this.btnOptIn.Text = "Opt In (Acct 2)";
            this.btnOptIn.UseVisualStyleBackColor = true;
            this.btnOptIn.Click += new System.EventHandler(this.btnOptIn_ClickAsync);
            // 
            // btnTransfer
            // 
            this.btnTransfer.Location = new System.Drawing.Point(932, 47);
            this.btnTransfer.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnTransfer.Name = "btnTransfer";
            this.btnTransfer.Size = new System.Drawing.Size(171, 75);
            this.btnTransfer.TabIndex = 12;
            this.btnTransfer.Text = "Transfer Assets";
            this.btnTransfer.UseVisualStyleBackColor = true;
            this.btnTransfer.Click += new System.EventHandler(this.btnTransfer_ClickAsync);
            // 
            // btnPinata
            // 
            this.btnPinata.Location = new System.Drawing.Point(364, 47);
            this.btnPinata.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnPinata.Name = "btnPinata";
            this.btnPinata.Size = new System.Drawing.Size(171, 75);
            this.btnPinata.TabIndex = 15;
            this.btnPinata.Text = "Upload to Pinata";
            this.btnPinata.UseVisualStyleBackColor = true;
            this.btnPinata.Click += new System.EventHandler(this.btnPinata_ClickAsync);
            // 
            // lblUnit
            // 
            this.lblUnit.AutoSize = true;
            this.lblUnit.Location = new System.Drawing.Point(24, 46);
            this.lblUnit.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUnit.Name = "lblUnit";
            this.lblUnit.Size = new System.Drawing.Size(100, 25);
            this.lblUnit.TabIndex = 16;
            this.lblUnit.Text = "Unit Name:";
            // 
            // txtbxUnitName
            // 
            this.txtbxUnitName.Location = new System.Drawing.Point(132, 43);
            this.txtbxUnitName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtbxUnitName.Name = "txtbxUnitName";
            this.txtbxUnitName.Size = new System.Drawing.Size(197, 31);
            this.txtbxUnitName.TabIndex = 17;
            // 
            // txtboxAssetName
            // 
            this.txtboxAssetName.Location = new System.Drawing.Point(132, 91);
            this.txtboxAssetName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtboxAssetName.Name = "txtboxAssetName";
            this.txtboxAssetName.Size = new System.Drawing.Size(197, 31);
            this.txtboxAssetName.TabIndex = 18;
            // 
            // lblAsset
            // 
            this.lblAsset.AutoSize = true;
            this.lblAsset.Location = new System.Drawing.Point(16, 86);
            this.lblAsset.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAsset.Name = "lblAsset";
            this.lblAsset.Size = new System.Drawing.Size(111, 25);
            this.lblAsset.TabIndex = 19;
            this.lblAsset.Text = "Asset Name:";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.operationsToolStripMenuItem,
            this.runProcessToolStripMenuItem,
            this.updateStatusFlagsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(2458, 33);
            this.menuStrip1.TabIndex = 29;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // operationsToolStripMenuItem
            // 
            this.operationsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addBlankRecordToolStripMenuItem,
            this.deleteHighlightedRecordToolStripMenuItem,
            this.refreshGridToolStripMenuItem,
            this.clearTablesToolStripMenuItem});
            this.operationsToolStripMenuItem.Name = "operationsToolStripMenuItem";
            this.operationsToolStripMenuItem.Size = new System.Drawing.Size(195, 29);
            this.operationsToolStripMenuItem.Text = "Database Operations";
            // 
            // addBlankRecordToolStripMenuItem
            // 
            this.addBlankRecordToolStripMenuItem.Name = "addBlankRecordToolStripMenuItem";
            this.addBlankRecordToolStripMenuItem.Size = new System.Drawing.Size(322, 34);
            this.addBlankRecordToolStripMenuItem.Text = "Add Blank Record";
            this.addBlankRecordToolStripMenuItem.Click += new System.EventHandler(this.addBlankRecordToolStripMenuItem_Click);
            // 
            // deleteHighlightedRecordToolStripMenuItem
            // 
            this.deleteHighlightedRecordToolStripMenuItem.Name = "deleteHighlightedRecordToolStripMenuItem";
            this.deleteHighlightedRecordToolStripMenuItem.Size = new System.Drawing.Size(322, 34);
            this.deleteHighlightedRecordToolStripMenuItem.Text = "Delete Highlighted Record";
            this.deleteHighlightedRecordToolStripMenuItem.Click += new System.EventHandler(this.deleteHighlightedRecordToolStripMenuItem_Click);
            // 
            // refreshGridToolStripMenuItem
            // 
            this.refreshGridToolStripMenuItem.Name = "refreshGridToolStripMenuItem";
            this.refreshGridToolStripMenuItem.Size = new System.Drawing.Size(322, 34);
            this.refreshGridToolStripMenuItem.Text = "Refresh Grid";
            this.refreshGridToolStripMenuItem.Click += new System.EventHandler(this.refreshGridToolStripMenuItem_Click);
            // 
            // clearTablesToolStripMenuItem
            // 
            this.clearTablesToolStripMenuItem.Name = "clearTablesToolStripMenuItem";
            this.clearTablesToolStripMenuItem.Size = new System.Drawing.Size(322, 34);
            this.clearTablesToolStripMenuItem.Text = "Clear Tables";
            this.clearTablesToolStripMenuItem.Click += new System.EventHandler(this.clearTablesToolStripMenuItem_Click);
            // 
            // runProcessToolStripMenuItem
            // 
            this.runProcessToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importCSVTraitDataToolStripMenuItem,
            this.selectImageFolderToolStripMenuItem});
            this.runProcessToolStripMenuItem.Name = "runProcessToolStripMenuItem";
            this.runProcessToolStripMenuItem.Size = new System.Drawing.Size(124, 29);
            this.runProcessToolStripMenuItem.Text = "Run Process";
            // 
            // importCSVTraitDataToolStripMenuItem
            // 
            this.importCSVTraitDataToolStripMenuItem.Name = "importCSVTraitDataToolStripMenuItem";
            this.importCSVTraitDataToolStripMenuItem.Size = new System.Drawing.Size(285, 34);
            this.importCSVTraitDataToolStripMenuItem.Text = "Import CSV Trait Data";
            this.importCSVTraitDataToolStripMenuItem.Click += new System.EventHandler(this.importCSVTraitDataToolStripMenuItem_Click);
            // 
            // selectImageFolderToolStripMenuItem
            // 
            this.selectImageFolderToolStripMenuItem.Name = "selectImageFolderToolStripMenuItem";
            this.selectImageFolderToolStripMenuItem.Size = new System.Drawing.Size(285, 34);
            this.selectImageFolderToolStripMenuItem.Text = "Select Image Folder";
            this.selectImageFolderToolStripMenuItem.Click += new System.EventHandler(this.selectImageFolderToolStripMenuItem_Click);
            // 
            // updateStatusFlagsToolStripMenuItem
            // 
            this.updateStatusFlagsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mintStatusToolStripMenuItem,
            this.optInStatusToolStripMenuItem,
            this.transferStatusToolStripMenuItem,
            this.pinataStatusToolStripMenuItem});
            this.updateStatusFlagsToolStripMenuItem.Name = "updateStatusFlagsToolStripMenuItem";
            this.updateStatusFlagsToolStripMenuItem.Size = new System.Drawing.Size(185, 29);
            this.updateStatusFlagsToolStripMenuItem.Text = "Update Status Flags";
            // 
            // mintStatusToolStripMenuItem
            // 
            this.mintStatusToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setAllTrueToolStripMenuItem,
            this.setAllFalseToolStripMenuItem});
            this.mintStatusToolStripMenuItem.Name = "mintStatusToolStripMenuItem";
            this.mintStatusToolStripMenuItem.Size = new System.Drawing.Size(228, 34);
            this.mintStatusToolStripMenuItem.Text = "Mint Status";
            // 
            // setAllTrueToolStripMenuItem
            // 
            this.setAllTrueToolStripMenuItem.Name = "setAllTrueToolStripMenuItem";
            this.setAllTrueToolStripMenuItem.Size = new System.Drawing.Size(207, 34);
            this.setAllTrueToolStripMenuItem.Text = "Set All True";
            this.setAllTrueToolStripMenuItem.Click += new System.EventHandler(this.setAllTrueToolStripMenuItem_Click);
            // 
            // setAllFalseToolStripMenuItem
            // 
            this.setAllFalseToolStripMenuItem.Name = "setAllFalseToolStripMenuItem";
            this.setAllFalseToolStripMenuItem.Size = new System.Drawing.Size(207, 34);
            this.setAllFalseToolStripMenuItem.Text = "Set All False";
            this.setAllFalseToolStripMenuItem.Click += new System.EventHandler(this.setAllFalseToolStripMenuItem_Click);
            // 
            // optInStatusToolStripMenuItem
            // 
            this.optInStatusToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setAllTrueToolStripMenuItem1,
            this.setAllFalseToolStripMenuItem1});
            this.optInStatusToolStripMenuItem.Name = "optInStatusToolStripMenuItem";
            this.optInStatusToolStripMenuItem.Size = new System.Drawing.Size(228, 34);
            this.optInStatusToolStripMenuItem.Text = "Opt In Status";
            // 
            // setAllTrueToolStripMenuItem1
            // 
            this.setAllTrueToolStripMenuItem1.Name = "setAllTrueToolStripMenuItem1";
            this.setAllTrueToolStripMenuItem1.Size = new System.Drawing.Size(207, 34);
            this.setAllTrueToolStripMenuItem1.Text = "Set All True";
            this.setAllTrueToolStripMenuItem1.Click += new System.EventHandler(this.setAllTrueToolStripMenuItem1_Click);
            // 
            // setAllFalseToolStripMenuItem1
            // 
            this.setAllFalseToolStripMenuItem1.Name = "setAllFalseToolStripMenuItem1";
            this.setAllFalseToolStripMenuItem1.Size = new System.Drawing.Size(207, 34);
            this.setAllFalseToolStripMenuItem1.Text = "Set All False";
            this.setAllFalseToolStripMenuItem1.Click += new System.EventHandler(this.setAllFalseToolStripMenuItem1_Click);
            // 
            // transferStatusToolStripMenuItem
            // 
            this.transferStatusToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setAllTrueToolStripMenuItem2,
            this.setAllFalseToolStripMenuItem2});
            this.transferStatusToolStripMenuItem.Name = "transferStatusToolStripMenuItem";
            this.transferStatusToolStripMenuItem.Size = new System.Drawing.Size(228, 34);
            this.transferStatusToolStripMenuItem.Text = "Transfer Status";
            // 
            // setAllTrueToolStripMenuItem2
            // 
            this.setAllTrueToolStripMenuItem2.Name = "setAllTrueToolStripMenuItem2";
            this.setAllTrueToolStripMenuItem2.Size = new System.Drawing.Size(207, 34);
            this.setAllTrueToolStripMenuItem2.Text = "Set All True";
            this.setAllTrueToolStripMenuItem2.Click += new System.EventHandler(this.setAllTrueToolStripMenuItem2_Click);
            // 
            // setAllFalseToolStripMenuItem2
            // 
            this.setAllFalseToolStripMenuItem2.Name = "setAllFalseToolStripMenuItem2";
            this.setAllFalseToolStripMenuItem2.Size = new System.Drawing.Size(207, 34);
            this.setAllFalseToolStripMenuItem2.Text = "Set All False";
            this.setAllFalseToolStripMenuItem2.Click += new System.EventHandler(this.setAllFalseToolStripMenuItem2_Click);
            // 
            // pinataStatusToolStripMenuItem
            // 
            this.pinataStatusToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setAllTrueToolStripMenuItem3,
            this.setAllFalseToolStripMenuItem3});
            this.pinataStatusToolStripMenuItem.Name = "pinataStatusToolStripMenuItem";
            this.pinataStatusToolStripMenuItem.Size = new System.Drawing.Size(228, 34);
            this.pinataStatusToolStripMenuItem.Text = "Pinata Status";
            // 
            // setAllTrueToolStripMenuItem3
            // 
            this.setAllTrueToolStripMenuItem3.Name = "setAllTrueToolStripMenuItem3";
            this.setAllTrueToolStripMenuItem3.Size = new System.Drawing.Size(207, 34);
            this.setAllTrueToolStripMenuItem3.Text = "Set All True";
            this.setAllTrueToolStripMenuItem3.Click += new System.EventHandler(this.setAllTrueToolStripMenuItem3_Click);
            // 
            // setAllFalseToolStripMenuItem3
            // 
            this.setAllFalseToolStripMenuItem3.Name = "setAllFalseToolStripMenuItem3";
            this.setAllFalseToolStripMenuItem3.Size = new System.Drawing.Size(207, 34);
            this.setAllFalseToolStripMenuItem3.Text = "Set All False";
            this.setAllFalseToolStripMenuItem3.Click += new System.EventHandler(this.setAllFalseToolStripMenuItem3_Click);
            // 
            // MintAssets
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblAsset);
            this.Controls.Add(this.txtboxAssetName);
            this.Controls.Add(this.txtbxUnitName);
            this.Controls.Add(this.lblUnit);
            this.Controls.Add(this.btnPinata);
            this.Controls.Add(this.btnTransfer);
            this.Controls.Add(this.btnOptIn);
            this.Controls.Add(this.radioMain);
            this.Controls.Add(this.radioTest);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnMint);
            this.Controls.Add(this.menuStrip1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "MintAssets";
            this.Size = new System.Drawing.Size(2458, 1102);
            ((System.ComponentModel.ISupportInitialize)(this.dgMain)).EndInit();
            this.panel1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnMint;
        private System.Windows.Forms.DataGridView dgMain;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton radioTest;
        private System.Windows.Forms.RadioButton radioMain;
        private System.Windows.Forms.Button btnOptIn;
        private System.Windows.Forms.Button btnTransfer;
        private System.Windows.Forms.Button btnPinata;
        private System.Windows.Forms.Label lblUnit;
        private System.Windows.Forms.TextBox txtbxUnitName;
        private System.Windows.Forms.TextBox txtboxAssetName;
        private System.Windows.Forms.Label lblAsset;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem operationsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addBlankRecordToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateStatusFlagsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mintStatusToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setAllTrueToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setAllFalseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optInStatusToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setAllTrueToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem setAllFalseToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem transferStatusToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setAllTrueToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem setAllFalseToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem refreshGridToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearTablesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteHighlightedRecordToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem runProcessToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importCSVTraitDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectImageFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pinataStatusToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setAllTrueToolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem setAllFalseToolStripMenuItem3;
    }
}
