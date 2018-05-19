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
        private double frontOperand; //앞쪽 피연산자
        private double backOperand; //뒤쪽 피연산자
        private char op; //연산자


        //예외1, numberDisplay 요소 글씨 못쓰게 할 것.
        //예외2. 100단위로 콤마
        //예외3. 글자 10개부터 폰트 작아짐
        //예외4. 소수점찍고 = 누르면 소수점은 없어지고 숫자만 그대로
        //예외5. 

        public CalculatorControl()
        {
            InitializeComponent();
            textResult.Text = "0";

            textResult.FontSize = 60;
        }

        private void BtnNum_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;

            String num = btn.Name.Remove(0, 3); //맨 앞에서 3글자 삭제
            
            if(isPushed == true)
            {
                textResult.Text = num;
                isPushed = false;
            }

            else if(textResult.Text.IndexOf('.') != -1)
            {
                textResult.Text = textResult.Text + num;
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
            if(isPushed == true || double.Parse(textResult.Text) == 0)
            {
                textResult.Text = "0.";
                isPushed = false;
            }

            else if(double.Parse(textResult.Text) == (int)(double.Parse(textResult.Text))) //정수라면
            {
                textResult.Text = textResult.Text.ToString() + ".";
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
