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
    /// 회원 탈퇴 클래스
    /// </summary>
    public partial class WithdrawControl : UserControl
    {
        string logonID;
        MainWindow mainWindow;
        LoginControl loginControl;
        MainViewControl mainViewControl;
        DAO dao;

        public WithdrawControl(string logonID, MainWindow mainWindow, LoginControl loginControl, MainViewControl mainViewControl, DAO dao)
        {
            InitializeComponent();
            this.logonID = logonID;
            this.mainWindow = mainWindow;
            this.loginControl = loginControl;
            this.mainViewControl = mainViewControl;
            this.dao = dao;
        }

        public void DeleteClicked(object sender, RoutedEventArgs e)
        {
            dao.Delete(logonID);
            MessageBox.Show("회원 삭제가 완료되었습니다!");

            mainWindow.MainGrid.Children.Clear();
            mainWindow.MainGrid.Children.Add(loginControl);
        }

        public void BackClicked(object sender, RoutedEventArgs e)
        {
            mainWindow.MainGrid.Children.Clear();
            mainWindow.MainGrid.Children.Add(mainViewControl);
        }

        private void InputPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            string realtimePassword;
            realtimePassword = inputPassword.Password;
            if (dao.IsAuthenticate(logonID, realtimePassword))
                Delete.IsEnabled = true;
        }
    }
}
