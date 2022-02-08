using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Recipe.Core.Base.Abstract;

namespace Happibook.Core.Entity
{
   public class Currency : EntityBase<int>
    {
        public Currency()
        {
        }   
        
        public string Name { get; set; }

        public string IsoCode { get; set; }

        public string Symbol { get; set; }

        public string Fraction { get; set; }

        public double Rate { get; set; }

        public double FractionUnit { get; set; }

        public int DecimalPlace { get; set; }

        public virtual Country Country { get; set; }

        public int CountryId { get; set; }

        public bool Active { get; set; }

        public IList<Setting> Company { get; set; }
    }
}