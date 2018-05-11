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
    /// 윈도우는 하나고 컨트롤 화면만 바꾸면서 프로그램이 돌아가는 구조
    /// 가장 신경썼던 부분 : 객체 생성 최소화, 완성도(예외처리, 기능)
    /// 가장 힘들었던 부분 :  예외처리
    /// 아쉬웠던 부분 : UI 신경쓰지 못한점
    /// </summary>
    public partial class MainWindow : Window
    {
        MainControl mainControl;
        ImageSearchControl imageSearchControl;
        RecentSearchControl recentSearchControl;

        public MainWindow()
        {
            InitializeComponent();
            imageSearchControl = new ImageSearchControl(this);
            recentSearchControl = new RecentSearchControl(this);

            mainControl = new MainControl(this, imageSearchControl, recentSearchControl);
            MainGrid.Children.Add(mainControl);
        }
    }
}
