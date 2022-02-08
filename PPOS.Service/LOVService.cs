using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Happibook.Common.Helper;
using Happibook.Core.Constant;
using Happibook.Core.DTO;
using Happibook.Core.Entity;
using Happibook.Core.Enum;
using Happibook.Core.Infrastructure;
using Happibook.Core.IRepository;
using Happibook.Core.IService;
using Recipe.Common.Helper;
using Recipe.Core.Base.Generic;

namespace Happibook.Service
{
    public class LOVService : Service<ILOVRepository, LOV, LOVDTO, int>, ILOVService
    {
        private ISSHUnitOfWork unitOfWork;
        private IExceptionHelper exceptionHelper;
        private ISSHRequestInfo requestInfo;

        public LOVService(ISSHUnitOfWork unitOfWork, IExceptionHelper exceptionHelper, ISSHRequestInfo requestInfo) 
            : base(unitOfWork, unitOfWork.LOVRepository)
        {
            this.unitOfWork = unitOfWork;
            this.exceptionHelper = exceptionHelper;
            this.requestInfo = requestInfo;
        }

        public async Task<IList<LOVDTO>> GetAllAsync(LOVGroup group)
        {
            var result = await this.unitOfWork.LOVRepository.GetAll();
            result = result
                    .Where(x => x.Group == group.ToString());

            return LOVDTO.ConvertEntityListToDTOList(result);
        }

        public override async Task<LOVDTO> CreateAsync(LOVDTO dtoObject)
        {
            if (!string.IsNullOrEmpty(dtoObject.Key) && !string.IsNullOrEmpty(dtoObject.Value) && !string.IsNullOrEmpty(dtoObject.Group))
            {
                LOV entity = new LOV();
                entity = dtoObject.ConvertToEntity();
                var result = await this.Repository.Exists(entity);
                if (!result)
                {
                    await this.Repository.Create(entity);
                    this.unitOfWork.Save();
                    dtoObject.ConvertFromEntity(entity);
                }
                else
                {
                    this.exceptionHelper.ThrowAPIException(Message.LOVExists);
                }
            }
            else
            {
                this.exceptionHelper.ThrowAPIException(string.Format(Message.InvalidObject, "Data"));
            }

            return dtoObject;
        }

        public override async Task<IList<LOVDTO>> UpdateAsync(IList<LOVDTO> dtoObjects)
        {
            foreach (var dtoObject in dtoObjects)
            {
                await this.UpdateLOV(dtoObject);
            }

            return dtoObjects;
        }
        
        public async Task<LOVDTO> UpdateLOV(LOVDTO dtoObject)
        {
            var entity = await this.Repository.GetAsync(dtoObject.Id);
            if (entity == null)
            {
                this.exceptionHelper.ThrowAPIException(string.Format(Message.NotFound, "LOV"));
            }

            entity.Value = dtoObject.Value;
            entity.LastModifiedBy = this.requestInfo.UserId;
            entity.LastModifiedOn = DateTime.UtcNow;

            this.UnitOfWork.DBContext.Set<LOV>().Attach(entity);
            this.UnitOfWork.DBContext.Entry(entity).Property(x => x.Value).IsModified = true;
            this.UnitOfWork.DBContext.Entry(entity).Property(x => x.LastModifiedBy).IsModified = true;
            this.UnitOfWork.DBContext.Entry(entity).Property(x => x.LastModifiedOn).IsModified = true;

            await this.UnitOfWork.SaveAsync();

            return dtoObject;
        }

        public async Task<int> DeleteAsync(List<LOVIdDTO> dtoList)
        {
            return await this.Repository.Delete(dtoList);
        }

        public async Task<int> UpdateStatusAsync(ChangeLOVStatusDTO dtoObject)
        {           
            var result = await this.Repository.UpdateStatus(dtoObject);          
            return result;
        }

        public async Task<TotalResultDTO<LOVDTO>> GetUpdatedListAsync(JsonApiRequest request)
        {
            var lovData = await this.GetAllAsync(request);
            var total = (await this.Repository.GetAll()).Count();
            return new TotalResultDTO<LOVDTO> { Result = lovData, TotalRecords = total };
        }

        public override async Task<IList<LOVDTO>> GetAllAsync(JsonApiRequest request)
        {
            var result = await this.Repository.GetAll(request);
            return LOVDTO.ConvertEntityListToDTOList(result);
        }
        
        public async Task<string[]> GetAllGroups()
        {
            var groups = await this.Repository.GetAllGroups();
            return groups.Where(x => !x.Contains(LOVGroup.None.ToString())).ToArray();
        }

        public async Task<IList<LOVDTO>> GetByGroup(string groupName)
        {
            var result = await this.Repository.GetByGroup(groupName);
            return LOVDTO.ConvertEntityListToDTOList(result);
        }
    }
}
