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
        AdjustText adjustText;
        private bool isPushed; //연산자가 눌린 바로 다음에 true
        private bool isCalculating; //계산중
        private double frontOperand; //앞쪽 피연산자
        private double backOperand; //뒤쪽 피연산자
        private char op; //연산자
        private double temp = 0;
        private string num; //숫자 버튼 눌렀을 때 저장되는 숫자
        private double previousNum; // 연산자만 눌렀을때 뒤 피연산자
        private double memNum; //이전 연산했을때 가지고 있는 값.

        public CalculatorControl()
        {
            InitializeComponent();
            textResult.Text = "0";
            textResult.FontSize = 60;

            adjustText = new AdjustText();
        }

        //모든 숫자 입력
        private void BtnNum_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;

            num = btn.Name.Remove(0, 3); //맨 앞에서 3글자 삭제

            if (textResult.Text.Contains("0으로"))
                ButtonEnabled(); //0으로 나눌 수 없음으로 인해서 버튼 비활성화 되었을 때 다시 활성화 시키는것.

            if (isPushed == true)
            {
                textResult.Text = num;
                textResult.Text = adjustText.AddComma(textResult.Text); //천단위 콤마
                isPushed = false;
            }

            else if (textResult.Text.IndexOf('.') != -1)
            {
                if (textResult.Text.Length > 20) //최대 숫자 개수보다 더 입력되면 바로 함수 종료
                    return;

                textResult.Text = textResult.Text + num;
                textResult.FontSize = adjustText.AdjustFontSize(textResult.Text);
            }

            else if (double.Parse(textResult.Text) == 0)
            {
                textResult.Text = num;
                return;
            }

            else
            {
                if (textResult.Text.Length > 20)
                    return;

                textResult.Text = textResult.Text + num;
                textResult.Text = adjustText.AddComma(textResult.Text);
                textResult.FontSize = adjustText.AdjustFontSize(textResult.Text); //폰트사이즈 조정
            }
        }

        //CE버튼
        private void BtnCE_Click(object sender, RoutedEventArgs e)
        {
            if (textResult.Text.Contains("0으로"))
                ButtonEnabled();

            if (operatorDisplay.Text.Contains("negate"))
                operatorDisplay.Text = "";

            textResult.Text = "0";
            textResult.FontSize = 60;
        }

        //C버튼
        private void BtnC_Click(object sender, RoutedEventArgs e)
        {
            if (textResult.Text.Contains("0으로"))
                ButtonEnabled();

            InitializeVariables(); //모든 변수 초기화
        }

        //뒤로 지우는 BackSpace버튼
        private void BtnBS_Click(object sender, RoutedEventArgs e)
        {
            if (textResult.Text.Contains("0으로"))
            {
                ButtonEnabled();
                return;
            }
               
            textResult.Text = adjustText.AddComma(textResult.Text.Remove(textResult.Text.Length - 1));

            if (textResult.Text.Length == 0)
                textResult.Text = "0";
        }

        //나눗셈 버튼
        private void BtnDivide_Click(object sender, RoutedEventArgs e)
        {
            if (isPushed)
                return;

            if (isPushed == false && isCalculating == true) //연달아서 계속 연산하는 케이스
            {
                if (double.Parse(textResult.Text) == memNum && memNum == frontOperand)
                    return;

                PreviousCalculate();
                frontOperand = memNum;
                operatorDisplay.Text = operatorDisplay.Text + textResult.Text + " ÷ ";
                textResult.Text = frontOperand.ToString();
                op = '÷';
                return;
            }

            //C눌렀을 때 맨처음 0 상황
            if (frontOperand == 0)
            {
                if (operatorDisplay.Text.Contains("negate") == true)
                {
                    operatorDisplay.Text = operatorDisplay.Text + " ÷ ";
                }
                else
                {
                    frontOperand = Convert.ToDouble(textResult.Text);
                    operatorDisplay.Text = frontOperand.ToString() + " ÷ ";
                    textResult.Text = frontOperand.ToString();
                }
            }

            else
            {
                backOperand = double.Parse(num);
                operatorDisplay.Text = operatorDisplay.Text + backOperand.ToString() + " ÷ ";
                textResult.Text = (frontOperand / backOperand).ToString();
            }

            isPushed = true;
            isCalculating = true;
            op = '÷';
            textResult.Text = adjustText.AddComma(textResult.Text);
            previousNum = double.Parse(textResult.Text);
        }

        //곱셈버튼
        private void BtnMultiply_Click(object sender, RoutedEventArgs e)
        {
            if (isPushed)
                return;

            if (isPushed == false && isCalculating == true)
            {
                if(double.Parse(textResult.Text) == memNum && memNum == frontOperand)
                    return;
                
                PreviousCalculate();
                frontOperand = memNum;
                operatorDisplay.Text = operatorDisplay.Text + textResult.Text + " X ";
                textResult.Text = frontOperand.ToString();
                op = 'X';
                return;
            }

            if (frontOperand == 0)
            {
                if (operatorDisplay.Text.Contains("negate") == true)
                {
                    operatorDisplay.Text = operatorDisplay.Text + " X ";
                }
                else
                {
                    frontOperand = Convert.ToDouble(textResult.Text);
                    operatorDisplay.Text = frontOperand.ToString() + " X ";
                    textResult.Text = frontOperand.ToString();
                }
            }

            else
            {
                backOperand = double.Parse(num);
                operatorDisplay.Text = operatorDisplay.Text + backOperand.ToString() + " X ";
                textResult.Text = (frontOperand * backOperand).ToString();
            }

            isCalculating = true;
            isPushed = true;
            op = 'X';
            textResult.Text = adjustText.AddComma(textResult.Text);
            previousNum = double.Parse(textResult.Text);
        }

        //뺄셈 버튼
        private void BtnMinus_Click(object sender, RoutedEventArgs e)
        {
            if (isPushed)
                return;
          
            if(isPushed == false && isCalculating == true)
            {
                if (double.Parse(textResult.Text) == memNum && memNum == frontOperand)
                    return;
                PreviousCalculate();
                frontOperand = memNum;
                operatorDisplay.Text = operatorDisplay.Text + textResult.Text + " - ";
                textResult.Text = frontOperand.ToString();
                op = '-';
                return;
            }

            if (frontOperand == 0)
            {
                if (operatorDisplay.Text.Contains("negate") == true)
                {
                    operatorDisplay.Text = operatorDisplay.Text + " - ";
                }
                else
                {
                    frontOperand = Convert.ToDouble(textResult.Text);
                    operatorDisplay.Text = frontOperand.ToString() + " - ";
                }
            }

            else
            {
                frontOperand = previousNum;
                backOperand = double.Parse(textResult.Text);
                operatorDisplay.Text = operatorDisplay.Text + backOperand.ToString() + " - ";
            }

            isCalculating = true;
            isPushed = true;
            op = '-';
            textResult.Text = (frontOperand - backOperand).ToString();
            textResult.Text = adjustText.AddComma(textResult.Text);
            previousNum = double.Parse(textResult.Text);
        }


        //더하기 버튼
        private void BtnPlus_Click(object sender, RoutedEventArgs e)
        {
            if(isPushed)
                return;

            if (isPushed == false && isCalculating == true)
            {
                if (double.Parse(textResult.Text) == memNum && memNum == frontOperand)
                    return;
                PreviousCalculate();
                frontOperand = memNum;
                operatorDisplay.Text = operatorDisplay.Text + textResult.Text + " + ";
                textResult.Text = frontOperand.ToString();
                op = '+';
                return;
            }

            if (frontOperand == 0)
            {
                if (operatorDisplay.Text.Contains("negate") == true)
                {
                    operatorDisplay.Text = operatorDisplay.Text + " + ";
                }
                else
                {
                    frontOperand = Convert.ToDouble(textResult.Text);
                    operatorDisplay.Text = frontOperand.ToString() + " + ";
                }
            }

            else
            {
                frontOperand = previousNum;
                backOperand = double.Parse(textResult.Text);
                operatorDisplay.Text = operatorDisplay.Text + backOperand.ToString() + " + ";
            }

            isCalculating = true;
            isPushed = true;
            op = '+';
            textResult.Text = (frontOperand + backOperand).ToString();
            textResult.Text = adjustText.AddComma(textResult.Text);
            previousNum = double.Parse(textResult.Text);
        }

        //소수점버튼
        private void BtnDot_Click(object sender, RoutedEventArgs e)
        {
            if (isPushed == true || double.Parse(textResult.Text) == 0)
            {
                textResult.Text = "0.";
                isPushed = false;
            }

            else if (double.Parse(textResult.Text) == (int)(double.Parse(textResult.Text))) //정수라면
            {
                textResult.Text = textResult.Text.ToString() + ".";
                textResult.Text = adjustText.AddComma(textResult.Text);
            }
        }

        //negate버튼
        private void BtnPlusMinus_Click(object sender, RoutedEventArgs e)
        {
            if (operatorDisplay.Text.Contains("negate"))
                operatorDisplay.Text = "negate(" + operatorDisplay.Text + ")";

            if (operatorDisplay.Text == "" && textResult.Text== "0")
                operatorDisplay.Text = "negate(" + textResult.Text + ")";

            textResult.Text = (-double.Parse(textResult.Text)).ToString();
            textResult.Text = adjustText.AddComma(textResult.Text);
        }

        //= 버튼
        private void BtnEqual_Click(object sender, RoutedEventArgs e)
        {
            if (textResult.Text.Equals("0."))
            {
                textResult.Text = "0";
                return;
            }

            if (textResult.Text.Equals("0으로 나눌 수 없습니다."))
            {
                ButtonEnabled();
                textResult.Text = "0";
                operatorDisplay.Text = "";
                return;
            }

            if (isCalculating == false)
            {
                backOperand = temp;
                frontOperand = double.Parse(textResult.Text);
            }

            if (isCalculating == true)
            {
                backOperand = double.Parse(textResult.Text);
            }

            switch (op)
            {
                case '+':
                    if (operatorDisplay.Text.Length > 21 && operatorDisplay.Text.Contains("negate") == false)
                    {
                        textResult.Text = (backOperand + double.Parse(textResult.Text)).ToString();
                        break;
                    }
                    if (isCalculating == false)
                        textResult.Text = (frontOperand + backOperand).ToString();
                    else if (isCalculating == true && isPushed == false)
                        textResult.Text = (frontOperand + backOperand).ToString();
                    else
                        textResult.Text = (previousNum + backOperand).ToString();
                    break;

                case '-':
                    if (operatorDisplay.Text.Length > 21 && operatorDisplay.Text.Contains("negate") == false)
                    {
                        textResult.Text = (backOperand - double.Parse(textResult.Text)).ToString();
                        break;
                    }
                    if (isCalculating == false)
                        textResult.Text = (frontOperand - backOperand).ToString();
                    else if (isCalculating == true && isPushed == false)
                        textResult.Text = (frontOperand - backOperand).ToString();
                    else
                        textResult.Text = (previousNum - backOperand).ToString();
                    break;

                case 'X':
                    if (operatorDisplay.Text.Length > 21 && operatorDisplay.Text.Contains("negate") == false)
                    {
                        textResult.Text = (backOperand * double.Parse(textResult.Text)).ToString();
                        break;
                    }
                    if (isCalculating == false)
                        textResult.Text = (frontOperand * backOperand).ToString();
                    else if (isCalculating == true && isPushed == false)
                        textResult.Text = (frontOperand * backOperand).ToString();
                    else
                        textResult.Text = (previousNum * backOperand).ToString();
                    break;

                case '÷':
                    if (backOperand == 0)
                    {
                        textResult.Text = "0으로 나눌 수 없습니다.";
                        ButtonDisabled();
                        textResult.FontSize = 40;
                        return;
                    }

                    if (operatorDisplay.Text.Length > 21 && operatorDisplay.Text.Contains("negate") == false)
                    {
                        textResult.Text = (backOperand * double.Parse(textResult.Text)).ToString();
                        break;
                    }
                    if (isCalculating == false)
                        textResult.Text = (frontOperand / backOperand).ToString();
                    else if (isCalculating == true && isPushed == false)
                        textResult.Text = (frontOperand / backOperand).ToString();
                    else
                        textResult.Text = (previousNum / backOperand).ToString();
                    break;
            }

            isCalculating = false;
            operatorDisplay.Text = "";
            isPushed = true;
            textResult.Text = adjustText.AddComma(textResult.Text);
            textResult.FontSize = adjustText.AdjustFontSize(textResult.Text);
            temp = backOperand;
        }

        public void ButtonDisabled()
        {
            BtnPlus.IsEnabled = false;
            BtnMinus.IsEnabled = false;
            BtnPlusMinus.IsEnabled = false;
            BtnMultiply.IsEnabled = false;
            BtnDivide.IsEnabled = false;
            BtnDot.IsEnabled = false;
        }

        public void ButtonEnabled()
        {
            BtnPlus.IsEnabled = true;
            BtnMinus.IsEnabled = true;
            BtnPlusMinus.IsEnabled = true;
            BtnMultiply.IsEnabled = true;
            BtnDivide.IsEnabled = true;
            BtnDot.IsEnabled = true;
            InitializeVariables();
        }

        public void InitializeVariables()
        {
            textResult.Text = "0";
            operatorDisplay.Text = "";
            textResult.FontSize = 60;
            frontOperand = 0;
            backOperand = 0;
            num = "0";
            previousNum = 0;
            isPushed = false;
            isCalculating = false;
        }

        //연달아 계산할때 이전 계산하는 메소드
        private void PreviousCalculate()
        {
            switch(op)
            {
                case '+':
                    memNum = frontOperand + double.Parse(textResult.Text);
                    break;

                case '-':
                    memNum = frontOperand - double.Parse(textResult.Text);
                    break;

                case 'X':
                    memNum = frontOperand * double.Parse(textResult.Text);
                    break;

                case '÷':
                    memNum = frontOperand / double.Parse(textResult.Text);
                    break;
            }
        }
    }
}
