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

namespace ImageSearch
{
    /// <summary>
    /// MainControl.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainControl : UserControl
    {
        MainWindow mainWindow;
        ImageSearchControl imageSearchControl;
        RecentSearchControl recentSearchControl;

        public MainControl()
        {
            InitializeComponent();
        }

        public MainControl(MainWindow mainWindow, ImageSearchControl imageSearchControl, RecentSearchControl recentSearchControl)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
            this.imageSearchControl = imageSearchControl;
            this.recentSearchControl = recentSearchControl;
        }
        
        public void Btn_ImageSearch_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.MainGrid.Children.Clear();
            mainWindow.MainGrid.Children.Add(imageSearchControl);
        }

        public void Btn_Recent_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.MainGrid.Children.Clear();
            mainWindow.MainGrid.Children.Add(recentSearchControl);
        }
    }
}
