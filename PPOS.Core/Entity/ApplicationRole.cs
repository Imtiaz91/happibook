using System;
using System.Collections.Generic;
using Microsoft.AspNet.Identity.EntityFramework;
using Recipe.Core.Base.Interface;

namespace Happibook.Core.Entity
{
    public class ApplicationRole : IdentityRole<string, ApplicationUserRole>, IAuditModel<string>
    {
        public ApplicationRole()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public int? RoleCategoryId { get; set; }

        public RoleCategory RoleCategory { get; set; }

        public string CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        public bool IsDeleted { get; set; }

        public string LastModifiedBy { get; set; }

        public DateTime LastModifiedOn { get; set; }
    }
}
