using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Happibook.Core.DTO;
using Happibook.Core.Entity;
using Happibook.Core.Enum;
using Happibook.Core.Infrastructure;
using Happibook.Core.IRepository;
using Recipe.Core.Base.Generic;

namespace Happibook.Repository
{
    public class LOVRepository : AuditableRepository<LOV, int>, ILOVRepository
    {
        public LOVRepository(ISSHRequestInfo requestInfo) 
            : base(requestInfo)
        {
        }

        public async Task<IEnumerable<LOV>> GetAll(List<int> ids)
        {
            return await this.DefaultListQuery.Where(x => ids.Contains(x.Id) && !x.IsDeleted).ToListAsync();
        }

        public async Task<IEnumerable<LOV>> GetByGroup(string groupName)
        {
            return await this.DefaultListQuery.Where(x => x.Group == groupName && !x.IsDeleted).ToListAsync();
        }

        public async Task<string> GetValueByGroupAndKey(string groupName, string keyName)
        {
            var result = await this.DefaultListQuery.FirstOrDefaultAsync(x => x.Group == groupName && x.Key == keyName && !x.IsDeleted);
            return result != null ? result.Value : null;
        }

        public async Task<bool> Exists(LOV entity)
        {
            var result = await this.DefaultSingleQuery.FirstOrDefaultAsync(x => x.Group == entity.Group && !x.IsDeleted && (x.Key == entity.Key || x.Value == entity.Value));
            return result != null;           
        }

        public override async Task<LOV> Update(LOV entity)
        {
            var lov = await this.GetAsync(entity.Id);
            lov.LastModifiedOn = DateTime.UtcNow;
            lov.LastModifiedBy = this.RequestInfo == null ? string.Empty : RequestInfo.UserId;
            lov.Value = entity.Value;
            lov.Group = entity.Group;
            lov.IsActive = entity.IsActive;

            entity = await base.Update(lov);
            await this.DBContext.SaveChangesAsync();

            return entity;
        }

        public async Task<int> Delete(List<LOVIdDTO> dtoList)
        {
            var lovIds = dtoList.Select(x => x.Id).ToList();
            var entities = await this.GetAll(lovIds);
            if (entities.Count() > 0)
            {
                foreach (var entity in entities)
                {
                    entity.IsDeleted = true;
                    await base.Update(entity);
                }

                return await this.DBContext.SaveChangesAsync();
            }

            return 0;
        }

        public async Task<int> UpdateStatus(ChangeLOVStatusDTO dtoObject)
        {
            var lovIds = dtoObject.Ids.Select(x => x.Id).ToList();
            var entities = await this.GetAll(lovIds);   
            if (entities.Count() > 0)
            {
                foreach (var entity in entities)
                {
                    entity.LastModifiedOn = DateTime.UtcNow;
                    entity.LastModifiedBy = this.RequestInfo == null ? string.Empty : RequestInfo.UserId;
                    entity.IsActive = dtoObject.IsActive;
                    await base.Update(entity);                 
                }

                return await this.DBContext.SaveChangesAsync();
            }

            return 0;          
        }

        public override Task<IEnumerable<LOV>> GetAll()
        {
            return base.GetAll();
        }

        public async Task<string[]> GetAllGroups()
        {
            return System.Enum.GetNames(typeof(LOVGroup));
        }
    }
}
