using System.Threading.Tasks;
using Happibook.Core.Entity;
using Recipe.Core.Base.Interface;

namespace Happibook.Core.IRepository
{
    public interface IRoleRepository : IRepository<ApplicationRole, string>
    {
        //Task<IEnumerable<ApplicationRole>> GetAll();

        Task<ApplicationRole> GetByName(string name);
    }
}
