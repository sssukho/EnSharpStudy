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

            if (inputText.Contains("."))
                return inputText;

            if (inputText.Equals(""))
                return "0";

            inputText = inputText.Replace(",", "");
            inputText = string.Format("{0:#,###,###,###,###,###}", Convert.ToDouble(inputText));
            return inputText;
        }

        public int AdjustFontSize(string inputText)
        {
            switch (inputText.Length)
            {
                case 21:
                    return 32;

                case 20:
                    return 36;

                case 19:
                    return 40;

                case 18:
                    return 44;

                case 17:
                    return 48;

                case 16:
                    return 52;

                case 15:
                    return 56;
            }
            return 60;
        }
    }
}
