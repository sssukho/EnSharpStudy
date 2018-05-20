using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class AdjustText
    {
        public AdjustText() { }

        public string AddComma(string inputText)
        {
            if(inputText.Contains("E")) //자연상수
                return inputText;

            if (inputText.Equals("0"))
                return inputText;
            
            inputText = inputText.Replace(",", "");
            inputText = string.Format("{0:#,###,###,###,###,###}", Convert.ToDouble(inputText));
            return inputText;
        }

        public int AdjustFontSize(string inputText)
        {
            switch (inputText.Length)
            {
                case 21:
                    return 39;

                case 20:
                    return 42;

                case 19:
                    return 45;

                case 18:
                    return 48;

                case 17:
                    return 51;

                case 16:
                    return 54;

                case 15:
                    return 57;
            }
            return 60;
        }
    }
}
