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
    /// LoginControl.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class LoginControl : UserControl
    {
        MainWindow mainWindow;
        DAO dao;
        ErrorCheck errorCheck;

        public LoginControl()
        {
            InitializeComponent();
            
        }

        public LoginControl(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
            dao = new DAO();
            this.errorCheck = ErrorCheck.GetInstance();
        }

        private void ForgotPasswordClicked(object sender, RoutedEventArgs e)
        {
            mainWindow.MainGrid.Children.Clear();
            mainWindow.MainGrid.Children.Add(new FindPasswordControl());
        }

        private void SignInClicked(object sender, RoutedEventArgs e)
        {   
            /*
            if(inputID.Text == null || inputPassword == null)
            {
                MessageBox.Show("아이디 및 비밀번호를 입력해주세요.");
                inputID.Clear();
                inputPassword.Clear();
                return;
            }*/

            if (errorCheck.MemberID(inputID.Text))
            {
                MessageBox.Show("아이디 양식에 맞춰 입력해주세요.");
                inputID.Clear();
                return;
            }

            if(errorCheck.MemberPassword(inputPassword.Text))
            {
                MessageBox.Show("비밀번호 양식에 맞춰 입력해주세요.");
                inputPassword.Clear();
                return;
            }
                
            mainWindow.MainGrid.Children.Clear();
            mainWindow.MainGrid.Children.Add(new MainViewControl());
        }

        private void CreateAccountClicked(object sender, RoutedEventArgs e)
        {
            mainWindow.MainGrid.Children.Clear();
            mainWindow.MainGrid.Children.Add(new SignUpControl());
        }
    }
}
