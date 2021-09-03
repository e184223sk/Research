using System.Net;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System;
namespace WebScraper
{
    public class PageScraper
    {

        public string GetHTML(string url)
        {
            
            //URLからRequestを作成
            HttpWebRequest request = WebRequest.CreateHttp(url);
            //html格納用
            string html = "";

            //指定されたURLに対してRequestを投げてResponseを取得
            try
            {
                using (HttpWebResponse resonse = (HttpWebResponse)request.GetResponse())
                using (Stream responseStream = resonse.GetResponseStream())
                //取得した文字列をUTF-8でエンコード
                using (StreamReader reader = new StreamReader(responseStream, Encoding.UTF8))
                {
                    //htmlを格納
                    html = reader.ReadToEnd();
                }
            }
            catch(Exception e)
            {
                return "";
            }

            return html;
        }


        public string GetTitle(string html)
        {
            //正規表現
            //大文字小文字区別なし　　　　    RegexOptions.IgnoreCase
            //「.」を改行にも適応する設定     RegexOptions.SingleLine
            Regex regex = new Regex(@"<title>(?<title>.*?)</title>", RegexOptions.IgnoreCase | RegexOptions.Singleline);

            //html文字内から条件にマッチしたデータを抽出
            var Matchtitle = regex.Match(html);

            //条件にマッチした部分からKey（"タイトル部分"）にマッチした値を抜き取る
            return Matchtitle.Groups["title"].Value;
        }

        /// <summary>
        /// web上の存在するすべてのプログラムを取得する プログラムとして成り立っていないものは除外する
        /// </summary>
        /// <param name="html"></param>
        /// <returns>カンマ区切りの文字列</returns>
        public string GetCode(string html)
        {

            //見つかったすべての部分文字列
            string Codes = "";
            int Counter_div = 0;
            int Counter_slashdiv = 0;

            int startIndex = 0, lastIndex = 0;
            string[] tmp_html;


            //C#コードを囲むdiv。　種類が　c# C# csharpと3種類あるため　含有チェックとタグを消す際に３分岐する必要あり　enumやね
            const string target = "<div class=\"code-frame\" data-lang=\"C#\">";
            const string target2 = "<div class=\"code-frame\" data-lang=\"csharp\">";

            

            while (html.Contains(target) || html.Contains(target2))
            {
                Counter_div = 0;
                Counter_slashdiv = 0;
                startIndex = 0;
                lastIndex = 0;

                if (html.Contains(target))
                    startIndex = html.IndexOf(target);
                else
                    startIndex = html.IndexOf(target2);


                string tmp_h = html.Substring(startIndex, html.Length - startIndex - 1);
                tmp_html =tmp_h.Split('\n');

                //対応する</div>のindexを取得
                foreach (string s in tmp_html)
                {
                    if (Counter_div == Counter_slashdiv)
                    {
                        if(s.Contains("<div") && s.Contains("</div>"))
                        {
                            //tmp_h = tmp_h.Remove(tmp_h.IndexOf(s), s.Length);
                            Counter_div++;
                            Counter_slashdiv++; 

                        }
                        else if (s.Contains("<div"))
                        {
                           // tmp_h = tmp_h.Remove(tmp_h.IndexOf(s), s.Length);
                            Counter_div++;
                        }
                        else if (s.Contains("</div>"))
                        {
                            lastIndex = tmp_h.IndexOf("</div>");
                        }
                    }
                    else
                    {
                        if (s.Contains("</div>"))
                        {
                            //tmp_h = tmp_h.Remove(tmp_h.IndexOf(s), s.Length);
                            Counter_slashdiv++;
                        }
                    }
                }
                string CsharpCode =  tmp_h.Substring(0, lastIndex);
                try
                {

                    html = html.Remove(startIndex, target.Length);
                    html = html.Remove(lastIndex - "</div>".Length, "</div>".Length);
                }
                catch(Exception e)
                {
                    //System.Windows.Forms.MessageBox.Show(e.ToString());
                    continue;
                }
                
                Regex regex = new Regex("<code>(?<Code>.*?)</code>", RegexOptions.IgnoreCase | RegexOptions.Singleline);


                //コードの抽出
                var match = regex.Match(CsharpCode);
                var group = match.Groups["Code"];


                string tmp_s = IsProgram(group.Value) ? group.Value : "";

                Codes += AllTagsDelete(tmp_s) + "," + System.Environment.NewLine;
                //MessageBox.Show(Regex.Replace(group.Value,"<[^>]*?>",""), "タグ消しテキスト", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //次にマッチする文字列があれば追記していく
                /* do
                 {
                     match = match.NextMatch();
                     Codes += AllTagsDelete(match.Groups["Code"].Value) + "," + System.Environment.NewLine;
                 }
                 while (match.Success);
                 */
            }

            return Codes;

        }

        //ソースコードの周りには<div cakss ="code-frame" data-lang="C#"> プログラム　</>　があることが分かった。
        //これがあればC#のソースコードがある
        //しかし単純にこの中を取ろうと<div>～</div>をやると別の</div>に引っかかる
        //同じインデントにある<div>を探すためには
        //内側にある<div>と</div>を数えてその数が同じになった時、次に出てくる</div>を探す


        public string GetSentence(string html)
        {
            Regex regex = new Regex("<p>(?<Sentence>.*?)</p>", RegexOptions.IgnoreCase | RegexOptions.Singleline);

            string sentences = "";
            var match = regex.Match(html);
            var group = match.Groups["Sentence"];
            sentences = AllTagsDelete(group.Value);
            sentences += "," + System.Environment.NewLine;
            do
            {
                match = match.NextMatch();
                sentences += AllTagsDelete(match.Groups["Sentence"].Value) + "," + System.Environment.NewLine;
            }
            while (match.Success);

            return sentences;
        }

        public bool IsProgram(string text)
        {
            Regex IsJapanese = new Regex(@"[\p{IsHiragana}]\p{IsKatakana}\p{IsCJKUnifiedIdeographs}]+");
            bool value = true;

            string[] lines = text.Split(System.Environment.NewLine.ToCharArray());
            for (int i = 0; i < lines.Length; i++)
            {
                if (Regex.IsMatch(lines[i], @"[\p{IsHiragana}\p{IsKatakana}\p{IsCJKUnifiedIdeographs}]+"))
                {
                    if (!lines[i].Contains("//") && !lines[i].Contains("\""))
                    {
                       // MessageBox.Show(lines[i], "IsJapanese", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        value = false;
                    }
                }
            }
            return value;
        }

        public string AllTagsDelete(string text)
        {
            return Regex.Replace(text, "<[^>]*?>", "");
        }

        public int HowManyTags(string html, string tag)
        {
            int count = 0;

            int index = html.IndexOf(tag, 0);
            while (index != -1)
            {
                count++;
                index = html.IndexOf(tag, index + tag.Length);
            }

            return count;
        }

    }
}