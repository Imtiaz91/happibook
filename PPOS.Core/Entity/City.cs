using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Recipe.Core.Base.Abstract;

namespace Happibook.Core.Entity
{
   public class City : EntityBase<int>
    {
        public City()
        {
        }   
        
        public string Name { get; set; }

        public int? StateId { get; set; }

        public bool Active { get; set; }

       // public virtual IList<HrmEmployee> HrmEmployee { get; set; }

      public virtual IList<Setting> Company { get; set; }
 }
}