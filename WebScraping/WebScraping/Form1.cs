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
using System.Net;

namespace WebScraping
{
    public partial class Form1 : Form
    {
        public bool _isCSV = false;

        public string _csvText;

        public PerfomanceMode _mode = PerfomanceMode.Test;

        ExclusionProgress form2;
        DataSetEditor _datasetEditor;

        [System.Runtime.InteropServices.DllImport("kernel32.dll")]
        private static extern bool AllocConsole();
        public Form1()
        {
            InitializeComponent();
            AllocConsole();

            _URLText.Text = "https://qiita.com/atsushi33/items/beb0685f5b967613f2e5";
            this.Text = "Pagescraper  < TestMode >";

            form2 = new ExclusionProgress();
            // _datasetEditor = new DataSetEditor();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {

            form2.Dispose();

        }


        private void _StartBtn_Click(object sender, EventArgs e)
        {

            //取得中UIを表示 -----------------------------------------
            labelView.Visible = true;
            labelView.Text = "取得中";
            labelView.BringToFront();
            labelView.Update();

            //------------------------------------------------------
            PageScraper scraper = new PageScraper();

            string html = "", program = "", sentence = "", title = "";

            if (_isCSV)
            {

                string[] urls = CSVReader.Read(_URLText.Text);

                foreach (string url in urls)
                {
                    html = scraper.GetHTML(url);
                    program += scraper.GetCode(html);
                    sentence += scraper.GetSentence(html);
                    title += scraper.GetTitle(html);
                }
                _ProgramText.Text = program;
                SentenceText.Text = sentence;
                _TitleText.Text = title;
            }
            else
            {

                //URLの取得
                string url = _URLText.Text;

                //htmlの取得と描画
                html = scraper.GetHTML(url);
                //_HTMLText.Text = html;

                program = scraper.GetCode(html);
                sentence = scraper.GetSentence(html);

                _ProgramText.Text = program;
                SentenceText.Text = sentence;

                //htmlからタイトルを取得して描画
                title = scraper.GetTitle(html);
                _TitleText.Text = title;
            }



            labelView.Visible = false;
            if (_mode == PerfomanceMode.Test)
            {
                MessageBox.Show("デバッグ中です", "デバッグ中", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //MessageBox.Show(program ==""  ? "空っぽ" : "じゃない","ss", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (_mode == PerfomanceMode.Seperate)
            {

                int count = WebScraping.Properties.Settings.Default._FileCount;
                string filename = String.Format("_{0:0000}", count);

                using (System.IO.StreamWriter sr = new System.IO.StreamWriter(setting.Output_Path + filename + ".csv"))
                {
                    sr.WriteLine("＜説明文を含む文章＞");
                    sr.WriteLine(sentence);

                }
                using (System.IO.StreamWriter sr = new System.IO.StreamWriter(setting.Output_Path + filename + ".csv"))
                {

                    sr.WriteLine("＜プログラム＞");
                    sr.WriteLine(program);
                }
                WebScraping.Properties.Settings.Default._FileCount++;
            }
            else if (_mode == PerfomanceMode.Dataset)
            {

            }

        }

        // 参照ボタン押したときの挙動
        private void reference_Click(object sender, EventArgs e)
        {
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                _URLText.Text = openFile.FileName;
            }

        }


        #region MenuButton Event
        private void ReadURL_Click(object sender, EventArgs e)
        {
            _isCSV = false;
            label1.Text = "URLモード";
            reference.Visible = false;
        }

        private void ReadCSV_Click(object sender, EventArgs e)
        {
            _isCSV = true;
            label1.Text = "CSVモード";
            reference.Visible = true;
        }



        #endregion

        #region SwitchPlatform Event
        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _mode = PerfomanceMode.Test;
            this.Text = "Pagescraper  < TestMode >";
        }

        private void separateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _mode = PerfomanceMode.Seperate;
            this.Text = "Pagescraper  < SeparateMode >";

        }

