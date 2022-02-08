using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Recipe.Core.Base.Abstract;

namespace Happibook.Core.Entity
{
    public class Setting : EntityBase<int>
    {
        public string Code { get; set; }

        public string SiteName { get; set; }

        public string Slogan { get; set; }

        public string NTNNumber { get; set; }

        public string OwnerName { get; set; }

        public virtual Currency Currency { get; set; }

        public int? CurrencyId { get; set; }

        public string ContactNumber1 { get; set; }

        public string ContactNumber2 { get; set; }

        public string FaxNumber { get; set; }

        public string Email { get; set; }

        public string Website { get; set; }

        public virtual Country Country { get; set; }

        public int? CountryId { get; set; }

        public int PostalCode { get; set; }

        public string Address { get; set; }

        public string SiteLogo { get; set; }
    }
}
