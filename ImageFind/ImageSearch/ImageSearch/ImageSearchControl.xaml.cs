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

namespace ImageSearch
{
    /// <summary>
    /// ImageSearchControl.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ImageSearchControl : UserControl
    {
        private const string API_KEY = "d86fb82fdd12eb178d7a1d73ae1a3158";

        MainWindow mainWindow;
        string searchWord;

        public ImageSearchControl(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
        }

        public void Btn_Search_Click(object sender, RoutedEventArgs e)
        {
            searchWord = TextBox.GetLineText(0);
            DBQuery dbQuery = DBQuery.GetInstance();

            dbQuery.SaveLog(searchWord, DateTime.Now);


            //ImageItem image = new ImageItem();
            //wrapPanel.Children.Add(image);
        }

        public void Btn_Back_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
