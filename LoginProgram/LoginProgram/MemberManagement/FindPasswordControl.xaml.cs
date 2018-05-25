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
    /// FindPasswordControl.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class FindPasswordControl : UserControl
    {
        ErrorCheck errorCheck;
        DAO dao;
        LoginControl loginControl;
        MainWindow mainWindow;

        public FindPasswordControl()
        {
            InitializeComponent();
        }

        public FindPasswordControl(MainWindow mainWindow, LoginControl loginControl, DAO dao)
        {
            InitializeComponent();
            errorCheck = ErrorCheck.GetInstance();
            this.dao = dao;
            this.loginControl = loginControl;
            this.mainWindow = mainWindow;
        }

        public void FindClicked(object sender, RoutedEventArgs e)
        {
            bool IsSucceed;
            if (errorCheck.MemberPhone(inputPhone.Text))
            {
                MessageBox.Show("올바른 핸드폰 번호가 아닙니다.");
                inputPhone.Clear();
                return;
            }

            if(errorCheck.MemberEmail(inputEmail.Text))
            {
                MessageBox.Show("올바른 이메일이 아닙니다.");
                inputEmail.Clear();
                return;
            }

            SendMail sendMail = new SendMail(dao);
            IsSucceed = sendMail.Send(inputPhone.Text, inputEmail.Text);
            if(IsSucceed == false)
            {
                MessageBox.Show("존재하는 회원이 아닙니다.");
                inputPhone.Clear();
                return;
            }

            MessageBox.Show("입력하신 이메일 주소로 이메일과 비밀번호를 보냈습니다.");
            inputPhone.Clear();
            inputEmail.Clear();
        }

        public void BackClicked(object sender, RoutedEventArgs e)
        {
            mainWindow.MainGrid.Children.Clear();
            loginControl.inputID.Clear();
            loginControl.inputPassword.Clear();
            mainWindow.MainGrid.Children.Add(loginControl);
        }
    }
}
