using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Newtonsoft.Json.Linq;
using System.Web;
using System.Net;
using System.IO;
using System.Xml;

namespace ImageSearch
{
    /// <summary>
    /// ImageSearchControl.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ImageSearchControl : UserControl
    {   
        MainWindow mainWindow;
        DBQuery dbQuery;
        ErrorCheck errorCheck;
        
        string searchWord;
        string result;

        public ImageSearchControl(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
            dbQuery = DBQuery.GetInstance();
            errorCheck = ErrorCheck.GetInstance();
        }

        public void Btn_Search_Click(object sender, RoutedEventArgs e)
        {
            searchWord = TextBox.GetLineText(0).ToString(); //50글자 제한
            if(errorCheck.IsValidSearch(searchWord) == false)
            {
                MessageBox.Show("50글자 이내로 입력하셔야 합니다!");
                TextBox.Clear();
            }

            result = HttpRequest(searchWord);

            textBox2.Text += result;

            dbQuery.SaveLog(searchWord, DateTime.Now);

            //ImageItem image = new ImageItem();
            //imageView.Children.Add(image);
        }

        public string HttpRequest(string searchWord)
        {
            HttpWebRequest webRequest;
            HttpWebResponse webResponse;

            string API_KEY = "d86fb82fdd12eb178d7a1d73ae1a3158";
            string HEADER = "KakaoAK " + API_KEY;
            string URL = string.Format("https://dapi.kakao.com/v2/search/image.json");
            string result;

            StringBuilder getParam = new StringBuilder();

            getParam.Append("?query=" + WebUtility.UrlEncode(searchWord));

            webRequest = (HttpWebRequest)WebRequest.Create(URL + getParam);
            webRequest.Headers.Add("Authorization", HEADER);
            webRequest.ContentType = "application/json; charset=utf-8";
            webRequest.Method = "GET";

            webResponse = (HttpWebResponse)webRequest.GetResponse(); 
            Stream stream = webResponse.GetResponseStream();
            StreamReader reader = new StreamReader(stream, Encoding.GetEncoding("EUC-KR"), true);
            result = reader.ReadToEnd();
            reader.Close();
            stream.Close();
            webResponse.Close();

            return result;
        }

        public List<string> ParsingJson(string json)
        {
            List<string> imageUrl = new List<string>();
            JObject obj = JObject.Parse(json);
            JArray array = JArray.Parse(obj["documents"].ToString());
            foreach (JObject item in array)
            {
                imageUrl.Add(item["image_url"].ToString());
            }
            return imageUrl;
        }

    }
}


// 
// <WrapPanel x:Name="wrapPanel" Height="180" Width="235"/>
