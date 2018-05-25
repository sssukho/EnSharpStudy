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
    /// 회원 가입 클래스
    /// </summary>
    public partial class SignUpControl : UserControl
    {
        MainWindow mainWindow;
        LoginControl loginControl;
        DAO dao;
        ErrorCheck errorCheck;
        bool idDuplicateCheck;
        string realtimePassword;
        bool passwordCheck;

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
            string messageType;

            messageType = errorCheck.InputErrorType(inputID.Text, inputPassword.Password, inputName.Text, 
                inputBirth.Text, inputEmail.Text, inputPhone.Text, inputAddress.Text, inputIdenetity.Text);

            if(messageType != "none")
            {
                ShowMessage(messageType);
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

            if(idDuplicateCheck == true)
            {
                MessageBox.Show("아이디 중복체크를 해주시기 바랍니다.");
                return;
            }

            if (dao.IsDuplicate(inputPhone.Text, "phone"))
            {
                MessageBox.Show("똑같은 휴대번호를 가지고 있는 회원이 있습니다.");
                inputPhone.Clear();
                return;
            }

            if(passwordCheck == false)
            {
                MessageBox.Show("패스워드와 패스워드 확인을 일치시켜야 합니다!");
                return;
            }

            dao.Insert(newMember);
            MessageBox.Show("회원가입에 성공하셨습니다!");
            InitializeTextBox();
            mainWindow.MainGrid.Children.Clear();
            mainWindow.MainGrid.Children.Add(loginControl);
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
            MessageBox.Show(input + " 양식에 맞춰 주십시오.");
        }

        private void DuplicateCheckClicked(object sender, RoutedEventArgs e)
        {
            if(dao.IsDuplicate(inputID.Text, "id"))
            {
                MessageBox.Show("중복 아이디 입니다!");
                inputID.Clear();
                idDuplicateCheck = true;
                return;
            }

            if (errorCheck.MemberID(inputID.Text))
            {
                ShowMessage("아이디");
                inputID.Clear();
                return;
            }

            MessageBox.Show("사용하실 수 있는 아이디 입니다!");
            idDuplicateCheck = false;
        }

        private void InputPasswordCheckChanged(object sender, RoutedEventArgs e)
        {
            realtimePassword = inputPasswordCheck.Password;

            if (inputPassword.Password == inputPasswordCheck.Password)
            {
                passWordCheckStatus.Text = "password와 일치합니다!";
                passWordCheckStatus.Foreground = Brushes.Green;
                passwordCheck = true;
                return;
            }

            passwordCheck = false;
            passWordCheckStatus.Foreground = Brushes.Red;
            passWordCheckStatus.Text = "password와 불일치합니다.";
        }
    }
}
