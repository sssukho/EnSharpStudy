﻿using System;
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
        private string num;
        private double previousNum; // 연산자만 눌렀을때 뒤 피연산자

        //negate
        public CalculatorControl()
        {
            InitializeComponent();
            textResult.Text = "0";
            textResult.FontSize = 60;
            
            adjustText = new AdjustText();
        }

        private void BtnNum_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;

            num = btn.Name.Remove(0, 3); //맨 앞에서 3글자 삭제

            if (isPushed == true)
            {
                textResult.Text = num;
                textResult.Text = adjustText.AddComma(textResult.Text);
                isPushed = false;
            }

            else if (textResult.Text.IndexOf('.') != -1)
            {
                if (textResult.Text.Length > 20)
                    return;

                textResult.Text = textResult.Text + num;
                textResult.FontSize = adjustText.AdjustFontSize(textResult.Text);
            }

            else if (double.Parse(textResult.Text) == 0)
            {
                textResult.Text = num;
            }

            else
            {
                if (textResult.Text.Length > 20)
                    return;

                textResult.Text = textResult.Text + num;
                textResult.Text = adjustText.AddComma(textResult.Text);
                textResult.FontSize = adjustText.AdjustFontSize(textResult.Text);
            }
        }

        private void BtnCE_Click(object sender, RoutedEventArgs e)
        {
            textResult.Text = "0";
            textResult.FontSize = 60;
        }

        private void BtnC_Click(object sender, RoutedEventArgs e)
        {
            textResult.Text = "0";
            operatorDisplay.Text = "";
            textResult.FontSize = 60;
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
            operatorDisplay.Text = frontOperand.ToString() + " ÷ ";
            
        }

        private void BtnMultiply_Click(object sender, RoutedEventArgs e)
        {
            frontOperand = Convert.ToDouble(textResult.Text);
            isCalculating = true;
            isPushed = true;
            op = 'X';
            operatorDisplay.Text = frontOperand.ToString() + " X ";
        }

        private void BtnMinus_Click(object sender, RoutedEventArgs e)
        {
            frontOperand = Convert.ToDouble(textResult.Text);
            isCalculating = true;
            isPushed = true;
            op = '-';
            operatorDisplay.Text = frontOperand.ToString() + " - ";
        }

        private void BtnPlus_Click(object sender, RoutedEventArgs e)
        {
            if(frontOperand == 0)
            {
                frontOperand = Convert.ToDouble(textResult.Text);
                operatorDisplay.Text = frontOperand.ToString() + " + ";
            }        

            else
            {
                frontOperand = previousNum;
                backOperand = double.Parse(num);
                operatorDisplay.Text = operatorDisplay.Text + backOperand.ToString() + " + ";
            }

            isCalculating = true;
            isPushed = true;
            op = '+';
            textResult.Text = (frontOperand + backOperand).ToString();
            previousNum = double.Parse(textResult.Text);
        }

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
            }
        }

        private void BtnPlusMinus_Click(object sender, RoutedEventArgs e)
        {
            if (operatorDisplay.Text.Contains("negate"))
                operatorDisplay.Text = "negate(" + operatorDisplay.Text + ")";

            if (operatorDisplay.Text == "")
                operatorDisplay.Text = "negate(" + textResult.Text + ")";

            textResult.Text = (-double.Parse(textResult.Text)).ToString();
        }

        private void BtnEqual_Click(object sender, RoutedEventArgs e)
        {
            if (textResult.Text.Equals("0."))
            {
                textResult.Text = "0";
                return;
            }

            if(textResult.Text.Equals("0으로 나눌 수 없습니다."))
            {
                textResult.Text = "0";
                operatorDisplay.Text = "";
                return;
            }

            if (isCalculating == false)
            {
                backOperand = temp;
                frontOperand = double.Parse(textResult.Text);
                //isCalculating = true;
            }

            if (isCalculating == true)
            {
                backOperand = double.Parse(textResult.Text);
            }

            switch (op)
            {
                case '+':
                    if(operatorDisplay.Text.Length > 3)
                    {
                        textResult.Text = (backOperand + double.Parse(textResult.Text)).ToString();
                        break;
                    }
                    textResult.Text = (frontOperand + backOperand).ToString();
                    break;
                case '-':
                    if (operatorDisplay.Text.Length > 3)
                    {
                        textResult.Text = (backOperand + double.Parse(textResult.Text)).ToString();
                        break;
                    }
                    textResult.Text = (frontOperand - backOperand).ToString();
                    break;
                case 'X':
                    if (operatorDisplay.Text.Length > 3)
                    {
                        textResult.Text = (backOperand + double.Parse(textResult.Text)).ToString();
                        break;
                    }
                    textResult.Text = (frontOperand * backOperand).ToString();
                    break;
                case '÷':
                    if (backOperand == 0)
                    {
                        textResult.Text = "0으로 나눌 수 없습니다.";
                        textResult.FontSize = 40;
                        return;
                    }
                    textResult.Text = (frontOperand / backOperand).ToString();
                    break;
            }

            isCalculating = false;
            operatorDisplay.Text = "";
            isPushed = true;
            textResult.Text = adjustText.AddComma(textResult.Text);
            textResult.FontSize = adjustText.AdjustFontSize(textResult.Text);
            temp = backOperand;
        }
    }
}
