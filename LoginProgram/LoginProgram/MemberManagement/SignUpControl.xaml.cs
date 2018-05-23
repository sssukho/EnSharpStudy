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
    /// SignUpControl.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class SignUpControl : UserControl
    {
        MainWindow mainWindow;
        LoginControl loginControl;
        DAO dao;
        ErrorCheck errorCheck;

        
        public SignUpControl()
        {
            InitializeComponent();
        }

        public SignUpControl(MainWindow mainWindow, LoginControl loginControl, DAO dao)
        {
            this.mainWindow = mainWindow;
            this.loginControl = loginControl;
            this.dao = dao;
            errorCheck = ErrorCheck.GetInstance();
            
        }

        //id, password, name, gender, birth, email, phone, address, identityNumber 입력받아야함
        public void JoinClicked(object sender, RoutedEventArgs e)
        {
            string[] newMember = new string[9];
            if (errorCheck.MemberID(inputID.Text))
            {
                MessageBox.Show("아이디 양식에 맞춰 주십시오.");
                inputID.Clear();
                return;
            }
            if (errorCheck.MemberPassword(inputPassword.Password))
            {
                MessageBox.Show("비밀번호 양식에 맞춰 주십시오.");
                inputPassword.Clear();
                return;
            }
            if (errorCheck.MemberName(inputName.Text))
            {
                MessageBox.Show("이름 양식에 맞춰 주십시오.");
                inputName.Clear();
                return;
            }
            if(errorCheck.MemberEmail(inputEmail.Text))
            {
                MessageBox.Show("이메일 양식에 맞춰 주십시오.");
                inputPhone.Clear();
                return;
            }
            if(errorCheck.MemberPhone(inputPhone.Text))
            {
                MessageBox.Show("전화번호 양식에 맞춰 주십시오.");
                inputPhone.Clear();
                return;
            }
            if(errorCheck.MemberAddress(inputAddress.Text))
            {
                MessageBox.Show("주소 양식에 맞춰 주십시오.");
                inputAddress.Clear();
                return;
            }
            //identify, birth check 해야함

            
            newMember[0] = inputID.Text;
            newMember[1] = inputPassword.Password;
            newMember[2] = inputName.Text;
            if ((bool)inputMale.IsChecked)
                newMember[3] = "남자";
            if ((bool)inputFemale.IsChecked)
                newMember[3] = "여성";
            newMember[4] = inputBirth.Text;
            newMember[5] = inputEmail.Text;
            newMember[6] = inputPhone.Text;
            newMember[7] = inputAddress.Text;
            newMember[8] = inputIdenetity.Text;

            
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
