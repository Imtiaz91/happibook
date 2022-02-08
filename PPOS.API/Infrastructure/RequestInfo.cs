using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Web;
using Happibook.Core.Constant;
using Happibook.Core.DBContext;
using Happibook.Core.Enum;
using Happibook.Core.Infrastructure;

namespace Happibook.API.Infrastructure
{
    public class RequestInfo : ISSHRequestInfo
    {
        private const string ApplicationConfigContextKey = "ApplicationConfigContext";
        private Dictionary<int, HappibookContext> threadContexts = new Dictionary<int, HappibookContext>();

        public RequestInfo()
        {
        }

        public string UserId
        {
            get
            {
                if (string.IsNullOrEmpty(this.GetValueFromClaims(General.ClaimsUserId)))
                {
                    return null;
                }

                return this.GetValueFromClaims(General.ClaimsUserId);
            }
        }

        public string UserName
        {
            get
            {
                return this.GetValueFromClaims(General.ClaimsUserName);
            }
        }

        public DbContext Context
        {
            get
            {
                HappibookContext context;

                if (HttpContext.Current != null && HttpContext.Current.Items != null && HttpContext.Current.Items.Contains(ApplicationConfigContextKey))
                {
                    context = (HappibookContext)HttpContext.Current.Items[ApplicationConfigContextKey];
                }
                else
                {
                    context = new HappibookContext();
                    if (HttpContext.Current != null)
                    {
                        HttpContext.Current.Items[ApplicationConfigContextKey] = context;
                    }
                }

                return context;
            }

            set
            {
                HttpContext.Current.Items[ApplicationConfigContextKey] = value;
            }
        }

        public string Role
        {
            get
            {
                return this.GetValueFromClaims(ClaimTypes.Role);
            }
        }

        public UserRoles UserRole
        {
            get
            {
                return Roles.GetRoleObject(Roles.GetRoleId(this.Role));
            }
        }

        #region Private Funcltions
        private string GetValueFromClaims(string key)
        {
            if (HttpContext.Current == null || HttpContext.Current.User == null || HttpContext.Current.User.Identity == null)
            {
                return string.Empty;
            }

            var claims = (HttpContext.Current.User.Identity as ClaimsIdentity).Claims;
            var value = string.Empty;

            if (claims != null && claims.Count() > 0)
            {
                value = claims.FirstOrDefault(x => x.Type == key).Value;
            }

            return value;
        }
        #endregion
    }
}
