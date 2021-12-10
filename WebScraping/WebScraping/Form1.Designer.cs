namespace WebScraping{
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
            this.switchPerfomanceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.extractModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.separateToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.datasetToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.readModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uRLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripComboBox1 = new System.Windows.Forms.ToolStripMenuItem();
            this.preprocessingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exclusionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.downloadHTMLSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.downloadAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.getSourceTargetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.seperateProgramsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataSetEditorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.folderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.reference = new System.Windows.Forms.Button();
            this.openFile = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.commentOutputToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.label1.Location = new System.Drawing.Point(12, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "URL";
            // 
            // _URLText
            // 
            this._URLText.Location = new System.Drawing.Point(15, 49);
            this._URLText.Name = "_URLText";
            this._URLText.Size = new System.Drawing.Size(601, 19);
            this._URLText.TabIndex = 1;
            // 
            // _StartBtn
            // 
            this._StartBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this._StartBtn.Location = new System.Drawing.Point(685, 100);
            this._StartBtn.Name = "_StartBtn";
            this._StartBtn.Size = new System.Drawing.Size(102, 33);
            this._StartBtn.TabIndex = 2;
            this._StartBtn.Text = "抽出！";
            this._StartBtn.UseVisualStyleBackColor = true;
            this._StartBtn.Click += new System.EventHandler(this._StartBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.label2.Location = new System.Drawing.Point(23, 166);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "Title";
            // 
            // _TitleText
            // 
            this._TitleText.Location = new System.Drawing.Point(12, 185);
            this._TitleText.Name = "_TitleText";
            this._TitleText.Size = new System.Drawing.Size(776, 19);
            this._TitleText.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.label3.Location = new System.Drawing.Point(12, 218);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 16);
            this.label3.TabIndex = 0;
            this.label3.Text = "Program";
            // 
            // labelView
            // 
            this.labelView.AutoSize = true;
            this.labelView.Font = new System.Drawing.Font("MS UI Gothic", 36F);
            this.labelView.Location = new System.Drawing.Point(19, 85);
            this.labelView.Name = "labelView";
            this.labelView.Size = new System.Drawing.Size(107, 48);
            this.labelView.TabIndex = 0;
            this.labelView.Text = "URL";
            // 
            // _ProgramText
            // 
            this._ProgramText.Location = new System.Drawing.Point(12, 246);
            this._ProgramText.Name = "_ProgramText";
            this._ProgramText.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this._ProgramText.Size = new System.Drawing.Size(348, 317);
            this._ProgramText.TabIndex = 3;
            this._ProgramText.Text = "";
            // 
            // Sentence
            // 
            this.Sentence.AutoSize = true;
            this.Sentence.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.Sentence.Location = new System.Drawing.Point(411, 218);
            this.Sentence.Name = "Sentence";
            this.Sentence.Size = new System.Drawing.Size(72, 16);
            this.Sentence.TabIndex = 0;
            this.Sentence.Text = "Sentence";
            // 
            // SentenceText
            // 
            this.SentenceText.Location = new System.Drawing.Point(411, 246);
            this.SentenceText.Name = "SentenceText";
            this.SentenceText.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.SentenceText.Size = new System.Drawing.Size(348, 317);
            this.SentenceText.TabIndex = 3;
            this.SentenceText.Text = "";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem,
            this.switchPerfomanceToolStripMenuItem,
            this.preprocessingToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.menuToolStripMenuItem.Text = "Menu";
            // 
            // switchPerfomanceToolStripMenuItem
            // 
            this.switchPerfomanceToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.extractModeToolStripMenuItem,
            this.readModeToolStripMenuItem});
            this.switchPerfomanceToolStripMenuItem.Name = "switchPerfomanceToolStripMenuItem";
            this.switchPerfomanceToolStripMenuItem.Size = new System.Drawing.Size(117, 20);
            this.switchPerfomanceToolStripMenuItem.Text = "SwitchPerfomance";
            // 
            // extractModeToolStripMenuItem
            // 
            this.extractModeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.testToolStripMenuItem1,
            this.separateToolStripMenuItem1,
            this.datasetToolStripMenuItem1});
            this.extractModeToolStripMenuItem.Name = "extractModeToolStripMenuItem";
            this.extractModeToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.extractModeToolStripMenuItem.Text = "ExtractMode";
            // 
            // testToolStripMenuItem1
            // 
            this.testToolStripMenuItem1.Name = "testToolStripMenuItem1";
            this.testToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.testToolStripMenuItem1.Text = "Debug (Single Only)";
            this.testToolStripMenuItem1.Click += new System.EventHandler(this.testToolStripMenuItem_Click);
            // 
            // separateToolStripMenuItem1
            // 
            this.separateToolStripMenuItem1.Name = "separateToolStripMenuItem1";
            this.separateToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.separateToolStripMenuItem1.Text = "Separate";
            this.separateToolStripMenuItem1.Click += new System.EventHandler(this.separateToolStripMenuItem_Click);
            // 
            // datasetToolStripMenuItem1
            // 
            this.datasetToolStripMenuItem1.Name = "datasetToolStripMenuItem1";
            this.datasetToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.datasetToolStripMenuItem1.Text = "Dataset (Multi Only)";
            // 
            // readModeToolStripMenuItem
            // 
            this.readModeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uRLToolStripMenuItem,
            this.toolStripComboBox1});
            this.readModeToolStripMenuItem.Name = "readModeToolStripMenuItem";
            this.readModeToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.readModeToolStripMenuItem.Text = "Read Mode";
            // 
            // uRLToolStripMenuItem
            // 
            this.uRLToolStripMenuItem.Name = "uRLToolStripMenuItem";
            this.uRLToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.uRLToolStripMenuItem.Text = "SinglePage (URL)";
            this.uRLToolStripMenuItem.Click += new System.EventHandler(this.ReadURL_Click);
            // 
            // toolStripComboBox1
            // 
            this.toolStripComboBox1.Name = "toolStripComboBox1";
            this.toolStripComboBox1.Size = new System.Drawing.Size(164, 22);
            this.toolStripComboBox1.Text = "MultiPages (CSV)";
            this.toolStripComboBox1.Click += new System.EventHandler(this.ReadCSV_Click);
            // 
            // preprocessingToolStripMenuItem
            // 
            this.preprocessingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exclusionToolStripMenuItem,
            this.downloadHTMLSToolStripMenuItem,
            this.dataSetEditorToolStripMenuItem,
            this.commentOutputToolStripMenuItem});
            this.preprocessingToolStripMenuItem.Name = "preprocessingToolStripMenuItem";
            this.preprocessingToolStripMenuItem.Size = new System.Drawing.Size(93, 20);
            this.preprocessingToolStripMenuItem.Text = "Preprocessing";
            // 
            // exclusionToolStripMenuItem
            // 
            this.exclusionToolStripMenuItem.Name = "exclusionToolStripMenuItem";
            this.exclusionToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.exclusionToolStripMenuItem.Text = "Delete Extra URL";
            this.exclusionToolStripMenuItem.Click += new System.EventHandler(this.exclusionToolStripMenuItem_Click);
            // 
            // downloadHTMLSToolStripMenuItem
            // 
            this.downloadHTMLSToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.downloadAsToolStripMenuItem,
            this.getSourceTargetToolStripMenuItem,
            this.seperateProgramsToolStripMenuItem});
            this.downloadHTMLSToolStripMenuItem.Name = "downloadHTMLSToolStripMenuItem";
            this.downloadHTMLSToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.downloadHTMLSToolStripMenuItem.Text = "HTMLs";
            // 
            // downloadAsToolStripMenuItem
            // 
            this.downloadAsToolStripMenuItem.Name = "downloadAsToolStripMenuItem";
            this.downloadAsToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.downloadAsToolStripMenuItem.Text = "download as...";
            this.downloadAsToolStripMenuItem.Click += new System.EventHandler(this.downloadHTMLSToolStripMenuItem_Click);
            // 
            // getSourceTargetToolStripMenuItem
            // 
            this.getSourceTargetToolStripMenuItem.Name = "getSourceTargetToolStripMenuItem";
            this.getSourceTargetToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.getSourceTargetToolStripMenuItem.Text = "GetSourceTarget";
            this.getSourceTargetToolStripMenuItem.Click += new System.EventHandler(this.GetSourceTargetToolStripMenuItem_Click);
            // 
            // seperateProgramsToolStripMenuItem
            // 
            this.seperateProgramsToolStripMenuItem.Name = "seperateProgramsToolStripMenuItem";
            this.seperateProgramsToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.seperateProgramsToolStripMenuItem.Text = "seperatePrograms";
            this.seperateProgramsToolStripMenuItem.Click += new System.EventHandler(this.seperateProgramsToolStripMenuItem_Click);
            // 
            // dataSetEditorToolStripMenuItem
            // 
            this.dataSetEditorToolStripMenuItem.Name = "dataSetEditorToolStripMenuItem";
            this.dataSetEditorToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.D)));
            this.dataSetEditorToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.dataSetEditorToolStripMenuItem.Text = "DataSetEditor";
            this.dataSetEditorToolStripMenuItem.Click += new System.EventHandler(this.dataSetEditorToolStripMenuItem_Click);
            // 
            // reference
            // 
            this.reference.Location = new System.Drawing.Point(630, 49);
            this.reference.Margin = new System.Windows.Forms.Padding(2);
            this.reference.Name = "reference";
            this.reference.Size = new System.Drawing.Size(80, 18);
            this.reference.TabIndex = 5;
            this.reference.Text = "参照";
            this.reference.UseVisualStyleBackColor = true;
            this.reference.Click += new System.EventHandler(this.reference_Click);
            // 
            // openFile
            // 
            this.openFile.FileName = "openFile";
            // 
            // commentOutputToolStripMenuItem
            // 
            this.commentOutputToolStripMenuItem.Name = "commentOutputToolStripMenuItem";
            this.commentOutputToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.commentOutputToolStripMenuItem.Text = "CommentOutput";
            this.commentOutputToolStripMenuItem.Click += new System.EventHandler(this.commentOutputToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(800, 574);
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
        private System.Windows.Forms.FolderBrowserDialog folderBrowser;
        private System.Windows.Forms.Button reference;
        private System.Windows.Forms.OpenFileDialog openFile;
        private System.Windows.Forms.ToolStripMenuItem switchPerfomanceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem preprocessingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exclusionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem extractModeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem separateToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem datasetToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem readModeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uRLToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripComboBox1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem downloadHTMLSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem downloadAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem getSourceTargetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem seperateProgramsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dataSetEditorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem commentOutputToolStripMenuItem;
    }
}

