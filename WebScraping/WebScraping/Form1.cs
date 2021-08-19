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

        [System.Runtime.InteropServices.DllImport("kernel32.dll")]
        private static extern bool AllocConsole();
        public Form1()
        {
            InitializeComponent();
            AllocConsole();

            _URLText.Text = "https://qiita.com/atsushi33/items/beb0685f5b967613f2e5";
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

            //スクレイパーを作る
            SampleScraping scraper = new SampleScraping();

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
#if DEBUG

            MessageBox.Show("デバッグ中です", "デバッグ中", MessageBoxButtons.OK, MessageBoxIcon.Information);

#else
            int count = Properties.Settings.Default._FileCount;
            string filename = String.Format("_{0:0000}", count);

            using (System.IO.StreamWriter sr = new System.IO.StreamWriter(@"C:\Users\konolab\Desktop\Research\csv\Explain" +filename + ".csv"))
            {
                sr.WriteLine("＜説明文を含む文章＞");
                sr.WriteLine(sentence);
            
            }
            using (System.IO.StreamWriter sr = new System.IO.StreamWriter(@"C:\Users\konolab\Desktop\Research\csv\Program" +filename + ".csv"))
            {

                sr.WriteLine("＜プログラム＞");
                sr.WriteLine(program);
            }
            Properties.Settings.Default._FileCount++;
#endif
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
            label1.Text = "CSVモード";
            reference.Visible = true;
        }

        private void ReadCSV_Click(object sender, EventArgs e)
        {
            _isCSV = true;
            label1.Text = "URLモード";
            reference.Visible = false;
        }

#endregion
    }
}
