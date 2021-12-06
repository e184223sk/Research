using System.Net;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System;
namespace WebScraping
{
    public class PageScraper
    {

        #region div tag List
        //C#コードを囲むdiv。　種類が　たくさんあるため　含有チェックとタグを消す際に分岐する必要あり　enumやね
        const string _target1 = "<div class=\"code-frame\" data-lang=\"c#\">";
        const string _target2 = "<div class=\"code-frame\" data-lang=\"C#\">";
        const string _target3 = "<div class=\"code-frame\" data-lang=\"csharp\">";
        const string _target4 = "<div class=\"code-frame\" data-lang=\"Csharp\">";
        const string _target5 = "<div class=\"code-frame\" data-lang=\"cs\">";
        const string _target6 = "<div class=\"code-frame\" data-lang=\"CS\">"; //ないかもしれんが一応
        #endregion

        
        WebClient wc = new WebClient();
        public PageScraper() => wc.Encoding = Encoding.UTF8;
        ~PageScraper() => wc.Dispose();


        #region HtmlScraping
        //今は複数繰り返す時、毎回request作ってるからやばそう
        //多分WebRequestが最速 HttpClientは1ホストにつき１clientだからめっちゃ作る必要ある感じ
        //ワンチャン、一回全部のhtmlファイルを保存して次からそこにアクセスするほうが楽かも
        public string GetHTML(string url)
        {
            try
            {
                return wc.DownloadString(url);
            }
            catch (Exception)
            {
                return "";
            }
        }
        /*
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
            catch (Exception e)
            {
                return "";
            }

            return html;
        }
             */

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


        public string GetCode(string html)
        {
            //見つかったすべての部分文字列
            string Codes = "";
            int Counter_div = 0;
            int Counter_slashdiv = 0;
            int startIndex = 0, lastIndex = 0;
            string[] tmp_html;
            string CsharpCode;
            TagPattern pattern = ContainTarget(html);


            while (pattern != TagPattern.NULL)
            {

                Counter_div = 0;
                Counter_slashdiv = 0;
                lastIndex = 0;
                startIndex = SearchTarget(pattern, html);

                string tmp_h = html.Substring(startIndex, html.Length - startIndex);
                tmp_html = tmp_h.Split('\n');

                for (int i = 1; i < tmp_html.Length; i++)
                {
                    if (tmp_html[i].Contains("<div"))
                    {
                        Counter_div++;
                    }
                    if (tmp_html[i].Contains("</div>"))
                    {

                        if (Counter_div == Counter_slashdiv)
                        {
                            lastIndex = CountAllString(tmp_html, i);
                            break;
                        }
                        else
                        {
                            Counter_slashdiv++;
                        }
                    }
                }

                CsharpCode = tmp_h.Substring(0, lastIndex);
                try
                {
                    html = DeleteTarget(pattern, html);
                }
                catch (Exception)
                {

                }
                Regex regex = new Regex("<code>(?<Code>.*?)</code>", RegexOptions.IgnoreCase | RegexOptions.Singleline);

                //コードの抽出
                var match = regex.Match(CsharpCode);
                var group = match.Groups["Code"];
                string tmp_s = IsProgram(group.Value) ? group.Value : "";
                Codes += AllTagsDelete(tmp_s) + ",,," + System.Environment.NewLine;

                //ループ条件　タグがまだあるか
                pattern = ContainTarget(html);

            }

            return Codes;
        }

        /*
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

            TagPattern pattern = ContainTarget(html);
            while (pattern != TagPattern.NULL)
            {
                Counter_div = 0;
                Counter_slashdiv = 0;
                startIndex = 0;
                lastIndex = 0;
                startIndex = SearchTarget(pattern, html);
                
                string tmp_h = html.Substring(startIndex, html.Length - startIndex);
                tmp_html = tmp_h.Split('\n');

                for (int i = 1; i < tmp_html.Length; i++)
                {
                    if (tmp_html[i].Contains("<div") && tmp_html[i].Contains("</div>"))
                    {
                        Counter_div++;
                        Counter_slashdiv++;
                    }
                    else if (tmp_html[i].Contains("<div"))
                    {
                        Counter_div++;
                    }
                    else if (tmp_html[i].Contains("</div>"))
                    {

                        if (Counter_div == Counter_slashdiv)
                        {
                            lastIndex = CountAllString(tmp_html, i);
                            break;
                        }
                        else
                        {
                            Counter_slashdiv++;
                        }
                    }
                }

                string CsharpCode = tmp_h.Substring(0, lastIndex);
                try
                {
                    html = DeleteTarget(pattern, html);
                }
                catch (Exception e)
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

                //ループ条件　タグがまだあるか
                pattern = ContainTarget(html);
            }
            return Codes;
        }
        */
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


            while (match.NextMatch().Success)
            {

                match = match.NextMatch();
                sentences += AllTagsDelete(match.Groups["Sentence"].Value);
            }
            sentences += "\n\n";
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
        #endregion

        #region TagPattern Methods
        public enum TagPattern
        {
            c_hash,
            C_hash,
            csharp,
            Csharp,
            cs,
            CS,
            NULL
        }

        public int CountAllString(string[] array, int index)
        {
            int count = 0;

            for (int i = 0; i <= index; i++)
            {
                count += array[i].Length + 1;
            }
            return count;
        }

        public TagPattern ContainTarget(string text)
        {

            if (text.Contains(_target1)) return TagPattern.c_hash;
            if (text.Contains(_target2)) return TagPattern.C_hash;
            if (text.Contains(_target3)) return TagPattern.csharp;
            if (text.Contains(_target4)) return TagPattern.Csharp;
            if (text.Contains(_target5)) return TagPattern.cs;
            if (text.Contains(_target6)) return TagPattern.CS;

            return TagPattern.NULL;


        }

        public int SearchTarget(TagPattern tag, string text)
        {
            switch (tag)
            {
                case TagPattern.c_hash: return text.IndexOf(_target1);
                case TagPattern.C_hash: return text.IndexOf(_target2);
                case TagPattern.csharp: return text.IndexOf(_target3);
                case TagPattern.Csharp: return text.IndexOf(_target4);
                case TagPattern.cs: return text.IndexOf(_target5);
                case TagPattern.CS: return text.IndexOf(_target6);
                default: return -1;

            }
        }

        public string DeleteTarget(TagPattern tag, string text)
        {
            switch (tag)
            {
                case TagPattern.c_hash: return text.Remove(text.IndexOf(_target1), _target1.Length);
                case TagPattern.C_hash: return text.Remove(text.IndexOf(_target2), _target2.Length);
                case TagPattern.csharp: return text.Remove(text.IndexOf(_target3), _target3.Length);
                case TagPattern.Csharp: return text.Remove(text.IndexOf(_target4), _target4.Length);
                case TagPattern.cs: return text.Remove(text.IndexOf(_target5), _target5.Length);
                case TagPattern.CS: return text.Remove(text.IndexOf(_target6), _target6.Length);
                default: return "";
            }
        }

        #endregion
    }
}


/*
 悪魔のコードです
                int start = SearchTarget(pattern, html);
                int len = html.IndexOf("</code></pre></div>") - start;
                string devilCode = html.Substring(start , len);
                return devilCode;
     
     */
