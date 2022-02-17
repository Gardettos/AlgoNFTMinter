
namespace AlgoNFTMinter
{
    partial class Messaging
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
            this.dgMain = new System.Windows.Forms.DataGridView();
            this.btnAddASA = new System.Windows.Forms.Button();
            this.txtBxASA = new System.Windows.Forms.TextBox();
            this.btnLoadGrid = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.radioTest = new System.Windows.Forms.RadioButton();
            this.radioMain = new System.Windows.Forms.RadioButton();
            this.btnSendMessage = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgMain)).BeginInit();
            this.SuspendLayout();
            // 
            // dgMain
            // 
            this.dgMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgMain.Location = new System.Drawing.Point(3, 65);
            this.dgMain.Name = "dgMain";
            this.dgMain.RowTemplate.Height = 25;
            this.dgMain.Size = new System.Drawing.Size(797, 361);
            this.dgMain.TabIndex = 0;
            this.dgMain.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgMain_CellValueChanged);
            // 
            // btnAddASA
            // 
            this.btnAddASA.Location = new System.Drawing.Point(226, 19);
            this.btnAddASA.Name = "btnAddASA";
            this.btnAddASA.Size = new System.Drawing.Size(75, 23);
            this.btnAddASA.TabIndex = 1;
            this.btnAddASA.Text = "Add ASA";
            this.btnAddASA.UseVisualStyleBackColor = true;
            this.btnAddASA.Click += new System.EventHandler(this.btnAddASA_Click);
            // 
            // txtBxASA
            // 
            this.txtBxASA.Location = new System.Drawing.Point(70, 19);
            this.txtBxASA.Name = "txtBxASA";
            this.txtBxASA.Size = new System.Drawing.Size(137, 23);
            this.txtBxASA.TabIndex = 2;
            // 
            // btnLoadGrid
            // 
            this.btnLoadGrid.Location = new System.Drawing.Point(418, 36);
            this.btnLoadGrid.Name = "btnLoadGrid";
            this.btnLoadGrid.Size = new System.Drawing.Size(88, 23);
            this.btnLoadGrid.TabIndex = 3;
            this.btnLoadGrid.Text = "Refresh Table";
            this.btnLoadGrid.UseVisualStyleBackColor = true;
            this.btnLoadGrid.Click += new System.EventHandler(this.btnLoadGrid_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(418, 3);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(88, 23);
            this.btnClear.TabIndex = 4;
            this.btnClear.Text = "Clear Table";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // radioTest
            // 
            this.radioTest.AutoSize = true;
            this.radioTest.Checked = true;
            this.radioTest.Location = new System.Drawing.Point(717, 3);
            this.radioTest.Name = "radioTest";
            this.radioTest.Size = new System.Drawing.Size(67, 19);
            this.radioTest.TabIndex = 10;
            this.radioTest.TabStop = true;
            this.radioTest.Text = "Test Net";
            this.radioTest.UseVisualStyleBackColor = true;
            // 
            // radioMain
            // 
            this.radioMain.AutoSize = true;
            this.radioMain.Location = new System.Drawing.Point(717, 28);
            this.radioMain.Name = "radioMain";
            this.radioMain.Size = new System.Drawing.Size(74, 19);
            this.radioMain.TabIndex = 11;
            this.radioMain.Text = "Main Net";
            this.radioMain.UseVisualStyleBackColor = true;
            // 
            // btnSendMessage
            // 
            this.btnSendMessage.Location = new System.Drawing.Point(553, 7);
            this.btnSendMessage.Name = "btnSendMessage";
            this.btnSendMessage.Size = new System.Drawing.Size(78, 40);
            this.btnSendMessage.TabIndex = 12;
            this.btnSendMessage.Text = "Send Messages";
            this.btnSendMessage.UseVisualStyleBackColor = true;
            this.btnSendMessage.Click += new System.EventHandler(this.btnSendMessage_Click);
            // 
            // Messaging
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnSendMessage);
            this.Controls.Add(this.radioMain);
            this.Controls.Add(this.radioTest);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnLoadGrid);
            this.Controls.Add(this.txtBxASA);
            this.Controls.Add(this.btnAddASA);
            this.Controls.Add(this.dgMain);
            this.Name = "Messaging";
            this.Size = new System.Drawing.Size(800, 426);
            ((System.ComponentModel.ISupportInitialize)(this.dgMain)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgMain;
        private System.Windows.Forms.Button btnAddASA;
        private System.Windows.Forms.TextBox txtBxASA;
        private System.Windows.Forms.Button btnLoadGrid;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.RadioButton radioTest;
        private System.Windows.Forms.RadioButton radioMain;
        private System.Windows.Forms.Button btnSendMessage;
    }
}
