using System.Collections.Generic;
using System.Threading.Tasks;
using Happibook.Core.DTO;
using Happibook.Core.Entity;
using Recipe.Core.Base.Interface;

namespace Happibook.Core.IRepository
{
    public interface ILOVRepository : IRepository<LOV, int>
    {
        Task<bool> Exists(LOV entity);

        Task<int> Delete(List<LOVIdDTO> dtoList);

        Task<int> UpdateStatus(ChangeLOVStatusDTO dtoObject);

        Task<string[]> GetAllGroups();

        Task<IEnumerable<LOV>> GetByGroup(string groupName);

        Task<string> GetValueByGroupAndKey(string groupName, string keyName);
    }
}
