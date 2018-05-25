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

namespace LoginProgram
{
    /// <summary>
    /// 로그인 후 메인화면 컨트롤러
    /// </summary>
    public partial class MainViewControl : UserControl
    {
        MainWindow mainWindow;
        LoginControl loginControl;
        DAO dao;
        string logonID;

        public MainViewControl(string logonID, MainWindow mainWindow, LoginControl loginControl, DAO dao)
        {
            InitializeComponent();
            this.dao = dao;
            this.logonID = logonID;
            this.mainWindow = mainWindow;
            this.loginControl = loginControl;
        }

        public void LogoutClicked(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("로그아웃 되었습니다.");
            mainWindow.MainGrid.Children.Clear();
            loginControl.inputID.Clear();
            loginControl.inputPassword.Clear();
            mainWindow.MainGrid.Children.Add(loginControl);
        }

        public void EditInfoClicked(object sender, RoutedEventArgs e)
        {
            mainWindow.MainGrid.Children.Clear();
            mainWindow.MainGrid.Children.Add(new EditProfileControl(logonID, mainWindow, this, dao));
        }

        //회원탈퇴 버튼 클릭
        public void WithdrawClicked(object sender, RoutedEventArgs e)
        {
            mainWindow.MainGrid.Children.Clear();
            mainWindow.MainGrid.Children.Add(new WithdrawControl(logonID, mainWindow, loginControl, this, dao));
        }

    }
}
