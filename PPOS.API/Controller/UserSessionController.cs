using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Happibook.Core.Attribute;
using Happibook.Core.DTO;
using Happibook.Core.Entity;
using Happibook.Core.IService;
using Recipe.Core.Base.Generic;

namespace Happibook.API.Controller
{
    [CustomAuthorize]
    [RoutePrefix("UserSession")]
    public class UserSessionController : Controller<IUserSessionService, UserSessionDTO, UserSession, int>
    {
        public UserSessionController(IUserSessionService service)
            : base(service)
        {
        }
    }
}
