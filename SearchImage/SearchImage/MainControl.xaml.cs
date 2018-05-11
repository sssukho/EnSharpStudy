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

namespace SearchImage
{
    /// <summary>
    /// 가장 첫 화면의 UserControl 화면
    /// </summary>
    public partial class MainControl : UserControl
    {
        MainWindow mainWindow;
        ImageSearchControl imageSearchControl;
        RecentSearchControl recentSearchControl;

        public MainControl(MainWindow mainWindow, ImageSearchControl imageSearchControl, RecentSearchControl recentSearchControl)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
            this.imageSearchControl = imageSearchControl;
            this.recentSearchControl = recentSearchControl;

            //이미지 검색 화면에서의 뒤로가기와 최근 검색어 화면에서의 뒤로가기 버튼의 이벤트는 메인 컨트롤에서 이루어지고 있음.
            //두 화면에서의 뒤로가기 자체가 모두 메인컨트롤로 돌아오는 것이기 때문에 메인 컨트롤에서 걸어주고 있음.
            imageSearchControl.Btn_Back.Click += Btn_Back_Click;
            recentSearchControl.Btn_Back.Click += Btn_Back_Click;
        }

        public void Btn_ImageSearch_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.MainGrid.Children.Clear();
            mainWindow.MainGrid.Children.Add(imageSearchControl);
        }

        public void Btn_Recent_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.MainGrid.Children.Clear();
            mainWindow.MainGrid.Children.Add(recentSearchControl);
        }

        public void Btn_Back_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.MainGrid.Children.Clear();
            imageSearchControl.TextBox.Clear();
            imageSearchControl.stackPanel.Children.Clear();

            recentSearchControl.textBox.Clear();
            mainWindow.MainGrid.Children.Add(this);
        }
    }
}
