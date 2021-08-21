namespace WebScraping
{
    partial class setting
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
            this.OutFolderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.RefBtn_output = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.OutFolderLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // RefBtn_output
            // 
            this.RefBtn_output.Font = new System.Drawing.Font("MS UI Gothic", 16F);
            this.RefBtn_output.Location = new System.Drawing.Point(653, 69);
            this.RefBtn_output.Name = "RefBtn_output";
            this.RefBtn_output.Size = new System.Drawing.Size(80, 42);
            this.RefBtn_output.TabIndex = 0;
            this.RefBtn_output.Text = "参照";
            this.RefBtn_output.UseVisualStyleBackColor = true;
            this.RefBtn_output.Click += new System.EventHandler(this.RefBtn_output_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 16F);
            this.label1.Location = new System.Drawing.Point(24, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(211, 27);
            this.label1.TabIndex = 1;
            this.label1.Text = "書き出し先フォルダ";
            // 
            // OutFolderLabel
            // 
            this.OutFolderLabel.AutoSize = true;
            this.OutFolderLabel.Font = new System.Drawing.Font("MS UI Gothic", 16F);
            this.OutFolderLabel.Location = new System.Drawing.Point(41, 77);
            this.OutFolderLabel.Name = "OutFolderLabel";
            this.OutFolderLabel.Size = new System.Drawing.Size(180, 27);
            this.OutFolderLabel.TabIndex = 1;
            this.OutFolderLabel.Text = "xxxxxxxxxxxxxx";
            // 
            // setting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.OutFolderLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.RefBtn_output);
            this.Name = "setting";
            this.Text = "setting";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog OutFolderBrowser;
        private System.Windows.Forms.Button RefBtn_output;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label OutFolderLabel;
    }
}