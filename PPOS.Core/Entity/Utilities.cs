using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Recipe.Core.Base.Abstract;

namespace Happibook.Core.Entity
{
    public class Utilities : EntityBase<int>
    {
        public Utilities()
        {
        }

        public string Name { get; set; }
    }
}
