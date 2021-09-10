using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;
namespace WebScraping
{
    class CSVReader
    {
        //csvファイルを配列にする
        public static string[] Read(string url)
        {
            string[] data ;

            using (StreamReader sr = new StreamReader(url))
            {
                string text = sr.ReadToEnd();
                string[] tmp_data= text.Split('\n'); 
                data = tmp_data;
            }



            return data;
        }


        
    }
}
