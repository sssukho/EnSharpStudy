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

namespace Calculator
{
    /// <summary>
    /// CalculatorControl.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class CalculatorControl : UserControl
    {
        private bool isPushed; //연산자가 눌린 바로 다음에 true
        private bool isCalculating; //계산중
        private bool isMemorySaved; //memory save 바로 다음에 true
        private double memoryNumber; //기억하고 있는 숫자
        private double frontOperand; //앞쪽 피연산자
        private double backOperand; //뒤쪽 피연산자
        private char op; //연산자

        public CalculatorControl()
        {
            InitializeComponent();
            textResult.Text = "0";

            textResult.FontSize = 20;
        }

        private void BtnNum_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;

            String num = btn.Name.Remove(0, 3);
            
            if(isPushed == true || isMemorySaved == true)
            {
                textResult.Text = num;
                isPushed = false;
                isMemorySaved = false;
            }

            else if(textResult.Text.IndexOf('.') != -1)
            {
                textResult.Text = textResult + num;
            }

            else if (double.Parse(textResult.Text) == 0)
            {
                textResult.Text = num;
            }
            else
            {
                textResult.Text = textResult.Text + num;
            }
        }

        private void BtnCE_Click(object sender, RoutedEventArgs e)
        {
            textResult.Text = "0";
        }

        private void BtnC_Click(object sender, RoutedEventArgs e)
        {
            textResult.Text = "0";
            operatorDisplay.Text = "";
            frontOperand = 0;
            backOperand = 0;
            isPushed = false;
            isCalculating = false;
        }

        private void BtnBS_Click(object sender, RoutedEventArgs e)
        {
            textResult.Text = textResult.Text.Remove(textResult.Text.Length - 1);
            if (textResult.Text.Length == 0)
                textResult.Text = "0";
        }

        private void BtnDivide_Click(object sender, RoutedEventArgs e)
        {
            frontOperand = Convert.ToDouble(textResult.Text);
            isPushed = true;
            isCalculating = true;
            op = '÷';
            operatorDisplay.Text = frontOperand.ToString() + " ÷";
        }

        private void BtnTimes_Click(object sender, RoutedEventArgs e)
        {
            frontOperand = Convert.ToDouble(textResult.Text);
            isCalculating = true;
            isPushed = true;
            op = 'X';
            operatorDisplay.Text = frontOperand.ToString() + " X";
        }

        private void BtnMinus_Click(object sender, RoutedEventArgs e)
        {
            frontOperand = Convert.ToDouble(textResult.Text);
            isCalculating = true;
            isPushed = true;
            op = '-';
            operatorDisplay.Text = frontOperand.ToString() + " -";
        }

        private void BtnPlus_Click(object sender, RoutedEventArgs e)
        {
            frontOperand = Convert.ToDouble(textResult.Text);
            isCalculating = true;
            isPushed = true;
            op = '+';
            operatorDisplay.Text = frontOperand.ToString() + " +";
        }

        private void BtnDot_Click(object sender, RoutedEventArgs e)
        {
            frontOperand = Convert.ToDouble(textResult.Text);
            isCalculating = true;
            isPushed = true;
            op = '.';

            if(isPushed == true || double.Parse(textResult.Text) == 0)
            {
                textResult.Text = "0,";
                isPushed = false;
            }

            else if(double.Parse(textResult.Text) == (int)(double.Parse(textResult.Text)))
            {
                textResult.Text = textResult.Text + ".";
            }
        }

        private void BtnEqual_Click(object sender, RoutedEventArgs e)
        {
            if(isCalculating == true)
            {
                backOperand = double.Parse(textResult.Text);
                switch(op)
                {
                    case '+':
                        textResult.Text = (frontOperand + backOperand).ToString();
                        break;
                    case '-':
                        textResult.Text = (frontOperand - backOperand).ToString();
                        break;
                    case 'X':
                        textResult.Text = (frontOperand * backOperand).ToString();
                        break;
                    case '÷':
                        textResult.Text = (frontOperand / backOperand).ToString();
                        break;
                }
                operatorDisplay.Text = "";
                isPushed = true;
            }
        }
    }
}
