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
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        MainControl mainControl = new MainControl();
        InputControl inputControl = new InputControl();

        public MainWindow()
        {
            InitializeComponent();
            MainGrid.Children.Add(mainControl);

            mainControl.Btn_Image.Click += new RoutedEventHandler(Btn_ImageClicked);
            mainControl.Btn_Recent.Click += Btn_RecentClicked;
            inputControl.Btn_Back.Click += Btn_BackClicked;

        }

        public void Btn_BackClicked(object sender, RoutedEventArgs e)
        {
            MainGrid.Children.Clear();
            MainGrid.Children.Add(mainControl);
        }

        public void Btn_ImageClicked(object sender, RoutedEventArgs e)
        {
            MainGrid.Children.Clear();
            MainGrid.Children.Add(inputControl);
        }

        public void Btn_RecentClicked(object sender, RoutedEventArgs e)
        {
            MainGrid.Children.Clear();
            MainGrid.Children.Add(inputControl);
        }
    }
}
