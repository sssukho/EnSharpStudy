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

namespace SearchImage
{
    /// <summary>
    ///  최근 검색어 버튼 이벤트 처리 담당
    /// </summary>
    public partial class RecentSearchControl : UserControl
    {
        MainWindow mainWindow;
        DBQuery dbQuery;
        ErrorCheck errorCheck;

        public RecentSearchControl(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
            this.dbQuery = DBQuery.GetInstance();
            this.errorCheck = ErrorCheck.GetInstance();
        }

        //검색기록 버튼 이벤트 처리 메소드
        //검색어와 검색한 시간 값만 가져오므로 딕셔너리 사용해봄
        //TextBokx에 AppendText로 딕셔너리에 있는 모든 값들을 출력
        public void Btn_GetLog_Click(object sender, RoutedEventArgs e)
        {
            Dictionary<string, string> log;
            log = dbQuery.GetLog();
            foreach (var item in log)
            {
                textBox.AppendText(item.Key + "      " + item.Value + Environment.NewLine);
            }
        }

        //기록 제거 버튼 클릭시에 dbQuery 클래스에 있는 delete 쿼리 실행
        public void Btn_RemoveLog_Click(object sender, RoutedEventArgs e)
        {
            dbQuery.RemoveLog();
            textBox.Clear();
        }
    }
}
