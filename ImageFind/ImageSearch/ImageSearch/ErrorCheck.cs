using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageSearch
{
    class ErrorCheck
    {
        private static ErrorCheck errorCheck;

        public static ErrorCheck GetInstance()
        {
            if (errorCheck == null)
                errorCheck = new ErrorCheck();
            return errorCheck;
        }

        public bool IsValidSearch(string searchWord)
        {
            if (searchWord.Length > 50)
                return false;

            return true;
        }
    }
}




/*
String SearchText = txb_SearchKeyWord.Text;
String SearchURL = "Https://openapi.naver.com/v1/search/blog.xml?query=" + SearchText + "display=10&start=1&sort=sim";

HttpWebRequest web_request = (HttpWebRequest)WebRequest.Create(SearchURL);

web_request.Method = "GET";

                web_request.Headers.Add("X-Naver-Client-Id", ClientID);
                web_request.Headers.Add("X-Naver-Client-Secret", ClientSecret);

                HttpWebResponse web_response = (HttpWebResponse)web_request.GetResponse();
Stream stream = web_response.GetResponseStream();
byte[] buf = new byte[4096];

                for (int len = 0; (len = stream.Read(buf, 0, buf.Length)) > 0; )
                {
                    txb_result.Text += Encoding.UTF8.GetString(buf, 0, len) + Environment.NewLine;
                }
            }*/
