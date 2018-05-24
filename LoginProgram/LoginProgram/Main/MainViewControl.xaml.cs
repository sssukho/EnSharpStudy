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
    /// MainViewControl.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainViewControl : UserControl
    {
        MainWindow mainWindow;
        LoginControl loginControl;
        DAO dao;
        string logonID;

        public MainViewControl()
        {
            InitializeComponent();
        }

        public MainViewControl(string logonID, MainWindow mainWindow, LoginControl loginControl, DAO dao)
        {
            this.dao = dao;
            InitializeComponent();
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

        public void WithdrawClicked(object sender, RoutedEventArgs e)
        {
            mainWindow.MainGrid.Children.Clear();
            mainWindow.MainGrid.Children.Add(new WithdrawControl(logonID, mainWindow, loginControl, this, dao));
        }

    }
}
