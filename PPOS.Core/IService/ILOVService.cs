using System.Collections.Generic;
using System.Threading.Tasks;
using Happibook.Core.DTO;
using Happibook.Core.Entity;
using Happibook.Core.Enum;
using Recipe.Common.Helper;
using Recipe.Core.Attribute;
using Recipe.Core.Base.Interface;
using Recipe.Core.Enum;

namespace Happibook.Core.IService
{
    public interface ILOVService : IService<LOVDTO, int>
    {
        [AuditOperation(OperationType.Read)]
        Task<IList<LOVDTO>> GetAllAsync(LOVGroup group);

        [AuditOperation(OperationType.Read)]
        Task<TotalResultDTO<LOVDTO>> GetUpdatedListAsync(JsonApiRequest request);

        //[AuditOperation(OperationType.Delete)]
        Task<int> DeleteAsync(List<LOVIdDTO> dtoList);

        [AuditOperation(OperationType.Update)]
        Task<int> UpdateStatusAsync(ChangeLOVStatusDTO dtoObject);

        [AuditOperation(OperationType.Read)]
        Task<string[]> GetAllGroups();

        [AuditOperation(OperationType.Read)]
        Task<IList<LOVDTO>> GetByGroup(string groupName);
    }
}
