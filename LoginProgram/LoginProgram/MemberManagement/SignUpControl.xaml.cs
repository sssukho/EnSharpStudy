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
       
        public SignUpControl(MainWindow mainWindow, LoginControl loginControl, DAO dao)
        {
            InitializeComponent();
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
                ShowMessage("아이디");
                inputID.Clear();
                return;
            }
            if (errorCheck.MemberPassword(inputPassword.Password))
            {
                ShowMessage("비밀번호");
                inputPassword.Clear();
                inputPasswordCheck.Clear();
                return;
            }
            if (errorCheck.MemberName(inputName.Text))
            {
                ShowMessage("이름");
                inputName.Clear();
                return;
            }
            if(errorCheck.MemberBirth(inputBirth.Text))
            {
                ShowMessage("생년월일");
                inputBirth.Clear();
                return;
            }
            if(errorCheck.MemberEmail(inputEmail.Text))
            {
                ShowMessage("이메일");
                inputEmail.Clear();
                return;
            }
            if(errorCheck.MemberPhone(inputPhone.Text))
            {
                ShowMessage("핸드폰 번호");
                inputPhone.Clear();
                return;
            }
            if(errorCheck.MemberAddress(inputAddress.Text))
            {
                ShowMessage("주소");
                inputAddress.Clear();
                return;
            }
            if (errorCheck.MemberIdentifyNumber(inputIdenetity.Text))
            {
                ShowMessage("주민등록번호");
                inputIdenetity.Clear();
                return;
            }

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

            dao.Insert(newMember);
            MessageBox.Show("회원가입에 성공하셨습니다!");
            InitializeTextBox();
        }

        public void BackClicked(object sender, RoutedEventArgs e)
        {
            mainWindow.MainGrid.Children.Clear();
            loginControl.inputID.Clear();
            loginControl.inputPassword.Clear();
            mainWindow.MainGrid.Children.Add(loginControl);
        }

        public void InitializeTextBox()
        {
            inputID.Clear();
            inputPassword.Clear();
            inputPasswordCheck.Clear();
            inputName.Clear();
            inputBirth.Clear();
            inputEmail.Clear();
            inputPhone.Clear();
            inputAddress.Clear();
            inputIdenetity.Clear();
        }

        public void ShowMessage(string input)
        {
            MessageBox.Show("{0} 양식에 맞춰 주십시오.", input);
        }
    }
}
