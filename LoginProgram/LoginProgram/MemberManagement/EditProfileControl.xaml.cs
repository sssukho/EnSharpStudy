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
            if(inputPassword != inputPasswordCheck)
            {
                MessageBox.Show("비밀번호와 비밀번호 확인이 일치하지 않습니다!");
                return;
            }
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
            if (errorCheck.MemberBirth(inputBirth.Text))
            {
                ShowMessage("생년월일");
                inputBirth.Clear();
                return;
            }
            if (errorCheck.MemberEmail(inputEmail.Text))
            {
                ShowMessage("이메일");
                inputEmail.Clear();
                return;
            }
            if (errorCheck.MemberPhone(inputPhone.Text))
            {
                ShowMessage("핸드폰 번호");
                inputPhone.Clear();
                return;
            }
            if (errorCheck.MemberAddress(inputAddress.Text))
            {
                ShowMessage("주소");
                inputAddress.Clear();
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
            MessageBox.Show("{0} 양식에 맞춰 주십시오.", input);
        }
    }
}
