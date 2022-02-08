using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Recipe.Core.Base.Abstract;

namespace Happibook.Core.Entity
{
    public class Country : EntityBase<int>
    {
        public Country()
        {
        }

        public string Name { get; set; }

        public bool Active { get; set; }

        public virtual IList<Setting> Company { get; set; }

        public virtual IList<Currency> Currency { get; set; }
    }
}
