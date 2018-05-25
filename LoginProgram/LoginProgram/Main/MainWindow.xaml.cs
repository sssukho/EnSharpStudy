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
    /*******************sssuk's login program**************************
     * 계정 예제 -> 아이디 : sssukho / 비밀번호 : enjoy605!
     * 각 클래스 설명
        - DAO : 데이터베이스 접근 클래스
        - ErrorCheck : 예외처리
        - MainWindow : 윈도우 창만 제공하는 클래스
        - MainViewControl : 로그인 후 메인화면 컨트롤러
        - LoginControl : 로그인 화면 컨트롤러
        - EditProfileControl : 로그인 한 회원의 개인정보 편집
        - FindPasswordControl : 계정 및 비밀번호 찾기
        - SendMail : 계정 및 비밀번호 메일로 보내주는 클래스
        - SignUpControl : 회원 가입 클래스
        - WithdrawControl : 회원 탈퇴 클래스
     ********************************************************************/
     
    public partial class MainWindow : Window
    {
        LoginControl loginControl;

        public MainWindow()
        {
            InitializeComponent();
            loginControl = new LoginControl(this);
            MainGrid.Children.Add(loginControl);
        }
    }
}
