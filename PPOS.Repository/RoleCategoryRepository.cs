using Happibook.Core.Entity;
using Happibook.Core.Infrastructure;
using Happibook.Core.IRepository;
using Recipe.Core.Base.Generic;

namespace Happibook.Repository
{
    public class RoleCategoryRepository : AuditableRepository<RoleCategory, int>, IRoleCategoryRepository
    {
        private ISSHRequestInfo requestInfo;

        public RoleCategoryRepository(ISSHRequestInfo requestInfo)
            : base(requestInfo)
        {
            this.requestInfo = requestInfo;
        }
    }
}
