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
            Thickness1Image.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + @"\..\..\png\Thickness1.png"));
            Thickness2Image.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + @"\..\..\png\Thickness2.png"));
            Thickness3Image.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + @"\..\..\png\Thickness3.png"));
            mouseButtonImage.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + @"\..\..\png\mouse.png"));
        }

        private void SelectButtonClicked(object sender, RoutedEventArgs e)
        {
            paintBoard.buttonType = "Select";
            Button button = sender as Button;
            button.Background = System.Windows.Media.Brushes.SkyBlue;
        }

        private void PencilButtonClicked(object sender, RoutedEventArgs e)
        {
            paintBoard.buttonType = "Pencil";
            Button button = sender as Button;
            button.Background = System.Windows.Media.Brushes.SkyBlue;
        }

        private void EraseButtonClicked(object sender, RoutedEventArgs e)
        {
            paintBoard.buttonType = "Erase";
            Button button = sender as Button;
            button.Background = System.Windows.Media.Brushes.SkyBlue;
        }

        private void PaintButtonClicked(object sender, RoutedEventArgs e)
        {
            paintBoard.buttonType = "Paint";
            Button button = sender as Button;
            button.Background = System.Windows.Media.Brushes.SkyBlue;
        }

        private void PipetteButtonClicked(object sender, RoutedEventArgs e)
        {
            paintBoard.buttonType = "Pipette";
            Button button = sender as Button;
            button.Background = System.Windows.Media.Brushes.SkyBlue;
        }

        private void SquareButtonClicked(object sender, RoutedEventArgs e)
        {
            paintBoard.buttonType = "Square";
            Button button = sender as Button;
            button.Background = System.Windows.Media.Brushes.SkyBlue;
        }

        private void CircleButtonClicked(object sender, RoutedEventArgs e)
        {
            paintBoard.buttonType = "Circle";
            Button button = sender as Button;
            button.Background = System.Windows.Media.Brushes.SkyBlue;
        }

        private void Thickness1ButtonClicked(object sender, RoutedEventArgs e)
        {
            paintBoard.thickness = "1";
            Button button = sender as Button;
            button.Background = System.Windows.Media.Brushes.SkyBlue;
        }

        private void Thickness2ButtonClicked(object sender, RoutedEventArgs e)
        {
            paintBoard.thickness = "2";
            Button button = sender as Button;
            button.Background = System.Windows.Media.Brushes.SkyBlue;
        }

        private void Thickness3ButtonClicked(object sender, RoutedEventArgs e)
        {
            paintBoard.thickness = "3";
            Button button = sender as Button;
            button.Background = System.Windows.Media.Brushes.SkyBlue;
        }

        private void ColorButtonClicked(object sender, RoutedEventArgs e)
        {
            Button colorButton = sender as Button;
            currentColor.Background = colorButton.Background;
        }

        private void MouseButtonClicked(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            button.Background = System.Windows.Media.Brushes.SkyBlue;
        }

        private void ButtonFocusLost(object sender, RoutedEventArgs e)
        {
            paintBoard.buttonType = "Mouse";
            Button button = sender as Button;
            button.Background = System.Windows.Media.Brushes.Transparent;
        }

        private void EraseButtonDoubleClicked(object sender, MouseButtonEventArgs e)
        {
            paintBoard.paintingCanvas.Children.Clear();
        }
    }
}
