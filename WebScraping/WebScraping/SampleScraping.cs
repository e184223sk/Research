﻿using System.Net;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System;
namespace WebScraping
{
    public class PageScraper
    {
        //C#コードを囲むdiv。　種類が　c# C# csharpと3種類あるため　含有チェックとタグを消す際に３分岐する必要あり　enumやね
        const string target = "<div class=\"code-frame\" data-lang=\"C#\">";
        const string target2 = "<div class=\"code-frame\" data-lang=\"csharp\">";
        const string target3 = "<div class=\"code-frame\" data-lang=\"Csharp\">";


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

                for (int i = 1; i < tmp_html.Length ; i++)
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

                System.IO.File.WriteAllText(@"C:\Users\konolab\Desktop\xxx\1.txt", CsharpCode);//ikeda
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
        #region TagPattern Methods


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


            if (text.Contains(target)) return TagPattern.C_hash;
            if (text.Contains(target2)) return TagPattern.csharp;
            if (text.Contains(target3)) return TagPattern.Csharp;

            return TagPattern.NULL;


        }

        public int SearchTarget(TagPattern tag, string text)
        {
            switch (tag)
            {
                case TagPattern.C_hash:
                    return text.IndexOf(target);

                case TagPattern.csharp:
                    return text.IndexOf(target2);

                case TagPattern.Csharp:
                    return text.IndexOf(target3);
                default:
                    return -1;

            }
        }

        public string DeleteTarget(TagPattern tag, string text)
        {
            switch (tag)
            {
                case TagPattern.C_hash: return text.Remove(text.IndexOf(target), target.Length);
                case TagPattern.csharp: return text.Remove(text.IndexOf(target2), target.Length);
                case TagPattern.Csharp: return text.Remove(text.IndexOf(target3), target.Length);
                default: return "";
            }
        }

        #endregion
    }
}


public enum TagPattern
{
    C_hash,
    csharp,
    Csharp,
    NULL
} 

/*
 悪魔のコードです
                int start = SearchTarget(pattern, html);
                int len = html.IndexOf("</code></pre></div>") - start;
                string devilCode = html.Substring(start , len);
                return devilCode;
     
     */
