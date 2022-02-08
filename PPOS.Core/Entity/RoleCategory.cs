using System;
using System.Collections.Generic;
using Microsoft.AspNet.Identity.EntityFramework;
using Recipe.Core.Base.Abstract;
using Recipe.Core.Base.Interface;

namespace Happibook.Core.Entity
{
    public class RoleCategory : EntityBase<int>
    {
        public RoleCategory()
        {
        }

        public string Name { get; set; }

        public bool Active { get; set; }

        public virtual IList<ApplicationRole> ApplicationRole { get; set; }
    }
}
