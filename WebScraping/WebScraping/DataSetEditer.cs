using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WebScraping
{
    public partial class DataSetEditor : Form
    {
        public int _MaxCount;
        public const string _basePath = @"C:\Users\konolab\Desktop\Research\DATA";
        public const string _sentencePath = "\\sentence.txt";
        public const string _htmlPath = "\\HTML.html";
        public const string _DataSetPath = @"C:\Users\konolab\Desktop\Research\pro-jpn.txt";


        public int _nowProgramIndex = 0;
        public int _maxProgramCount = 0;
        public string[] _programs = new string[] { };

        public DataSetEditor()
        {
            InitializeComponent();
            _MaxCount = System.IO.Directory.GetDirectories(_basePath, "*", SearchOption.TopDirectoryOnly).Length - 1;
            //translateText.Text = _MaxCount.ToString();
            ChangedNowReference();
            referenceIndex.Text = String.Format("{0:0000}", Properties.Settings.Default._ReferenceCount);
        }


        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.Text.Contains("*"))
            {
                DialogResult result = MessageBox.Show("変更が保存されていません。終了しますか？",
                                                      "終了中",
                                                       MessageBoxButtons.YesNo,
                                                       MessageBoxIcon.Exclamation,
                                                       MessageBoxDefaultButton.Button2); 
                if (result == DialogResult.No)
                {
                    e.Cancel = true;
                }

            }
            this.Dispose();

        }

        #region UIEvent


        private void Minus_Click(object sender, EventArgs e)
        {
            minus();
        }
        private void minus()
        {
            if (this.Text.Contains("*"))
            {
                DialogResult result = MessageBox.Show("変更が保存されていません。終了しますか？",
                                                      "ページ移動中",
                                                       MessageBoxButtons.YesNo,
                                                       MessageBoxIcon.Exclamation,
                                                       MessageBoxDefaultButton.Button2);
                if (result == DialogResult.No)
                {
                    return;
                }

            }
            Properties.Settings.Default._ReferenceCount = (Properties.Settings.Default._ReferenceCount - 1 <= 0) ? 0 : Properties.Settings.Default._ReferenceCount - 1;
            referenceIndex.Text = String.Format("{0:0000}", Properties.Settings.Default._ReferenceCount);
            ChangedNowReference();
            Properties.Settings.Default.Save();
            translateText.Text = "";
            if (this.Text.Contains("*")) this.Text = "DataSetEditor";

        }

        private void Plus_Click(object sender, EventArgs e)
        {
            //translateText.Text = Properties.Settings.Default._ReferenceCount.ToString();
            plus();
        }
        private void plus()
        {
            if (this.Text.Contains("*"))
            {
                DialogResult result = MessageBox.Show("変更が保存されていません。終了しますか？",
                                                      "ページ移動中",
                                                       MessageBoxButtons.YesNo,
                                                       MessageBoxIcon.Exclamation,
                                                       MessageBoxDefaultButton.Button2);
                if (result == DialogResult.No)
                {
                    return;
                }

            }
            Properties.Settings.Default._ReferenceCount = (Properties.Settings.Default._ReferenceCount + 1 >= _MaxCount) ? _MaxCount : Properties.Settings.Default._ReferenceCount + 1;
            referenceIndex.Text = String.Format("{0:0000}", Properties.Settings.Default._ReferenceCount);
            ChangedNowReference();
            Properties.Settings.Default.Save();
            translateText.Text = "";
            if (this.Text.Contains("*")) this.Text = "DataSetEditor";
        }


        private void programMinus_Click(object sender, EventArgs e)
        {
            minus_pro();
        }
        private void minus_pro()
        {
            if (this.Text.Contains("*"))
            {
                DialogResult result = MessageBox.Show("変更が保存されていません。終了しますか？",
                                                      "ページ移動中",
                                                       MessageBoxButtons.YesNo,
                                                       MessageBoxIcon.Exclamation,
                                                       MessageBoxDefaultButton.Button2);
                if (result == DialogResult.No)
                {
                    return;
                }

            }
            _nowProgramIndex = (_nowProgramIndex - 1 <= 0) ? 0 : _nowProgramIndex - 1;
            programText.Text = _programs[_nowProgramIndex];
            translateText.Text = "";
            if (this.Text.Contains("*")) this.Text = "DataSetEditor";
        }

        private void programPlus_Click(object sender, EventArgs e)
        {
            plus_pro();
        }
        private void plus_pro()
        {
            if (this.Text.Contains("*"))
            {
                DialogResult result = MessageBox.Show("変更が保存されていません。終了しますか？",
                                                      "ページ移動中",
                                                       MessageBoxButtons.YesNo,
                                                       MessageBoxIcon.Exclamation,
                                                       MessageBoxDefaultButton.Button2);
                if (result == DialogResult.No)
                {
                    return;
                }

            }
            _nowProgramIndex = (_nowProgramIndex + 1 > _maxProgramCount) ? _maxProgramCount : _nowProgramIndex + 1;
            programText.Text = _programs[_nowProgramIndex];
            translateText.Text = "";
            if (this.Text.Contains("*")) this.Text = "DataSetEditor";
        }


        private void ChangedNowReference()
        {
            string nowPath = _basePath + String.Format("\\html_{0:0000}", Properties.Settings.Default._ReferenceCount);
            _programs = GetPrograms(nowPath);
            System.Diagnostics.Process.Start(@"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe", nowPath + _htmlPath);
            _nowProgramIndex = 0;
            _maxProgramCount = _programs.Length - 1;
            programText.Text = _programs[_nowProgramIndex];
        }


        private void TranslateChanged(object sender, EventArgs e)
        {
            this.Text = "DataSetEditor*";
        }

        #endregion


        private string[] GetPrograms(string path)
        {
            var alldata = GetAllData(path);
            string[] tmp = new string[alldata.Length - 2];
            int count = 0;
            for (int i = 0; i < alldata.Length; i++)
            {
                if (alldata[i].Contains("program"))
                {
                    tmp[count++] = System.IO.File.ReadAllText(alldata[i]);
                }
            }
            return tmp;

        }

        private string[] GetAllData(string path)
        {
            return System.IO.Directory.GetFiles(path);
        }

        private void AddandSave(object sender, EventArgs e)
        {
            if (this.Text.Contains("*")) this.Text = "DataSetEditor";

            using (StreamWriter sw = new StreamWriter(_DataSetPath, true,Encoding.UTF8))
            {
                string tmp_pro = programText.Text.Replace("\r", "").Replace("\n", "");
                string tmp_tra = translateText.Text.Replace("\r", "").Replace("\n", "");
                sw.WriteLine(tmp_pro);
                sw.WriteLine(tmp_tra);

            }
        }　
    }
}
