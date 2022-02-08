using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Happibook.Core.Constant;
using Happibook.Core.DTO;
using Happibook.Core.Entity;
using Happibook.Core.Enum;
using Happibook.Core.Extensions;
using Happibook.Core.Infrastructure;
using Happibook.Core.IRepository;
using Happibook.Core.IService;
using Recipe.Core.Base.Generic;

namespace Happibook.Service
{
    public class CurrencyService : Service<ICurrencyRepository, Currency, CurrencyDTO, int>, ICurrencyService
    {
        private readonly ISSHRequestInfo requestInfo;
        private readonly IExceptionHelper exceptionHelper;
        private readonly ISSHUnitOfWork unitOfWork;

        public CurrencyService(
            ISSHUnitOfWork unitOfWork,
            ISSHRequestInfo requestInfo,
            IExceptionHelper exceptionHelper)
            : base(unitOfWork, unitOfWork.CurrencyRepository)
        {
            this.requestInfo = requestInfo;
            this.exceptionHelper = exceptionHelper;
            this.unitOfWork = unitOfWork;
        }
    }
}
