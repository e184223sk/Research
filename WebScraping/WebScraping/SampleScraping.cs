using System.Net;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace WebScraping
{
    class WebScraping
    {
        public string GetHTML(string url)
        {
            //URLからRequestを作成
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            //html格納用
            string html = "";

            //指定されたURLに対してRequestを投げてResponseを取得
            using (HttpWebResponse resonse = (HttpWebResponse)request.GetResponse())
            using (Stream responseStream = resonse.GetResponseStream())

            //取得した文字列をUTF-8でエンコード
            using (StreamReader reader = new StreamReader(responseStream, Encoding.UTF8))
            {
                //htmlを格納
                html = reader.ReadToEnd();
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
            Regex regex = new Regex("<code>(?<Code>.*?)</code>", RegexOptions.IgnoreCase | RegexOptions.Singleline);

            //見つかったすべての部分文字列
            string Codes = "";

            //まずは一個探す
            var match = regex.Match(html);
            var group = match.Groups["Code"];

            /*
            if(group.Value.Contains("<span>"))
                Codes += RemoveSpan(group.Value);
            else */
            //Codes +=  IsProgram( group.Value) ?group.Value +",": "" ;

            string tmp_s = IsProgram(group.Value) ? group.Value : "";

            Codes = AllTagsDelete(tmp_s) +"," + System.Environment.NewLine;
            //MessageBox.Show(Regex.Replace(group.Value,"<[^>]*?>",""), "タグ消しテキスト", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //次にマッチする文字列があれば追記していく
            do
            {
                match = match.NextMatch();
                Codes += AllTagsDelete(match.Groups["Code"].Value) + "," + System.Environment.NewLine;
            }
            while (match.Success);

            return Codes;

        }

       

        public string GetSentence(string html)
        {
            Regex regex = new Regex("<p>(?<Sentence>.*?)</p>", RegexOptions.IgnoreCase | RegexOptions.Singleline);

            string sentences = "";
            var match = regex.Match(html);
            var group = match.Groups["Sentence"];
            sentences = AllTagsDelete( group.Value);
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
            for(int i = 0;i < lines.Length; i++)
            {
                if (Regex.IsMatch(lines[i], @"[\p{IsHiragana}\p{IsKatakana}\p{IsCJKUnifiedIdeographs}]+")) 
                {
                    if (!lines[i].Contains("//") && !lines[i].Contains("\""))
                    {
                        MessageBox.Show(lines[i], "IsJapanese", MessageBoxButtons.OK, MessageBoxIcon.Information);
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