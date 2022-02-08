using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using Happibook.API.Infrastructure;
using Happibook.Core.Attribute;
using Happibook.Core.Constant;
using Happibook.Core.IService;
using Recipe.Common.Helper;

namespace Happibook.API.Controller
{
    [CustomAuthorize]
    [RoutePrefix("Audit")]
    public class AuditController : Recipe.Core.Base.Generic.Controller
    {
        private IAuditService auditService;

        public AuditController(IAuditService auditService)
        {
            this.auditService = auditService;
        }

        [Route("Get")]
        public async Task<ResponseMessageResult> Get()
        {
            var request = Request.GetJsonApiRequest();
            var result = await this.auditService.GetAllAsync(request);
            if (result != null)
            {
                return await this.JsonApiSuccessAsync(Message.SuccessResult, result);
            }

            return await this.JsonApiNoContentAsync(Message.NoContent, null);
        }

        [Route("Get/{id}")]
        public async Task<ResponseMessageResult> GetById(int id)
        {
            var result = await this.auditService.GetAsync(id);
            if (result != null)
            {
                return await this.JsonApiSuccessAsync(Message.SuccessResult, result);
            }

            return await this.JsonApiNoContentAsync(Message.NoContent, null);
        }
    }
}
