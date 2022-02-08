using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using Happibook.API.Infrastructure;
using Happibook.Common.Attribute;
using Happibook.Core.Attribute;
using Happibook.Core.Constant;
using Happibook.Core.DTO;
using Happibook.Core.Entity;
using Happibook.Core.Enum;
using Happibook.Core.IService;
using Recipe.Common.Helper;
using Recipe.Core.Base.Generic;

namespace Happibook.API.Controller
{
    [CustomAuthorize]
    [RoutePrefix("User")]
    public class UserController : Controller<IUserService, UserDTO, ApplicationUser, string>
    {
        public UserController(IUserService service)
            : base(service)
        {
        }
        
        [HttpGet]
        [Route("Get")]
        public async Task<ResponseMessageResult> GetAllUsers(string search = null)
        {
            var request = Request.GetJsonApiRequest();
            var result = await this.Service.GetAllUserUpdateAsync(request, search);
            if (result != null)
            {
                return await this.JsonApiSuccessAsync(Message.SuccessResult, result);
            }

            return await this.JsonApiNoContentAsync(Message.NoContent, null);
        }
        
        [HttpGet]
        [Route("GetSingle")]
        public async Task<ResponseMessageResult> GetSingleUser(string id)
        {
            var result = await this.Get(id);
            if (result != null)
            {
                return await this.JsonApiSuccessAsync(Message.SuccessResult, result);
            }

            return await this.JsonApiNoContentAsync(Message.NoContent, null);
        }        
        
        [HttpPost]
        [Route("Create")]
        public async Task<ResponseMessageResult> CreateUser(UserDTO dtoObject)
        {
            var result = await this.Service.CreateAsync(dtoObject);
            if (result != null)
            {
                return await this.JsonApiSuccessAsync(Message.SuccessResult, result);
            }

            return await this.JsonApiNoContentAsync(Message.NoContent, null);
        }

        [HttpPut]
        [Route("Update")]
        public async Task<ResponseMessageResult> UpdateUser(UserDTO dtoObject)
        {
            var result = await this.Service.UpdateAsync(dtoObject);
            if (result != null)
            {
                return await this.JsonApiSuccessAsync(Message.SuccessResult, result);
            }

            return await this.JsonApiNoContentAsync(Message.NoContent, null);
        }
        
        public override Task Delete(string id)
        {
            return base.Delete(id);
        }
        
        [HttpPost]
        [Route("ChangePassword")]
        public async Task<ResponseMessageResult> ChangeUserPassword(ChangePasswordDTO dtoObject)
        {
            var result = await Service.ChangePasswordAsync(dtoObject);
            if (result != null)
            {
                return await this.JsonApiSuccessAsync(Message.UserPasswordChangeSuccessfully, result);
            }

            return await this.JsonApiNoContentAsync(Message.NoContent, null);
        }
        
        [HttpDelete]
        [Route("DeleteList")]
        public async Task<ResponseMessageResult> DeleteMultipleUsers(List<UserIdDTO> dtoList)
        {
            await this.Service.DeleteMultipleUsersAsync(dtoList);
            return await this.JsonApiSuccessAsync(Message.SuccessResult, null);
        }
        
        [HttpPut]
        [Route("UpdateStatus")]
        public async Task<ResponseMessageResult> UpdateStatus(List<ChangeUserStatusDTO> dtoStatus)
        {
            await this.Service.UpdateUserStatusAsync(dtoStatus);
            return await this.JsonApiSuccessAsync(Message.SuccessResult, null);
        }
        
        [HttpGet]
        [Route("CheckEmail")]
        [AllowAnonymous]
        [AuthorizeAnonymousApi]
        public async Task<ResponseMessageResult> CheckEmail(string emailId)
        {
            var result = await this.Service.EmailExists(emailId);
            if (!result)
            {
                return await this.JsonApiSuccessAsync(Message.SuccessResult, result);
            }

            return await this.JsonApiBadRequestAsync(string.Format(Message.AlreadyExist, "Email"), null);
        }
    }
}