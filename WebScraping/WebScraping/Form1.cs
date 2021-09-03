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
    public partial class Form1 : Form
    {
        public bool _isCSV  =false;

        public string _csvText;

        public PerfomanceMode _mode = PerfomanceMode.Test;

        ExclusionProgress form2;


        [System.Runtime.InteropServices.DllImport("kernel32.dll")]
        private static extern bool AllocConsole();
        public Form1()
        {
            InitializeComponent();
            AllocConsole();

            _URLText.Text = "https://qiita.com/atsushi33/items/beb0685f5b967613f2e5";
            this.Text = "Pagescraper  < TestMode >";

            form2 = new ExclusionProgress();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {

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

            string html ="", program ="", sentence = "" , title ="";

            if (_isCSV)
            {

                string[] urls = CSVReader.Read(_URLText.Text);

                foreach(string url in urls)
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
            if(_mode == PerfomanceMode.Test)
            {
                MessageBox.Show("デバッグ中です", "デバッグ中", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //MessageBox.Show(program ==""  ? "空っぽ" : "じゃない","ss", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if(_mode == PerfomanceMode.Seperate)
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
            else if(_mode == PerfomanceMode.Dataset)
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


        private void exclusionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PageScraper scraper = new PageScraper();
            
            if (_URLText.Text == null)
                MessageBox.Show("URLを入力してください");
            else
            {
                //CSVモード
                if (_isCSV)
                {

                    
                    string[] urls = CSVReader.Read(_URLText.Text);

                    form2.progressBar1.Minimum = 0;
                    form2.progressBar1.Maximum = urls.Length;
                    form2.Show();


                    List<string> after = new List<string>();
                    foreach(string url in urls)
                    {
                        if (url == "") break;

                        form2.label1.Text = form2.progressBar1.Value++.ToString()+" / " + urls.Length.ToString();
                        form2.label1.Update();
                        string tmp_html = scraper.GetHTML(url);
                        string tmp_code = scraper.GetCode(tmp_html);
                        string tmp_sentence = scraper.GetSentence(tmp_html);

                        if(tmp_code !="" && tmp_sentence != "")
                        {
                            after.Add(url);
                        }
                    }

                    //System.Threading.Thread.Sleep(5000);
                    form2.Close();
                    form2.Dispose();
                    string tmp_url = _URLText.Text.Replace(".csv", "");

                    tmp_url += "_1.csv";

                    using (StreamWriter sr = new StreamWriter(tmp_url))
                    {
                        foreach(string s in after)
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

    }
}
public enum PerfomanceMode
{
    Test,
    Seperate,
    Dataset,
}
