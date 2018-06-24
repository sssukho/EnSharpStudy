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
    /// PaintBoard.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class PaintBoard : UserControl
    {
        public ButtonMenu buttonMenu;
        public string buttonType = null;
        public Point currentPoint;
        public string thickness;
        public Rectangle selectPreviousRectangle;
        public Rectangle previousRectangle;
        public Ellipse previousEllipse;

        public PaintBoard(ButtonMenu buttonMenu)
        {
            InitializeComponent();
            this.buttonMenu = buttonMenu;
            this.buttonMenu.paintBoard = this;
            currentPoint = new Point();
            paintingCanvas.Background = System.Windows.Media.Brushes.White;
        }

        private void CanvasMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ButtonState == MouseButtonState.Pressed)
                currentPoint = e.GetPosition(this);
        }

        private void CanvasMouseMove(object sender, MouseEventArgs e)
        { 
            if (buttonType == null)
                return;

            if (e.LeftButton == MouseButtonState.Pressed)
            {
                switch(buttonType)
                {
                    case "Select":
                        DrawWithSelect(e);
                        break;

                    case "Pencil":
                        DrawWithPencil(e);
                        break;

                    case "Square":
                        DrawWithSquare(e);
                        break;

                    case "Circle":
                        DrawWithCircle(e);
                        break;
                }
            }
        }

        private void MouseSelect(object shape)
        {
            if(shape is Rectangle)
            {
                Rectangle rectangle = shape as Rectangle;
                rectangle.StrokeDashArray = new DoubleCollection() { 1 };
            }
        }

        private void DrawWithSelect(MouseEventArgs e)
        {
            if(e.MouseDevice.LeftButton == MouseButtonState.Pressed)
            {
                Rectangle selectRectangle = new Rectangle();
                selectRectangle.Stroke = new SolidColorBrush(Colors.Black);
                selectRectangle.StrokeThickness = 2;
                selectRectangle.Opacity = 0.7;
                selectRectangle.StrokeDashArray = new DoubleCollection() { 1 };
                selectRectangle.Fill = Brushes.Transparent;

                double left = currentPoint.X;
                double top = currentPoint.Y;

                if(e.GetPosition(this).X < currentPoint.X)
                    left = e.GetPosition(this).X;

                if (e.GetPosition(this).Y < currentPoint.Y)
                    top = e.GetPosition(this).Y;

                selectRectangle.Margin = new Thickness(left, top, 0, 0);
                selectRectangle.Width = Math.Abs(e.GetPosition(this).X - currentPoint.X);
                selectRectangle.Height = Math.Abs(e.GetPosition(this).Y - currentPoint.Y);

                paintingCanvas.Children.Remove(selectPreviousRectangle);
                selectPreviousRectangle = selectRectangle;
                paintingCanvas.Children.Add(selectRectangle);
            }
            else
            {
                if (selectPreviousRectangle == null) 
                    return;
                
                Rectangle rectangle = new Rectangle();
                selectPreviousRectangle.StrokeDashArray = null;
                rectangle = selectPreviousRectangle;
                selectPreviousRectangle = null;
            }
        }

        private void DrawWithErase(MouseEventArgs e)
        {
            Line line = new Line();

            switch (thickness)
            {
                case "1":
                    line.StrokeThickness = 1;
                    break;

                case "2":
                    line.StrokeThickness = 5;
                    break;

                case "3":
                    line.StrokeThickness = 10;
                    break;
            }

            line.Stroke = new SolidColorBrush(Colors.White);
            line.X1 = currentPoint.X;
            line.Y1 = currentPoint.Y;
            line.X2 = e.GetPosition(this).X;
            line.Y2 = e.GetPosition(this).Y;

            currentPoint = e.GetPosition(this);
            paintingCanvas.Children.Add(line);
        }

        private void DrawWithPaint(object shape)
        {
            if(shape is Rectangle)
            {
                Rectangle rectangle = shape as Rectangle;
                rectangle.Fill = buttonMenu.currentColor.Background;
            }

            else if(shape is Ellipse)
            {
                Ellipse ellipse = shape as Ellipse;
                ellipse.Fill = buttonMenu.currentColor.Background;
            }

            else
            {
                return;
            }
        }

        private void DrawWithPipette(object shape)
        {
            if (shape is Rectangle)
                buttonMenu.currentColor.Background = ((Rectangle)shape).Fill;

            else if (shape is Ellipse)
                buttonMenu.currentColor.Background = ((Ellipse)shape).Fill;
        }

        private void DrawWithSquare(MouseEventArgs e)
        {
            if (e.MouseDevice.LeftButton == MouseButtonState.Pressed)
            {
                Rectangle rectangle = new Rectangle();

                double left = currentPoint.X;
                double top = currentPoint.Y;

                if (e.GetPosition(this).X < currentPoint.X)
                    left = e.GetPosition(this).X;

                if (e.GetPosition(this).Y < currentPoint.Y)
                    top = e.GetPosition(this).Y;

                rectangle.StrokeThickness = 2;
                rectangle.Margin = new Thickness(left, top, 0, 0);
                rectangle.Width = Math.Abs(e.GetPosition(this).X - currentPoint.X);
                rectangle.Height = Math.Abs(e.GetPosition(this).Y - currentPoint.Y);
                rectangle.Stroke = buttonMenu.currentColor.Background;
                rectangle.Fill = Brushes.Transparent;

                paintingCanvas.Children.Remove(previousRectangle);
                previousRectangle = rectangle;
                paintingCanvas.Children.Add(rectangle);
                rectangle.MouseLeftButtonUp += Rectangle_MouseLeftButtonUp;
            }
        }

        private void Rectangle_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            previousRectangle = null;
            if (buttonType.Equals("Paint"))
                DrawWithPaint(sender);

            else if (buttonType.Equals("Pipette"))
                DrawWithPipette(sender);

            else if (buttonType.Equals("Mouse"))
                MouseSelect(sender);
        }

        private void DrawWithCircle(MouseEventArgs e)
        {
            if (e.MouseDevice.LeftButton == MouseButtonState.Pressed)
            {
                Ellipse ellipse = new Ellipse();

                double left = currentPoint.X;
                double top = currentPoint.Y;

                if (e.GetPosition(this).X < currentPoint.X)
                    left = e.GetPosition(this).X;

                if (e.GetPosition(this).Y < currentPoint.Y)
                    top = e.GetPosition(this).Y;

                ellipse.StrokeThickness = 2;
                ellipse.Margin = new Thickness(left, top, 0, 0);
                ellipse.Width = Math.Abs(e.GetPosition(this).X - currentPoint.X);
                ellipse.Height = Math.Abs(e.GetPosition(this).Y - currentPoint.Y);
                ellipse.Stroke = buttonMenu.currentColor.Background;
                ellipse.Fill = Brushes.Transparent;

                paintingCanvas.Children.Remove(previousEllipse);
                previousEllipse = ellipse;
                paintingCanvas.Children.Add(ellipse);
                MouseLeftButtonUp += PaintBoard_MouseLeftButtonUp;
            }
        }

        private void PaintBoard_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            previousEllipse = null;
            if (buttonType.Equals("Paint") && e.OriginalSource is Ellipse)
                DrawWithPaint(e.OriginalSource);

            else if (buttonType.Equals("Pipette") && e.OriginalSource is Ellipse)
                DrawWithPipette(e.OriginalSource);

            else if (buttonType.Equals("Mouse") && e.OriginalSource is Ellipse)
                MouseSelect(e.OriginalSource);
        }

        private void DrawWithPencil(MouseEventArgs e)
        {
            Line line = new Line();

            switch(thickness)
            {
                case "1":
                    line.StrokeThickness = 1;
                    break;

                case "2":
                    line.StrokeThickness = 5;
                    break;

                case "3":
                    line.StrokeThickness = 10;
                    break;
            }

            line.Stroke = buttonMenu.currentColor.Background;
            line.X1 = currentPoint.X;
            line.Y1 = currentPoint.Y;
            line.X2 = e.GetPosition(this).X;
            line.Y2 = e.GetPosition(this).Y;

            currentPoint = e.GetPosition(this);
            paintingCanvas.Children.Add(line);
        }
    }
}
