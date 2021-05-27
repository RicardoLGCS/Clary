using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clary
{
    class Memo
    {
        public string sMemoTitle, sMemoDate;

        string MemoTitle
        {
            set { sMemoTitle = value; }
            get { return sMemoTitle; }
        }

        string MemoDate
        {
            set { sMemoDate = value; }
            get { return sMemoDate; }
        }
    }
}
