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
    /// RecentSearchControl.xaml에 대한 상호 작용 논리
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

        public void Btn_GetLog_Click(object sender, RoutedEventArgs e)
        {
            Dictionary<string, string> log;
            log = dbQuery.GetLog();
            foreach (var item in log)
            {
                textBox.AppendText(item.Key + "      " + item.Value + Environment.NewLine);
            }
        }

        public void Btn_RemoveLog_Click(object sender, RoutedEventArgs e)
        {
            dbQuery.RemoveLog();
            textBox.Clear();
        }
    }
}
