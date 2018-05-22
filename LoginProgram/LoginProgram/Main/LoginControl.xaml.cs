﻿using System;
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
    /// LoginControl.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class LoginControl : UserControl
    {
        SignUpControl signUpControl;
        EditProfileControl editProfileControl;
        MainWindow mainWindow;

        public LoginControl()
        {
            InitializeComponent();
        }

        public LoginControl(MainWindow mainWindow, SignUpControl signUpControl, EditProfileControl editProfileControl)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
            this.signUpControl = signUpControl;
            this.editProfileControl = editProfileControl;
        }

        private void FindPasswordClicked(object sender, RoutedEventArgs e)
        {
            mainWindow.MainGrid.Children.Clear();
            mainWindow.MainGrid.Children.Add(new FindPasswordControl());
        }

        private void SignInClicked(object sender, RoutedEventArgs e)
        {
            mainWindow.MainGrid.Children.Clear();
            mainWindow.MainGrid.Children.Add(new MainViewControl());
        }

        private void CreateAccountClicked(object sender, RoutedEventArgs e)
        {
            mainWindow.MainGrid.Children.Clear();
            mainWindow.MainGrid.Children.Add(signUpControl);
        }
    }
}
