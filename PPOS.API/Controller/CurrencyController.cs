﻿using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using Happibook.API.Infrastructure;
using Happibook.Core.Attribute;
using Happibook.Core.Constant;
using Happibook.Core.DTO;
using Happibook.Core.Entity;
using Happibook.Core.IService;
using Recipe.Common.Helper;
using Recipe.Core.Base.Generic;

namespace Happibook.API.Controller
{
    [CustomAuthorize]
    [RoutePrefix("Currency")]
    public class CurrencyController : Controller<ICurrencyService, CurrencyDTO, Currency, int>
    {
        public CurrencyController(ICurrencyService service)
            : base(service)
        {
        }

        [HttpGet]
        [Route("Get")]
        public async Task<ResponseMessageResult> GetAll()
        {
            var request = Request.GetJsonApiRequest();
            var result = await this.Service.GetAllAsync(request);
            if (result != null)
            {
                return await this.JsonApiSuccessAsync(Message.SuccessResult, result);
            }

            return await this.JsonApiNoContentAsync(Message.NoContent, null);
        }

        [HttpGet]
        [Route("GetSingle")]
        public async Task<ResponseMessageResult> GetSingle(int id)
        {
            var result = await this.Service.GetAsync(id);
            if (result != null)
            {
                return await this.JsonApiSuccessAsync(Message.SuccessResult, result);
            }

            return await this.JsonApiNoContentAsync(Message.NoContent, null);
        }

        [HttpPost]
        [Route("Create")]
        public async Task<ResponseMessageResult> CreateCurrency(CurrencyDTO dtoObject)
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
        public async Task<ResponseMessageResult> UpdateCurrency(CurrencyDTO dtoObject)
        {
            var result = await this.Service.UpdateAsync(dtoObject);
            if (result != null)
            {
                return await this.JsonApiSuccessAsync(Message.SuccessResult, result);
            }

            return await this.JsonApiNoContentAsync(Message.NoContent, null);
        }

        [HttpDelete]
        [Route("Delete")]
        public async Task<ResponseMessageResult> DeleteCurrency(int id)
        {
            await this.Service.DeleteAsync(id);
            return await this.JsonApiSuccessAsync(Message.SuccessResult, id);
        }
    }
}
