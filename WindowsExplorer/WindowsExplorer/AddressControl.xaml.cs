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
using System.IO;

namespace WindowsExplorer
{
    /// <summary>
    /// AddressControl.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class AddressControl : UserControl
    {
        public string currentPath;
        public Stack<string> frontPathStack;
        public Stack<string> backPathStack;
        public ContentControl contentControl;

        public AddressControl()
        {
            InitializeComponent();
            frontPathStack = new Stack<string>();
            backPathStack = new Stack<string>();
            InitializeImageButton();
        }

        public void InitializeImageButton()
        {
            UpButtonImage.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + @"\..\..\ButtonImage\UpButton.png"));
        }

        public void SetCurrentPath(string currentPath)
        {
            this.currentPath = currentPath;
            if (!currentPath.EndsWith(@"\"))
                this.currentPath = currentPath.Insert(currentPath.Length, @"\");

            addressTextBox.Text = currentPath;
        }

        public void BackButtonClicked(object sender, RoutedEventArgs e)
        {
            if(backPathStack.Count > 0)
            {
                frontPathStack.Push(currentPath);
                currentPath = backPathStack.Pop();
                addressTextBox.Text = currentPath;
                contentControl.SetIcon(currentPath);
            }
        }

        public void FrontButtonClicked(object sender, RoutedEventArgs e)
        {
            if (frontPathStack.Count > 0)
            {
                backPathStack.Push(currentPath);
                currentPath = frontPathStack.Pop();
                addressTextBox.Text = currentPath;
                contentControl.SetIcon(currentPath);
            }
        }

        public void AddressTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key.Equals(Key.Return))
            {
                if (Directory.Exists(addressTextBox.Text))
                {
                    backPathStack.Push(currentPath);
                    frontPathStack.Clear();
                    currentPath = addressTextBox.Text;
                    contentControl.SetIcon(addressTextBox.Text.ToString());
                }

                else
                {
                    MessageBox.Show("존재하지 않는 경로 입니다.");
                } 
            }
        }
    }
}
