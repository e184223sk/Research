namespace WebScraping
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this._URLText = new System.Windows.Forms.TextBox();
            this._StartBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this._TitleText = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.labelView = new System.Windows.Forms.Label();
            this._ProgramText = new System.Windows.Forms.RichTextBox();
            this.Sentence = new System.Windows.Forms.Label();
            this.SentenceText = new System.Windows.Forms.RichTextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ReadURL = new System.Windows.Forms.ToolStripMenuItem();
            this.ReadCSV = new System.Windows.Forms.ToolStripMenuItem();
            this.folderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.reference = new System.Windows.Forms.Button();
            this.openFile = new System.Windows.Forms.OpenFileDialog();
            this.switchPerfomanceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.separateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.datasetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.label1.Location = new System.Drawing.Point(16, 38);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "URL";
            // 
            // _URLText
            // 
            this._URLText.Location = new System.Drawing.Point(20, 61);
            this._URLText.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this._URLText.Name = "_URLText";
            this._URLText.Size = new System.Drawing.Size(800, 22);
            this._URLText.TabIndex = 1;
            // 
            // _StartBtn
            // 
            this._StartBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this._StartBtn.Location = new System.Drawing.Point(913, 125);
            this._StartBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this._StartBtn.Name = "_StartBtn";
            this._StartBtn.Size = new System.Drawing.Size(136, 41);
            this._StartBtn.TabIndex = 2;
            this._StartBtn.Text = "抽出！";
            this._StartBtn.UseVisualStyleBackColor = true;
            this._StartBtn.Click += new System.EventHandler(this._StartBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.label2.Location = new System.Drawing.Point(31, 208);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Title";
            // 
            // _TitleText
            // 
            this._TitleText.Location = new System.Drawing.Point(16, 231);
            this._TitleText.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this._TitleText.Name = "_TitleText";
            this._TitleText.Size = new System.Drawing.Size(1033, 22);
            this._TitleText.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.label3.Location = new System.Drawing.Point(16, 272);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Program";
            // 
            // labelView
            // 
            this.labelView.AutoSize = true;
            this.labelView.Font = new System.Drawing.Font("MS UI Gothic", 36F);
            this.labelView.Location = new System.Drawing.Point(25, 106);
            this.labelView.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelView.Name = "labelView";
            this.labelView.Size = new System.Drawing.Size(133, 60);
            this.labelView.TabIndex = 0;
            this.labelView.Text = "URL";
            // 
            // _ProgramText
            // 
            this._ProgramText.Location = new System.Drawing.Point(16, 308);
            this._ProgramText.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this._ProgramText.Name = "_ProgramText";
            this._ProgramText.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this._ProgramText.Size = new System.Drawing.Size(463, 395);
            this._ProgramText.TabIndex = 3;
            this._ProgramText.Text = "";
            // 
            // Sentence
            // 
            this.Sentence.AutoSize = true;
            this.Sentence.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.Sentence.Location = new System.Drawing.Point(548, 272);
            this.Sentence.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Sentence.Name = "Sentence";
            this.Sentence.Size = new System.Drawing.Size(88, 20);
            this.Sentence.TabIndex = 0;
            this.Sentence.Text = "Sentence";
            // 
            // SentenceText
            // 
            this.SentenceText.Location = new System.Drawing.Point(548, 308);
            this.SentenceText.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.SentenceText.Name = "SentenceText";
            this.SentenceText.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.SentenceText.Size = new System.Drawing.Size(463, 395);
            this.SentenceText.TabIndex = 3;
            this.SentenceText.Text = "";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem,
            this.switchPerfomanceToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1067, 28);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ReadURL,
            this.ReadCSV});
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(58, 24);
            this.menuToolStripMenuItem.Text = "Menu";
            // 
            // ReadURL
            // 
            this.ReadURL.Name = "ReadURL";
            this.ReadURL.Size = new System.Drawing.Size(166, 26);
            this.ReadURL.Text = "URL読み込み";
            this.ReadURL.Click += new System.EventHandler(this.ReadURL_Click);
            // 
            // ReadCSV
            // 
            this.ReadCSV.Name = "ReadCSV";
            this.ReadCSV.Size = new System.Drawing.Size(166, 26);
            this.ReadCSV.Text = "CSV読み込み";
            this.ReadCSV.Click += new System.EventHandler(this.ReadCSV_Click);
            // 
            // reference
            // 
            this.reference.Location = new System.Drawing.Point(840, 61);
            this.reference.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.reference.Name = "reference";
            this.reference.Size = new System.Drawing.Size(107, 22);
            this.reference.TabIndex = 5;
            this.reference.Text = "参照";
            this.reference.UseVisualStyleBackColor = true;
            this.reference.Click += new System.EventHandler(this.reference_Click);
            // 
            // openFile
            // 
            this.openFile.FileName = "openFile";
            // 
            // switchPerfomanceToolStripMenuItem
            // 
            this.switchPerfomanceToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.testToolStripMenuItem,
            this.separateToolStripMenuItem,
            this.datasetToolStripMenuItem});
            this.switchPerfomanceToolStripMenuItem.Name = "switchPerfomanceToolStripMenuItem";
            this.switchPerfomanceToolStripMenuItem.Size = new System.Drawing.Size(143, 24);
            this.switchPerfomanceToolStripMenuItem.Text = "SwitchPerfomance";
            // 
            // testToolStripMenuItem
            // 
            this.testToolStripMenuItem.Name = "testToolStripMenuItem";
            this.testToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.testToolStripMenuItem.Text = "Test";
            this.testToolStripMenuItem.Click += new System.EventHandler(this.testToolStripMenuItem_Click);
            // 
            // separateToolStripMenuItem
            // 
            this.separateToolStripMenuItem.Name = "separateToolStripMenuItem";
            this.separateToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.separateToolStripMenuItem.Text = "Separate";
            this.separateToolStripMenuItem.Click += new System.EventHandler(this.separateToolStripMenuItem_Click);
            // 
            // datasetToolStripMenuItem
            // 
            this.datasetToolStripMenuItem.Name = "datasetToolStripMenuItem";
            this.datasetToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.datasetToolStripMenuItem.Text = "Dataset";
            this.datasetToolStripMenuItem.Click += new System.EventHandler(this.datasetToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 718);
            this.Controls.Add(this.reference);
            this.Controls.Add(this.SentenceText);
            this.Controls.Add(this._ProgramText);
            this.Controls.Add(this._StartBtn);
            this.Controls.Add(this.Sentence);
            this.Controls.Add(this._TitleText);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this._URLText);
            this.Controls.Add(this.labelView);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "PageScraper";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox _URLText;
        private System.Windows.Forms.Button _StartBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox _TitleText;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelView;
        private System.Windows.Forms.RichTextBox _ProgramText;
        private System.Windows.Forms.Label Sentence;
        private System.Windows.Forms.RichTextBox SentenceText;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ReadURL;
        private System.Windows.Forms.ToolStripMenuItem ReadCSV;
        private System.Windows.Forms.FolderBrowserDialog folderBrowser;
        private System.Windows.Forms.Button reference;
        private System.Windows.Forms.OpenFileDialog openFile;
        private System.Windows.Forms.ToolStripMenuItem switchPerfomanceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem separateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem datasetToolStripMenuItem;
    }
}

