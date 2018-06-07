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

namespace WindowsExplorer
{
    /// <summary>
    /// AddressControl.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class AddressControl : UserControl
    {
        public AddressControl()
        {
            InitializeComponent();
            InitializeImageButton();
        }

        public void InitializeImageButton()
        {
            BackButtonImage.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + @"\..\..\ButtonImage\BackButton.png"));
            FrontButtonImage.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + @"\..\..\ButtonImage\FrontButton.png"));
            UpButtonImage.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + @"\..\..\ButtonImage\UpButton.png"));
        }

        public void BackButtonClicked(object sender, RoutedEventArgs e)
        {

        }

        public void FrontButtonClicked(object sender, RoutedEventArgs e)
        {

        }

        public void AddressChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
