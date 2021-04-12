
namespace CIA_Decoder
{
    partial class Form1
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.UndecodedIMG = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Open = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenFile = new System.Windows.Forms.OpenFileDialog();
            this.Decipher = new System.Windows.Forms.Button();
            this.secretCodeTXT = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.UndecodedIMG)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // UndecodedIMG
            // 
            this.UndecodedIMG.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.UndecodedIMG.Location = new System.Drawing.Point(40, 42);
            this.UndecodedIMG.Name = "UndecodedIMG";
            this.UndecodedIMG.Size = new System.Drawing.Size(340, 384);
            this.UndecodedIMG.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.UndecodedIMG.TabIndex = 1;
            this.UndecodedIMG.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Open});
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.openToolStripMenuItem.Text = "open";
            // 
            // Open
            // 
            this.Open.Name = "Open";
            this.Open.Size = new System.Drawing.Size(90, 22);
            this.Open.Text = "file";
            this.Open.Click += new System.EventHandler(this.OpenFile_Click);
            // 
            // OpenFile
            // 
            this.OpenFile.FileName = "openFileDialog1";
            this.OpenFile.Filter = "PPM Files|*.ppm";
            // 
            // Decipher
            // 
            this.Decipher.Location = new System.Drawing.Point(405, 42);
            this.Decipher.Name = "Decipher";
            this.Decipher.Size = new System.Drawing.Size(288, 87);
            this.Decipher.TabIndex = 4;
            this.Decipher.Text = "Decipher";
            this.Decipher.UseVisualStyleBackColor = true;
            this.Decipher.Click += new System.EventHandler(this.Decipher_Click);
            // 
            // secretCodeTXT
            // 
            this.secretCodeTXT.Enabled = false;
            this.secretCodeTXT.Location = new System.Drawing.Point(405, 145);
            this.secretCodeTXT.Multiline = true;
            this.secretCodeTXT.Name = "secretCodeTXT";
            this.secretCodeTXT.Size = new System.Drawing.Size(288, 80);
            this.secretCodeTXT.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.secretCodeTXT);
            this.Controls.Add(this.Decipher);
            this.Controls.Add(this.UndecodedIMG);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.UndecodedIMG)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox UndecodedIMG;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Open;
        private System.Windows.Forms.OpenFileDialog OpenFile;
        private System.Windows.Forms.Button Decipher;
        private System.Windows.Forms.TextBox secretCodeTXT;
    }
}

