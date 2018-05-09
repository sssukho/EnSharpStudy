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
            
            stackPanel.Children.Clear();
            searchWord = TextBox.GetLineText(0).ToString(); //50글자 제한

            if (errorCheck.IsValidSearch(searchWord) == false)
            {
                MessageBox.Show("50글자 이내로 입력하셔야 합니다!");
                TextBox.Clear();
                return;
            }

            if(ComboBox.SelectedValue == null)
            {
                MessageBox.Show("콤보박스에서 항목을 선택하셔야 합니다!");
                return;
            }

            result = HttpRequest(searchWord);
            List<string> imageURL = ParsingJson(result);

            //10개 일때
            if (View10Contents.IsSelected)
            {
                if (imageURL.Count < 10)
                    PrintImage(imageURL.Count, imageURL);
                PrintImage(10, imageURL);
            }

            //20개 일때
            if (ComboBox.Items.Contains("20개"))
            {
                if (imageURL.Count < 20)
                    PrintImage(imageURL.Count, imageURL);
                PrintImage(20, imageURL);
            }

            //30개 일때
            if (ComboBox.Items.Contains("30개"))
            {
                if (imageURL.Count < 30)
                    PrintImage(imageURL.Count, imageURL);
                PrintImage(30, imageURL);
            }

            ScrollViewer.SetVerticalScrollBarVisibility(scrollViewer, ScrollBarVisibility.Visible);
            dbQuery.SaveLog(searchWord, DateTime.Now);
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
            List<string> imageURL = new List<string>();
            JObject obj = JObject.Parse(json);
            JArray array = JArray.Parse(obj["documents"].ToString());
            foreach (JObject item in array)
            {
                imageURL.Add(item["image_url"].ToString());
            }
            return imageURL;
        }

        public BitmapImage LoadImage(string url)
        {
            if (string.IsNullOrEmpty(url))
                return null;
            WebClient wc = new WebClient();
            Byte[] MyData = wc.DownloadData(url);
            wc.Dispose();
            BitmapImage bimgTemp = new BitmapImage();
            bimgTemp.BeginInit();
            bimgTemp.StreamSource = new MemoryStream(MyData);
            bimgTemp.EndInit();
            return bimgTemp;
        }

        public void PrintImage(int count, List<string> imageURL)
        {
            for (int i = 0; i < count; i++)
            {
                Image image = new Image()
                {
                    Source = LoadImage(imageURL[i]),
                    Height = 150,
                    Width = 150
                };
                stackPanel.Children.Add(image);
            }
        }
    }
}