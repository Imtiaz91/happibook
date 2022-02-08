using Happibook.Core.Entity;
using Happibook.Core.Infrastructure;
using Happibook.Core.IRepository;
using Recipe.Core.Base.Generic;

namespace Happibook.Repository
{
    public class UtilitiesRepository : AuditableRepository<Utilities, int>, IUtilitiesRepository
    {
        private ISSHRequestInfo requestInfo;

        public UtilitiesRepository(ISSHRequestInfo requestInfo)
            : base(requestInfo)
        {
            this.requestInfo = requestInfo;
        }
    }
}
