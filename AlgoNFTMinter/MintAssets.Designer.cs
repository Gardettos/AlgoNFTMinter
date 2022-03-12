
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
            this.btnRefreshTable = new System.Windows.Forms.Button();
            this.btnImport = new System.Windows.Forms.Button();
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
            this.btnImageLocation = new System.Windows.Forms.Button();
            this.radioMint = new System.Windows.Forms.RadioButton();
            this.radioOptIn = new System.Windows.Forms.RadioButton();
            this.radioTransfer = new System.Windows.Forms.RadioButton();
            this.btnUpdateTrue = new System.Windows.Forms.Button();
            this.btnUpdateFalse = new System.Windows.Forms.Button();
            this.grpStatus = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgMain)).BeginInit();
            this.panel1.SuspendLayout();
            this.grpStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(17, 15);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(120, 45);
            this.btnClear.TabIndex = 8;
            this.btnClear.Text = "Clear Tables";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnRefreshTable
            // 
            this.btnRefreshTable.Location = new System.Drawing.Point(17, 69);
            this.btnRefreshTable.Name = "btnRefreshTable";
            this.btnRefreshTable.Size = new System.Drawing.Size(120, 45);
            this.btnRefreshTable.TabIndex = 7;
            this.btnRefreshTable.Text = "Refresh Grid";
            this.btnRefreshTable.UseVisualStyleBackColor = true;
            this.btnRefreshTable.Click += new System.EventHandler(this.btnRefreshTable_Click);
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(437, 15);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(129, 52);
            this.btnImport.TabIndex = 6;
            this.btnImport.Text = "Import CSV Trait Data";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // btnMint
            // 
            this.btnMint.Location = new System.Drawing.Point(1065, 15);
            this.btnMint.Name = "btnMint";
            this.btnMint.Size = new System.Drawing.Size(120, 45);
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
            this.dgMain.Name = "dgMain";
            this.dgMain.RowTemplate.Height = 25;
            this.dgMain.Size = new System.Drawing.Size(1525, 506);
            this.dgMain.TabIndex = 5;
            this.dgMain.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgMain_CellValueChanged);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.dgMain);
            this.panel1.Location = new System.Drawing.Point(0, 131);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1525, 506);
            this.panel1.TabIndex = 0;
            // 
            // radioTest
            // 
            this.radioTest.AutoSize = true;
            this.radioTest.Checked = true;
            this.radioTest.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.radioTest.Location = new System.Drawing.Point(1332, 11);
            this.radioTest.Name = "radioTest";
            this.radioTest.Size = new System.Drawing.Size(97, 29);
            this.radioTest.TabIndex = 9;
            this.radioTest.TabStop = true;
            this.radioTest.Text = "Test Net";
            this.radioTest.UseVisualStyleBackColor = true;
            // 
            // radioMain
            // 
            this.radioMain.AutoSize = true;
            this.radioMain.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.radioMain.Location = new System.Drawing.Point(1332, 46);
            this.radioMain.Name = "radioMain";
            this.radioMain.Size = new System.Drawing.Size(108, 29);
            this.radioMain.TabIndex = 10;
            this.radioMain.Text = "Main Net";
            this.radioMain.UseVisualStyleBackColor = true;
            // 
            // btnOptIn
            // 
            this.btnOptIn.Location = new System.Drawing.Point(1191, 15);
            this.btnOptIn.Name = "btnOptIn";
            this.btnOptIn.Size = new System.Drawing.Size(120, 45);
            this.btnOptIn.TabIndex = 11;
            this.btnOptIn.Text = "Opt In (Acct 2)";
            this.btnOptIn.UseVisualStyleBackColor = true;
            this.btnOptIn.Click += new System.EventHandler(this.btnOptIn_ClickAsync);
            // 
            // btnTransfer
            // 
            this.btnTransfer.Location = new System.Drawing.Point(1191, 73);
            this.btnTransfer.Name = "btnTransfer";
            this.btnTransfer.Size = new System.Drawing.Size(120, 45);
            this.btnTransfer.TabIndex = 12;
            this.btnTransfer.Text = "Transfer Assets";
            this.btnTransfer.UseVisualStyleBackColor = true;
            this.btnTransfer.Click += new System.EventHandler(this.btnTransfer_ClickAsync);
            // 
            // btnPinata
            // 
            this.btnPinata.Location = new System.Drawing.Point(585, 74);
            this.btnPinata.Name = "btnPinata";
            this.btnPinata.Size = new System.Drawing.Size(129, 45);
            this.btnPinata.TabIndex = 15;
            this.btnPinata.Text = "Upload to Pinata";
            this.btnPinata.UseVisualStyleBackColor = true;
            this.btnPinata.Click += new System.EventHandler(this.btnPinata_ClickAsync);
            // 
            // lblUnit
            // 
            this.lblUnit.AutoSize = true;
            this.lblUnit.Location = new System.Drawing.Point(213, 19);
            this.lblUnit.Name = "lblUnit";
            this.lblUnit.Size = new System.Drawing.Size(67, 15);
            this.lblUnit.TabIndex = 16;
            this.lblUnit.Text = "Unit Name:";
            // 
            // txtbxUnitName
            // 
            this.txtbxUnitName.Location = new System.Drawing.Point(283, 15);
            this.txtbxUnitName.Name = "txtbxUnitName";
            this.txtbxUnitName.Size = new System.Drawing.Size(139, 23);
            this.txtbxUnitName.TabIndex = 17;
            // 
            // txtboxAssetName
            // 
            this.txtboxAssetName.Location = new System.Drawing.Point(283, 44);
            this.txtboxAssetName.Name = "txtboxAssetName";
            this.txtboxAssetName.Size = new System.Drawing.Size(139, 23);
            this.txtboxAssetName.TabIndex = 18;
            // 
            // lblAsset
            // 
            this.lblAsset.AutoSize = true;
            this.lblAsset.Location = new System.Drawing.Point(207, 43);
            this.lblAsset.Name = "lblAsset";
            this.lblAsset.Size = new System.Drawing.Size(73, 15);
            this.lblAsset.TabIndex = 19;
            this.lblAsset.Text = "Asset Name:";
            // 
            // btnImageLocation
            // 
            this.btnImageLocation.Location = new System.Drawing.Point(585, 15);
            this.btnImageLocation.Name = "btnImageLocation";
            this.btnImageLocation.Size = new System.Drawing.Size(129, 52);
            this.btnImageLocation.TabIndex = 20;
            this.btnImageLocation.Text = "Set Image Locations";
            this.btnImageLocation.UseVisualStyleBackColor = true;
            this.btnImageLocation.Click += new System.EventHandler(this.btnImageLocation_Click);
            // 
            // radioMint
            // 
            this.radioMint.AutoSize = true;
            this.radioMint.Location = new System.Drawing.Point(6, 22);
            this.radioMint.Name = "radioMint";
            this.radioMint.Size = new System.Drawing.Size(85, 19);
            this.radioMint.TabIndex = 21;
            this.radioMint.TabStop = true;
            this.radioMint.Text = "Mint Status";
            this.radioMint.UseVisualStyleBackColor = true;
            // 
            // radioOptIn
            // 
            this.radioOptIn.AutoSize = true;
            this.radioOptIn.Location = new System.Drawing.Point(6, 43);
            this.radioOptIn.Name = "radioOptIn";
            this.radioOptIn.Size = new System.Drawing.Size(93, 19);
            this.radioOptIn.TabIndex = 22;
            this.radioOptIn.TabStop = true;
            this.radioOptIn.Text = "Opt In Status";
            this.radioOptIn.UseVisualStyleBackColor = true;
            // 
            // radioTransfer
            // 
            this.radioTransfer.AutoSize = true;
            this.radioTransfer.Location = new System.Drawing.Point(6, 63);
            this.radioTransfer.Name = "radioTransfer";
            this.radioTransfer.Size = new System.Drawing.Size(101, 19);
            this.radioTransfer.TabIndex = 23;
            this.radioTransfer.TabStop = true;
            this.radioTransfer.Text = "Transfer Status";
            this.radioTransfer.UseVisualStyleBackColor = true;
            // 
            // btnUpdateTrue
            // 
            this.btnUpdateTrue.Location = new System.Drawing.Point(107, 22);
            this.btnUpdateTrue.Name = "btnUpdateTrue";
            this.btnUpdateTrue.Size = new System.Drawing.Size(87, 31);
            this.btnUpdateTrue.TabIndex = 24;
            this.btnUpdateTrue.Text = "Set All True";
            this.btnUpdateTrue.UseVisualStyleBackColor = true;
            this.btnUpdateTrue.Click += new System.EventHandler(this.btnUpdateTrue_Click);
            // 
            // btnUpdateFalse
            // 
            this.btnUpdateFalse.Location = new System.Drawing.Point(107, 58);
            this.btnUpdateFalse.Name = "btnUpdateFalse";
            this.btnUpdateFalse.Size = new System.Drawing.Size(87, 31);
            this.btnUpdateFalse.TabIndex = 25;
            this.btnUpdateFalse.Text = "Set All False";
            this.btnUpdateFalse.UseVisualStyleBackColor = true;
            this.btnUpdateFalse.Click += new System.EventHandler(this.btnUpdateFalse_Click);
            // 
            // grpStatus
            // 
            this.grpStatus.Controls.Add(this.btnUpdateTrue);
            this.grpStatus.Controls.Add(this.radioTransfer);
            this.grpStatus.Controls.Add(this.btnUpdateFalse);
            this.grpStatus.Controls.Add(this.radioOptIn);
            this.grpStatus.Controls.Add(this.radioMint);
            this.grpStatus.Location = new System.Drawing.Point(830, 15);
            this.grpStatus.Name = "grpStatus";
            this.grpStatus.Size = new System.Drawing.Size(207, 99);
            this.grpStatus.TabIndex = 26;
            this.grpStatus.TabStop = false;
            this.grpStatus.Text = "Update Status";
            // 
            // MintAssets
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grpStatus);
            this.Controls.Add(this.btnImageLocation);
            this.Controls.Add(this.lblAsset);
            this.Controls.Add(this.txtboxAssetName);
            this.Controls.Add(this.txtbxUnitName);
            this.Controls.Add(this.lblUnit);
            this.Controls.Add(this.btnPinata);
            this.Controls.Add(this.btnTransfer);
            this.Controls.Add(this.btnOptIn);
            this.Controls.Add(this.radioMain);
            this.Controls.Add(this.radioTest);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnRefreshTable);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.btnMint);
            this.Name = "MintAssets";
            this.Size = new System.Drawing.Size(1525, 637);
            ((System.ComponentModel.ISupportInitialize)(this.dgMain)).EndInit();
            this.panel1.ResumeLayout(false);
            this.grpStatus.ResumeLayout(false);
            this.grpStatus.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnMint;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnRefreshTable;
        private System.Windows.Forms.Button btnImport;
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
        private System.Windows.Forms.Button btnImageLocation;
        private System.Windows.Forms.RadioButton radioMint;
        private System.Windows.Forms.RadioButton radioOptIn;
        private System.Windows.Forms.RadioButton radioTransfer;
        private System.Windows.Forms.Button btnUpdateTrue;
        private System.Windows.Forms.Button btnUpdateFalse;
        private System.Windows.Forms.GroupBox grpStatus;
    }
}
