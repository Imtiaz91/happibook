using System.Threading.Tasks;
using Happibook.Core.DTO;
using Happibook.Core.Entity;
using Happibook.Core.Infrastructure;
using Happibook.Core.IRepository;
using Happibook.Core.IService;
using Recipe.Core.Base.Generic;

namespace Happibook.Service
{
    public class SettingService : Service<ISettingRepository, Setting, SettingDTO, int>, ISettingService
    {
        private readonly ISSHRequestInfo requestInfo;
        private readonly IExceptionHelper exceptionHelper;
        private readonly ISSHUnitOfWork unitOfWork;

        public SettingService(
            ISSHUnitOfWork unitOfWork,
            ISSHRequestInfo requestInfo,
            IExceptionHelper exceptionHelper)
            : base(unitOfWork, unitOfWork.SettingRepository)
        {
            this.requestInfo = requestInfo;
            this.exceptionHelper = exceptionHelper;
            this.unitOfWork = unitOfWork;
        }

        public async override Task<SettingDTO> UpdateAsync(SettingDTO dtoObject)
        {
            var activEnt = await this.Repository.GetAsync(dtoObject.Id);

            // End Here Check Status Active or not

            // Full update of Master
            activEnt.Code = dtoObject.Code;
            activEnt.SiteName = dtoObject.SiteName;
            activEnt.Slogan = dtoObject.Slogan;
            activEnt.NTNNumber = dtoObject.NTNNumber;
            activEnt.CurrencyId = (dtoObject.CurrencyId != null && dtoObject.CurrencyId != 0) ? dtoObject.CurrencyId : null;
            activEnt.ContactNumber1 = dtoObject.ContactNumber1;
            activEnt.ContactNumber2 = dtoObject.ContactNumber2;
            activEnt.FaxNumber = dtoObject.FaxNumber;
            activEnt.Email = dtoObject.Email;
            activEnt.Website = dtoObject.Website;
            activEnt.CountryId = (dtoObject.CountryId != null && dtoObject.CountryId != 0) ? dtoObject.CountryId : null;
            activEnt.PostalCode = dtoObject.PostalCode;
            activEnt.Address = dtoObject.Address;
            activEnt.SiteLogo = dtoObject.SiteLogo;              
          
            this.unitOfWork.DBContext.Set<Setting>().Attach(activEnt);
            this.UnitOfWork.DBContext.Entry(activEnt).Property(x => x.Code).IsModified = true;
            this.UnitOfWork.DBContext.Entry(activEnt).Property(x => x.SiteName).IsModified = true;
            this.UnitOfWork.DBContext.Entry(activEnt).Property(x => x.Slogan).IsModified = true;
            this.UnitOfWork.DBContext.Entry(activEnt).Property(x => x.NTNNumber).IsModified = true;
            this.UnitOfWork.DBContext.Entry(activEnt).Property(x => x.CurrencyId).IsModified = true;
            this.UnitOfWork.DBContext.Entry(activEnt).Property(x => x.ContactNumber1).IsModified = true;
            this.UnitOfWork.DBContext.Entry(activEnt).Property(x => x.ContactNumber2).IsModified = true;
            this.UnitOfWork.DBContext.Entry(activEnt).Property(x => x.FaxNumber).IsModified = true;
            this.UnitOfWork.DBContext.Entry(activEnt).Property(x => x.Email).IsModified = true;
            this.UnitOfWork.DBContext.Entry(activEnt).Property(x => x.Website).IsModified = true;
            this.UnitOfWork.DBContext.Entry(activEnt).Property(x => x.CountryId).IsModified = true;
            this.UnitOfWork.DBContext.Entry(activEnt).Property(x => x.PostalCode).IsModified = true;
            this.UnitOfWork.DBContext.Entry(activEnt).Property(x => x.Address).IsModified = true;
            this.UnitOfWork.DBContext.Entry(activEnt).Property(x => x.SiteLogo).IsModified = true;

            await this.unitOfWork.SaveAsync();

            dtoObject.ConvertFromEntity(activEnt);

            return dtoObject;
        }

        public async Task<int> DeleteSetting(int id)
        {
            int isDeleted = 0;

            var compEntity = await this.Repository.GetAsync(id);

            if (compEntity == null)
            {
                this.exceptionHelper.ThrowAPIException(string.Format("Please provide correct Setting"));
            }

            return isDeleted;
        }
    }
}
