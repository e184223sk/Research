namespace WebScraping
{
    partial class DataSetEditor
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
            this.referenceIndex = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.programText = new System.Windows.Forms.RichTextBox();
            this.translateText = new System.Windows.Forms.RichTextBox();
            this.Plus = new System.Windows.Forms.Button();
            this.Minus = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Save = new System.Windows.Forms.ToolStripMenuItem();
            this.programPlus = new System.Windows.Forms.Button();
            this.programMinus = new System.Windows.Forms.Button();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PageRightToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ページ左に移動ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.プログラム右に移動ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.プログラム左に移動ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // referenceIndex
            // 
            this.referenceIndex.Location = new System.Drawing.Point(66, 53);
            this.referenceIndex.Name = "referenceIndex";
            this.referenceIndex.Size = new System.Drawing.Size(73, 19);
            this.referenceIndex.TabIndex = 0;
            this.referenceIndex.Text = "0000";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(64, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "参照中の番号";
            // 
            // programText
            // 
            this.programText.Location = new System.Drawing.Point(12, 134);
            this.programText.Name = "programText";
            this.programText.Size = new System.Drawing.Size(381, 353);
            this.programText.TabIndex = 2;
            this.programText.Text = "";
            // 
            // translateText
            // 
            this.translateText.Location = new System.Drawing.Point(420, 134);
            this.translateText.Name = "translateText";
            this.translateText.Size = new System.Drawing.Size(368, 353);
            this.translateText.TabIndex = 3;
            this.translateText.Text = "";
            this.translateText.TextChanged += new System.EventHandler(this.TranslateChanged);
            // 
            // Plus
            // 
            this.Plus.Location = new System.Drawing.Point(145, 53);
            this.Plus.Name = "Plus";
            this.Plus.Size = new System.Drawing.Size(20, 20);
            this.Plus.TabIndex = 4;
            this.Plus.Text = ">";
            this.Plus.UseVisualStyleBackColor = true;
            this.Plus.Click += new System.EventHandler(this.Plus_Click);
            // 
            // Minus
            // 
            this.Minus.Location = new System.Drawing.Point(40, 53);
            this.Minus.Name = "Minus";
            this.Minus.Size = new System.Drawing.Size(20, 20);
            this.Minus.TabIndex = 4;
            this.Minus.Text = "<";
            this.Minus.UseVisualStyleBackColor = true;
            this.Minus.Click += new System.EventHandler(this.Minus_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.Location = new System.Drawing.Point(178, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 19);
            this.label2.TabIndex = 5;
            this.label2.Text = "プログラム";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label3.Location = new System.Drawing.Point(575, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 19);
            this.label3.TabIndex = 5;
            this.label3.Text = "翻訳文";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Save});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // Save
            // 
            this.Save.Name = "Save";
            this.Save.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.Save.Size = new System.Drawing.Size(180, 22);
            this.Save.Text = "追記して保存";
            this.Save.Click += new System.EventHandler(this.AddandSave);
            // 
            // programPlus
            // 
            this.programPlus.Location = new System.Drawing.Point(265, 101);
            this.programPlus.Name = "programPlus";
            this.programPlus.Size = new System.Drawing.Size(20, 20);
            this.programPlus.TabIndex = 4;
            this.programPlus.Text = ">";
            this.programPlus.UseVisualStyleBackColor = true;
            this.programPlus.Click += new System.EventHandler(this.programPlus_Click);
            // 
            // programMinus
            // 
            this.programMinus.Location = new System.Drawing.Point(146, 100);
            this.programMinus.Name = "programMinus";
            this.programMinus.Size = new System.Drawing.Size(20, 20);
            this.programMinus.TabIndex = 4;
            this.programMinus.Text = "<";
            this.programMinus.UseVisualStyleBackColor = true;
            this.programMinus.Click += new System.EventHandler(this.programMinus_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PageRightToolStripMenuItem,
            this.ページ左に移動ToolStripMenuItem,
            this.プログラム右に移動ToolStripMenuItem,
            this.プログラム左に移動ToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.editToolStripMenuItem.Text = "ページ移動";
            // 
            // PageRightToolStripMenuItem
            // 
            this.PageRightToolStripMenuItem.Name = "PageRightToolStripMenuItem";
            this.PageRightToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.M)));
            this.PageRightToolStripMenuItem.Size = new System.Drawing.Size(229, 22);
            this.PageRightToolStripMenuItem.Text = "1ページ右に移動";
            this.PageRightToolStripMenuItem.Click += new System.EventHandler(this.Plus_Click);
            // 
            // ページ左に移動ToolStripMenuItem
            // 
            this.ページ左に移動ToolStripMenuItem.Name = "ページ左に移動ToolStripMenuItem";
            this.ページ左に移動ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.N)));
            this.ページ左に移動ToolStripMenuItem.Size = new System.Drawing.Size(229, 22);
            this.ページ左に移動ToolStripMenuItem.Text = "1ページ左に移動";
            this.ページ左に移動ToolStripMenuItem.Click += new System.EventHandler(this.Minus_Click);
            // 
            // プログラム右に移動ToolStripMenuItem
            // 
            this.プログラム右に移動ToolStripMenuItem.Name = "プログラム右に移動ToolStripMenuItem";
            this.プログラム右に移動ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.M)));
            this.プログラム右に移動ToolStripMenuItem.Size = new System.Drawing.Size(229, 22);
            this.プログラム右に移動ToolStripMenuItem.Text = "1プログラム右に移動";
            this.プログラム右に移動ToolStripMenuItem.Click += new System.EventHandler(this.programPlus_Click);
            // 
            // プログラム左に移動ToolStripMenuItem
            // 
            this.プログラム左に移動ToolStripMenuItem.Name = "プログラム左に移動ToolStripMenuItem";
            this.プログラム左に移動ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.プログラム左に移動ToolStripMenuItem.Size = new System.Drawing.Size(229, 22);
            this.プログラム左に移動ToolStripMenuItem.Text = "1プログラム左に移動";
            this.プログラム左に移動ToolStripMenuItem.Click += new System.EventHandler(this.programMinus_Click);
            // 
            // DataSetEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 502);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.programMinus);
            this.Controls.Add(this.programPlus);
            this.Controls.Add(this.Minus);
            this.Controls.Add(this.Plus);
            this.Controls.Add(this.translateText);
            this.Controls.Add(this.programText);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.referenceIndex);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "DataSetEditor";
            this.Text = "DataSetEditer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox referenceIndex;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox programText;
        private System.Windows.Forms.RichTextBox translateText;
        private System.Windows.Forms.Button Plus;
        private System.Windows.Forms.Button Minus;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Save;
        private System.Windows.Forms.Button programPlus;
        private System.Windows.Forms.Button programMinus;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem PageRightToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ページ左に移動ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem プログラム右に移動ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem プログラム左に移動ToolStripMenuItem;
    }
}