        private void datasetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _mode = PerfomanceMode.Dataset;
            this.Text = "Pagescraper  < DatasetMode >";
        }
        #endregion


        #region Preprosession
        private void exclusionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PageScraper scraper = new PageScraper();

            if (_URLText.Text == "")
                MessageBox.Show("URLを入力してください");
            else
            {
                //CSVモード
                if (_isCSV)
                {
                    //URLの読み込み
                    string[] urls = CSVReader.Read(_URLText.Text);

                    //プログレスバーウィンドウの表示
                    form2.progressBar1.Minimum = 0;
                    form2.progressBar1.Maximum = urls.Length;
                    form2.Text = "Exclusion";
                    form2.Show();

                    //プログラムと本文のいずれかが欠けてたら省く
                    List<string> after = new List<string>();
                    foreach (string url in urls)
                    {
                        if (url == "") break;

                        form2.label1.Text = form2.progressBar1.Value++.ToString() + " / " + urls.Length.ToString();
                        form2.label1.Update();
                        string tmp_html = scraper.GetHTML(url);
                        string tmp_code = scraper.GetCode(tmp_html);
                        string tmp_sentence = scraper.GetSentence(tmp_html);

                        if (tmp_code != "" && tmp_sentence != "")
                        {
                            after.Add(url + "\n");
                        }
                    }
                    form2.Close();
                    form2.progressBar1.Value = 0;
                    string tmp_url = _URLText.Text.Replace(".csv", "");

                    tmp_url += "_1.csv";

                    using (StreamWriter sr = new StreamWriter(tmp_url))
                    {
                        foreach (string s in after)
                        {
                            sr.Write(s);
                        }
                    }

                    MessageBox.Show("完了しました");

                }
                else
                {
                    MessageBox.Show("CSVモードでのみ可能です \n [Switch Performance] → [CSV]よりCSVモードに変更して下さい");

                }
            }

        }

        private void GetSourceTargetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PageScraper scraper = new PageScraper();

            string sentence = "";
            string folder_path = "";
            string save_path = "";


            saveFileDialog1.Filter = "テキストファイル (*.txt) |*.txt |CSVファイル(*.csv)|*.csv |すべてのファイル(*.*) | *.*";
            saveFileDialog1.FilterIndex = 0;



            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {
                folder_path = folderBrowser.SelectedPath;
            }
            else return;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                save_path = saveFileDialog1.FileName;
            }
            else return;

            string[] htmls = Directory.GetFiles(folder_path, "*", SearchOption.TopDirectoryOnly);
            MessageBox.Show(htmls.Length.ToString());
            form2.progressBar1.Minimum = 0;
            form2.progressBar1.Maximum = htmls.Length;
            form2.Text = "GetAllSentence";
            form2.Show();

            foreach (string html in htmls)
            {
                form2.label1.Text = form2.progressBar1.Value++.ToString() + " / " + htmls.Length.ToString();
                form2.label1.Update();
                sentence += scraper.GetSentence(File.ReadAllText(html));
            }

            using (StreamWriter sw = new StreamWriter(save_path))
            {
                sw.Write(sentence);
            }

            form2.Close();
            form2.progressBar1.Value = 0;
            MessageBox.Show("完了しました");

        }


        WebClient wc = new WebClient();
        private void downloadHTMLSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string urlfile_path = "";
            string save_path = @"C:\Users\konolab\Desktop\Research\url_Scraping\qiita\html2\";
            int count = 0;

            if (openFile.ShowDialog() == DialogResult.OK)
            {
                urlfile_path = openFile.FileName;
            }
            else return;


            var data = CSVReader.Read(urlfile_path);


            foreach (var d in data)
            {
                try
                {
                    wc.DownloadFile(d, save_path + "html_" + (++count).ToString() + ".html");
                }
                catch (Exception)
                {

                }

            }
        }

        /*private void GetSourceTargetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PageScraper scraper = new PageScraper();

            string sentence = "";

            if(_URLText.Text == "")
            {
                MessageBox.Show("URLを入力してください");

            }
            else
            {
                if (_isCSV)
                {
                    string save_path = "";
                    Stream stream;
                    saveFileDialog1.Filter = "テキストファイル (*.txt) |*.txt |CSVファイル(*.csv)|*.csv |すべてのファイル(*.*) | *.*";
                    saveFileDialog1.FilterIndex = 0;
                    saveFileDialog1.FileName = "Source_1.txt";


                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        save_path = saveFileDialog1.FileName;
                        stream = saveFileDialog1.OpenFile();
                    }
                    else
                    {
                        return;
                    }
                    string[] urls = CSVReader.Read(_URLText.Text);


                    form2.progressBar1.Minimum = 0;
                    form2.progressBar1.Maximum = urls.Length;
                    form2.Text = "GetAllSentence";
                    form2.Show();
                    foreach (string url in urls)
                    {
                        form2.label1.Text = form2.progressBar1.Value++.ToString() + " / " + urls.Length.ToString();
                        form2.label1.Update();
                        string tmp_html = scraper.GetHTML(url);
                        string tmp_s = scraper.GetSentence(tmp_html);
                        sentence += tmp_s;


                    }
                    form2.Close();
                    form2.progressBar1.Value = 0;
                    using (StreamWriter sw = new StreamWriter(save_path))
                    {
                        try
                        {
                            sw.Write(sentence);
                        }
                        catch (Exception exeption)
                        {
                            MessageBox.Show(exeption.Message);
                        }


                    }
                    MessageBox.Show("完了しました");
                }
                else
                    MessageBox.Show("CSVモードでのみ可能です \n [Switch Performance] → [CSV]よりCSVモードに変更して下さい");
            }
        }*/
        #endregion

        private void seperateProgramsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string[] htmls = System.IO.Directory.GetFiles(@"C:\Users\konolab\Desktop\Research\url_Scraping\qiita\html", "*", SearchOption.AllDirectories);
            int count = 0;
            PageScraper scraper = new PageScraper();
            form2.progressBar1.Minimum = 0;
            form2.progressBar1.Maximum = htmls.Length;
            form2.Text = "Creating...";
            form2.Show();
            foreach (var h in htmls)
            {

                var html = File.ReadAllText(h);
                var programs = scraper.GetCode(html);
                var title = scraper.GetTitle(html);
                var sentence = scraper.GetSentence(html);

                if (programs == "") continue;
                var code = programs.Split(new string[] { ",,," }, StringSplitOptions.RemoveEmptyEntries);

                //title = title.Replace("\\", "").Replace("/", "").Replace(":", "").Replace("*", "").Replace("?", "").Replace("\"", "").Replace("<", "").Replace(">", "").Replace("|", "").Replace(".","").Trim();
                string tmp_path = @"C:\Users\konolab\Desktop\Research\DATA\" + String.Format("html_{0:0000}", count++);

                Directory.CreateDirectory(tmp_path);
                using (StreamWriter sw = new StreamWriter(tmp_path + "\\HTML.html"))
                {
                    sw.WriteLine(html);
                }

                try
                {
                    for (int i = 0; i < code.Length - 1; i++)
                    {
                        //プログラムごとに書き出し
                        using (StreamWriter sw = new StreamWriter(tmp_path + "\\program" + String.Format("_{0:00}", i) + ".txt"))
                        {
                            sw.WriteLine(code[i]);
                        }
                    }
                    using (StreamWriter sw = new StreamWriter(tmp_path + "\\sentence.txt"))
                    {
                        sw.WriteLine(sentence);
                    }
                }
                catch { }
                form2.label1.Text = form2.progressBar1.Value++.ToString() + " / " + htmls.Length.ToString();
                form2.label1.Update();
            }

            form2.progressBar1.Value = 0;

            form2.Close();
        }

        private void dataSetEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenDataSetEditor();
        }
        private void OpenDataSetEditor()
        {
            _datasetEditor = new DataSetEditor();
            _datasetEditor.Show();
        }

        private void commentOutputToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string _basePath = @"C:\Users\konolab\Desktop\Research\DATA";
            string _DataSetPath = @"C:\Users\konolab\Desktop\Research\pro-jpn1.txt";
            var dirs = System.IO.Directory.GetDirectories(_basePath, "*", SearchOption.TopDirectoryOnly);
            PageScraper scraper = new PageScraper(); 

            form2.progressBar1.Minimum = 0;
            form2.progressBar1.Maximum = dirs.Length;
            form2.Text = "Creating...";
            form2.Show();

            using (StreamWriter sw = new StreamWriter(_DataSetPath))
            {
                for (int i = 0; i < dirs.Length; i++)
                {
                    var files = System.IO.Directory.GetFiles( dirs[i]);

                    string program = scraper.GetCode(scraper.GetHTML(files[0]));
                    string com_pro = GetCommentProgram( program);

                    if (com_pro != "")
                        sw.WriteLine(com_pro);
                    
                    form2.label1.Text = form2.progressBar1.Value++.ToString() + " / " + dirs.Length.ToString();
                    form2.label1.Update();
                }
            }

            form2.progressBar1.Value = 0;
            MessageBox.Show("完了しました");
            form2.Close();
        }
        //コメントとその次の行のプログラムを抜き出す
        private string GetCommentProgram(string program)
        { 
            string result = "";
            bool outflag = false;
            if (program.Contains("//"))
            {
                string[] tmp_split = program.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
                foreach(var s  in tmp_split)
                {
                    if (s.Contains("///")) continue;
                    if (outflag) { result += s.Trim() + Environment.NewLine; outflag = false; }
                    if (s.Contains("//") && IsJapanese(s)) { result += s.Trim() + Environment.NewLine ;  outflag = true; }
                } 
            }
            return result;
        }
        private bool IsJapanese(string text)
        {
            var isJapanese = System.Text.RegularExpressions.Regex.IsMatch(text, @"[\p{IsHiragana}\p{IsKatakana}\p{IsCJKUnifiedIdeographs}]+");
            return isJapanese;
        }
    }

    public enum PerfomanceMode
    {
        Test,
        Seperate,
        Dataset,
    }


}