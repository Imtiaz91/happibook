using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Happibook.Core.Constant
{
    public class GLTrans
    {
        public int CodeCombinationId { get; set; }

        public string AccountCode { get; set; }

        public int CurrencyId { get; set; }

        public double CurrencyRate { get; set; }

        public double TotalAmount { get; set; }

        public int TransactionTypecode { get; set; }

        public string TransactionType { get; set; }
    }
}
