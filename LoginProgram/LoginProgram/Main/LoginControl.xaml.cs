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
    /// 로그인 화면 컨트롤러
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
            mainWindow.Closed += MainWindow_Closed;
        }

        //우측 상단 x 버튼으로 프로그램 종료시 데이터베이스 연결 종료
        private void MainWindow_Closed(object sender, EventArgs e)
        {
            dao.CloseConnection();
            dao.DataReaderClose();
        }

        public void ForgotPasswordClicked(object sender, RoutedEventArgs e)
        {
            mainWindow.MainGrid.Children.Clear();
            mainWindow.MainGrid.Children.Add(new FindPasswordControl(mainWindow, this, dao));
        }

        //로그인 Sign In 클릭 이벤트
        public void SignInClicked(object sender, RoutedEventArgs e)
        {   
            if (errorCheck.MemberID(inputID.Text))
            {
                MessageBox.Show("아이디 양식에 맞춰 입력해주세요.");
                inputID.Clear();
                return;
            }

            if(errorCheck.MemberPassword(inputPassword.Password))
            {
                MessageBox.Show("비밀번호 양식에 맞춰 입력해주세요.");
                inputPassword.Clear();
                return;
            }

            if(dao.IsAuthenticate(inputID.Text, inputPassword.Password) == false)
            {
                MessageBox.Show("존재하지 않는 사용자 혹은 비밀번호가 일치하지 않습니다.");
                inputPassword.Clear();
                inputID.Clear();
                return;
            }

            mainWindow.MainGrid.Children.Clear();
            mainWindow.MainGrid.Children.Add(new MainViewControl(inputID.Text, mainWindow, this, dao));
        }

        //회원가입
        public void CreateAccountClicked(object sender, RoutedEventArgs e)
        {
            mainWindow.MainGrid.Children.Clear();
            mainWindow.MainGrid.Children.Add(new SignUpControl(mainWindow, this, dao));
        }
    }
}
