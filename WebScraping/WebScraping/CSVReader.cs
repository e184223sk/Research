using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace WebScraping
{
    class CSVReader
    {
        //csvファイルを二重配列にする
        public static string[] Read(string url)
        {
            string[] data ;
            using (StreamReader sr = new StreamReader(url))
            {
                string text = sr.ReadToEnd();

                // カンマの数を数えてその数の半分が行の数
                int row = (text.Length - text.Replace(",", "").Length);
                data = new string[row];
                for (int i = 0; i < data.Length; i++)
                {
                    data[i] = text.Remove(text.IndexOf(","), text.Length - text.IndexOf(","));
                    text = text.Remove(0, text.IndexOf(",") + 1);

                }

            }
            return data;
        }


    }
}
