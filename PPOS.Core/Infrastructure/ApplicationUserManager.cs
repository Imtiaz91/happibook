using System;
using Happibook.Core.Entity;
using Microsoft.AspNet.Identity;

namespace Happibook.Core.Infrastructure
{
    public class ApplicationUserManager : UserManager<ApplicationUser, string>
    {
        public ApplicationUserManager(ApplicationUserStore userStore) : base(userStore)
        {
            this.MaxFailedAccessAttemptsBeforeLockout = 3;
            this.DefaultAccountLockoutTimeSpan = TimeSpan.FromDays(365 * 100);
        }
    }
}
