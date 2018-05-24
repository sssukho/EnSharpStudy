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
    /// EditProfileControl.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class EditProfileControl : UserControl
    {
        string logonID;
        MainWindow mainWindow;
        MainViewControl mainViewControl;
        DAO dao;
        ErrorCheck errorCheck = ErrorCheck.GetInstance();
        string realtimePassword;
        bool passwordCheck;

        public EditProfileControl(string logonID, MainWindow mainWindow, MainViewControl mainViewControl, DAO dao)
        {
            InitializeComponent();
            this.logonID = logonID;
            this.mainWindow = mainWindow;
            this.mainViewControl = mainViewControl;
            this.dao = dao;
            
            ViewUserInformation();
        }

        public void ViewUserInformation()
        {
            string[] user = new string[9];
            user = dao.Select(logonID);
            inputID.Text = user[0];
            inputPassword.Password = user[1];
            inputPasswordCheck.Password = user[1];
            inputName.Text = user[2];
            inputBirth.Text = user[4];
            inputEmail.Text = user[5];
            inputPhone.Text = user[6];
            inputAddress.Text = user[7];
            inputIdentity.Text = user[8];
        }
        
        private void InputIDClicked(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("ID는 바꿀 수 없습니다!");
        }

        private void InputIdentityClicked(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("주민등록 번호는 바꿀 수 없습니다!");
        }

        private void EditClicked(object sender, RoutedEventArgs e)
        {
            string messageType;

            messageType = errorCheck.InputErrorType(inputID.Text, inputPassword.Password, inputName.Text,
                inputBirth.Text, inputEmail.Text, inputPhone.Text, inputAddress.Text, inputIdentity.Text);

            if (messageType != "none")
            {
                ShowMessage(messageType);
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
                MessageBox.Show("패스워드 확인과 패스워드를 일치시켜야 합니다!");
                return;
            }

            MessageBox.Show("정보 수정 완료되었습니다.");
            mainWindow.MainGrid.Children.Clear();
            mainWindow.MainGrid.Children.Add(mainViewControl);
        }

        private void BackClicked(object sender, RoutedEventArgs e)
        {
            mainWindow.MainGrid.Children.Clear();
            mainWindow.MainGrid.Children.Add(mainViewControl);
        }

        public void ShowMessage(string input)
        {
            MessageBox.Show(input + " 양식에 맞춰 주십시오.");
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