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

namespace Paint
{
    /// <summary>
    /// ButtonMenu.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ButtonMenu : UserControl
    {
        public PaintBoard paintBoard;

        public ButtonMenu()
        {
            InitializeComponent();
            InitializeImageButton();
        }

        public void InitializeImageButton()
        {
            selectButtonImage.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + @"\..\..\png\crop.png"));
            pencilButtonImage.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + @"\..\..\png\pencil.png"));
            eraseButtonImage.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + @"\..\..\png\erase.png"));
            paintButtonImage.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + @"\..\..\png\paint.png"));
            pipetteButtonImage.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + @"\..\..\png\pipette.png"));
            squareButtonImage.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + @"\..\..\png\square.png"));
            circleButtonImage.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + @"\..\..\png\circle.png"));
            sizeButtonImage.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + @"\..\..\png\size.png"));
        }

        private void SelectButtonClicked(object sender, RoutedEventArgs e)
        {

        }

        private void PencilButtonClicked(object sender, RoutedEventArgs e)
        {

        }

        private void EraseButtonClicked(object sender, RoutedEventArgs e)
        {

        }

        private void PaintButtonClicked(object sender, RoutedEventArgs e)
        {

        }

        private void PipetteButtonClicked(object sender, RoutedEventArgs e)
        {

        }

        private void SquareButtonClicked(object sender, RoutedEventArgs e)
        {

        }

        private void CircleButtonClicked(object sender, RoutedEventArgs e)
        {

        }

        private void SizeButtonClicked(object sender, RoutedEventArgs e)
        {

        }

        private void ColorButtonClicked(object sender, RoutedEventArgs e)
        {
            Button colorButton = sender as Button;
            currentColor.Background = colorButton.Background;
        }
    }
}
