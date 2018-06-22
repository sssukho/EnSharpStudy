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
using System.Drawing;
using System.IO;
using System.Diagnostics;

namespace WindowsExplorer
{
    /// <summary>
    /// ContentControl.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ContentControl : UserControl
    {
        public AddressControl addressControl;
        public string currentPath;

        public ContentControl(AddressControl addressControl)
        {
            InitializeComponent();
            this.addressControl = addressControl;
        }

        public void setCurrentPath(string currentPath)
        {
            if (!currentPath.EndsWith(@"\"))
                this.currentPath = currentPath.Insert(currentPath.Length, @"\");
            else
                this.currentPath = currentPath;
        }

        public ImageSource GetIcon(string filePath)
        {
            if(File.Exists(filePath))
            {
                Icon icon = Icon.ExtractAssociatedIcon(filePath);
                return System.Windows.Interop.Imaging.CreateBitmapSourceFromHIcon(
                    icon.Handle, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            }
            return null;
        }

        public void SetIcon(string directoryPath)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(directoryPath);
            setCurrentPath(directoryPath);

            iconPanel.Children.Clear();
            foreach (var item in directoryInfo.GetFileSystemInfos())
            {
                //디렉토리일 경우
                if (item.Attributes.HasFlag(FileAttributes.Directory) && !item.Attributes.HasFlag(FileAttributes.Hidden))
                {
                    System.Windows.Controls.Image directoryIcon = new System.Windows.Controls.Image();
                    Button directoryButton = new Button();
                    directoryIcon.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + @"\..\..\ButtonImage\Directory.png"));
                    directoryIcon.Width = 60;
                    directoryIcon.Height = 60;
                    directoryButton.Content = directoryIcon;
                    directoryButton.Tag = item.Name;
                    directoryButton.Background = System.Windows.Media.Brushes.White;

                    Label directoryName = new Label();
                    directoryName.Content = item.Name;
                    if (item.Name.Length > 8)
                        directoryName.Content = item.Name.Substring(0, 8) + "...";
                    
                    directoryName.FontSize = 12;
                    directoryName.HorizontalContentAlignment = HorizontalAlignment.Center;
                    directoryName.VerticalContentAlignment = VerticalAlignment.Bottom;

                    StackPanel directoryPanel = new StackPanel();
                    directoryPanel.Children.Add(directoryButton);
                    directoryPanel.Children.Add(directoryName);

                    iconPanel.Children.Add(directoryPanel);
                    directoryButton.Click += DirectoryButtonClicked;
                    directoryButton.MouseDoubleClick += DirectoryButtonDoubleClicked;
                    directoryButton.LostFocus += DirectoryButtonLostFocus;
                }
                //파일일 경우
                else if(item.Attributes.HasFlag(FileAttributes.Archive) && !item.Attributes.HasFlag(FileAttributes.System))
                {
                    System.Windows.Controls.Image fileIcon = new System.Windows.Controls.Image();
                    Button fileButton = new Button();

                    fileIcon.Source = GetIcon(item.FullName);
                    fileIcon.Width = 60;
                    fileIcon.Height = 60;
                    fileButton.Content = fileIcon;
                    fileButton.Tag = item.Name;
                    fileButton.Background = System.Windows.Media.Brushes.White;

                    Label fileName = new Label();
                    fileName.Content = item.Name;
                    if (item.Name.Length > 8)
                        fileName.Content = item.Name.Substring(0, 8) + "...";
                    fileName.FontSize = 12;
                    fileName.HorizontalAlignment = HorizontalAlignment.Center;
                    fileName.VerticalAlignment = VerticalAlignment.Bottom;

                    StackPanel filePanel = new StackPanel();
                    filePanel.Children.Add(fileButton);
                    filePanel.Children.Add(fileName);

                    fileButton.Click += FileButtonClicked;
                    fileButton.MouseDoubleClick += FileButtonMouseDoubleClicked;
                    fileButton.LostFocus += FileButtonLostFocus;
                    iconPanel.Children.Add(filePanel);                    
                }
            }
        }

        public void FileButtonClicked(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            button.Background = System.Windows.Media.Brushes.SkyBlue;
        }

        public void FileButtonLostFocus(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            button.Background = System.Windows.Media.Brushes.White;
        }

        public void FileButtonMouseDoubleClicked(object sender, MouseButtonEventArgs e)
        {
            Button button = (Button)sender;
            button.Background = System.Windows.Media.Brushes.White;
            Process.Start(currentPath + button.Tag.ToString());
        }

        public void DirectoryButtonLostFocus(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            button.Background = System.Windows.Media.Brushes.White;
        }

        public void DirectoryButtonDoubleClicked(object sender, MouseButtonEventArgs e)
        {
            Button button = (Button)sender;
            button.Background = System.Windows.Media.Brushes.White;

            addressControl.SetCurrentPath(currentPath + button.Tag.ToString());
            addressControl.backPathStack.Push(currentPath);
            SetIcon(currentPath + button.Tag.ToString());
            
        }

        public void DirectoryButtonClicked(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            button.Background = System.Windows.Media.Brushes.SkyBlue;
        }
    }
}
