using System.Threading.Tasks;
using Happibook.Core.Entity;
using Happibook.Core.Infrastructure;
using Happibook.Core.IRepository;
using Recipe.Core.Base.Generic;

namespace Happibook.Repository
{
    public class LisenceRepository : AuditableRepository<Lisence, int>, ILisenceRepository
    {
        private ISSHRequestInfo requestInfo;

        public LisenceRepository(ISSHRequestInfo requestInfo)
            : base(requestInfo)
        {
            this.requestInfo = requestInfo;
        }
    }
}
