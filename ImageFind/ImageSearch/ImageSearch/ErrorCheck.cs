using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

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
            if (searchWord.Length > 50 || string.IsNullOrEmpty(searchWord) || string.IsNullOrWhiteSpace(searchWord))
                return false;

            return true;
        }

        public bool IsValidStatusCode(System.Exception err)
        {
            if (err is WebException)
            {
                WebException we = (WebException)err;
                if (we.Response is HttpWebResponse)
                {
                    HttpWebResponse response = (HttpWebResponse)we.Response;
                    if (response.StatusCode.ToString().Contains("404"))
                        return true;
                }
            }
            return false;
        }
    }
}