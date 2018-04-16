using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManage
{
    class CancelKey
    {
        private static CancelKey cancel;

        private CancelKey() { }

        public static CancelKey GetInstance()
        {
            if (cancel == null) cancel = new CancelKey();
            return cancel;
        }

        public void Cancel()
        {
            string result = null;

            StringBuilder buffer = new StringBuilder();

        }
    }
}
