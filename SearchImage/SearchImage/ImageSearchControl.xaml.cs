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
using System.Xml;
using System.Web;
using System.Net;
using System.IO;

namespace SearchImage
{
    /// <summary>
    /// 이미지 검색 화면 이벤트 처리 등등
    /// </summary>
    public partial class ImageSearchControl : UserControl
    {
        MainWindow mainWindow;
        DBQuery dbQuery;
        ErrorCheck errorCheck;
        Image image;

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
                MessageBox.Show("50글자 이내로 입력 하셔야 되거나 공백을 입력하시면 안됩니다!");
                TextBox.Clear();
                return;
            }

            //콤보박스에서 개수 설정
            if (ComboBox.SelectedValue == null)
            {
                MessageBox.Show("콤보박스에서 항목을 선택하셔야 합니다!");
                return;
            }

            result = HttpRequest(searchWord);
            List<string> imageURL = ParsingJson(result);

            //콤보박스 10개 설정시 검색결과가 10개 미만일 경우 모든 이미지 출력
            if (View10Contents.IsSelected)
            {
                if (imageURL.Count < 10)
                    PrintImage(imageURL.Count, imageURL);
                else
                    PrintImage(10, imageURL);
            }

            //콤보박스 20개 설정시 검색결과가 20개 미만일 경우 모든 이미지 출력
            if (View20Contents.IsSelected)
            {
                if (imageURL.Count < 20)
                    PrintImage(imageURL.Count, imageURL);
                else
                    PrintImage(20, imageURL);
            }

            //콤보박스 30개 설정시 검색결과가 30개 미만일 경우 모든 이미지 출력
            if (View30Contents.IsSelected)
            {
                if (imageURL.Count < 30)
                    PrintImage(imageURL.Count, imageURL);
                else
                    PrintImage(30, imageURL);
            }

            ScrollViewer.SetVerticalScrollBarVisibility(scrollViewer, ScrollBarVisibility.Visible);
            dbQuery.SaveLog(searchWord, DateTime.Now);
        }

        //카카오 API 이용하여 GET 방식으로 Request 메시지 보내고
        //stream을 이용하여 Response 받음
        public string HttpRequest(string searchWord)
        {
            HttpWebRequest webRequest;
            HttpWebResponse webResponse;

            string API_KEY = "d86fb82fdd12eb178d7a1d73ae1a3158";
            string HEADER = "KakaoAK " + API_KEY;
            string URL = string.Format("https://dapi.kakao.com/v2/search/image.json");
            string result;

            StringBuilder getParam = new StringBuilder();

            getParam.Append("?query=" + HttpUtility.UrlEncode(searchWord));

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

        //json형태로 받아온 string 값을 썸네일의 URL을 파싱하여 리턴
        public List<string> ParsingJson(string json)
        {
            List<string> imageURL = new List<string>();
            JObject obj = JObject.Parse(json);
            JArray array = JArray.Parse(obj["documents"].ToString());
            foreach (JObject item in array)
            {
                imageURL.Add(item["thumbnail_url"].ToString());
            }
            return imageURL;
        }

        //인자로 들어오는 url을 비트맵 이미지를 이용하여 변환시켜 이미지 객체.Source에 바로 할당하여 이미지 객체 리턴
        public Image LoadImage(string url)
        {
            if (string.IsNullOrEmpty(url))
                return null;

            Image newImage = new Image()
            {
                Height = 400,
                Width = 260
            };

            BitmapImage bimgTemp = new BitmapImage();
            bimgTemp.BeginInit();
            bimgTemp.UriSource = new Uri(url, UriKind.RelativeOrAbsolute);
            bimgTemp.EndInit();
            newImage.Source = bimgTemp;
            return newImage;
        }

        //각각의 이미지 객체에 더블클릭 이벤트를 걸어주고 stackpanel에 추가시켜줌.
        public void PrintImage(int count, List<string> imageURL)
        {
            if (count == 0)
            {
                MessageBox.Show("검색결과가 없습니다!");
            }

            for (int i = 0; i < count; i++)
            {
                image = LoadImage(imageURL[i]);
                image.PreviewMouseDown += MouseDoubleClicked;
                stackPanel.Children.Add(image);
            }
        }

        //이벤트 발생된 곳의 source(위치)를  형번환을 통해 새로운 이미지 객체에 그 위치를 할당해준다.
        //새 이미지 객체를 생성하는 이유는 기존에 있는 이미지는 기존 stackPanel과 종속관계에 있기 때문이다.
        //새롭게 생성한 window의 내용(Content)에 더블클릭 이벤트가 발생한 이미지를 넣어주어 가장 맨위로 띄운다.(ShowDialog 메소드 이용)   
        public void MouseDoubleClicked(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
            {
                Image imagePosition = (Image)e.Source;
                Image newImage = new Image()
                {
                    Source = imagePosition.Source
                };

                ImageWindow imageWindow= new ImageWindow()
                {
                    Content = newImage,
                    Owner = Application.Current.MainWindow
                };
                imageWindow.ShowDialog();
            }
        }
    }
}
