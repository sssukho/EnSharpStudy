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
            string[] selectedUser;

            selectedUser = dao.Select(inputID.Text);

            password.Text = selectedUser[1];
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
