﻿
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnMint = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnMint);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(590, 311);
            this.panel1.TabIndex = 0;
            // 
            // btnMint
            // 
            this.btnMint.Location = new System.Drawing.Point(41, 51);
            this.btnMint.Name = "btnMint";
            this.btnMint.Size = new System.Drawing.Size(75, 23);
            this.btnMint.TabIndex = 0;
            this.btnMint.Text = "Mint";
            this.btnMint.UseVisualStyleBackColor = true;
            this.btnMint.Click += new System.EventHandler(this.btnMint_Click);
            // 
            // MintAssets
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "MintAssets";
            this.Size = new System.Drawing.Size(590, 311);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnMint;
    }
}
