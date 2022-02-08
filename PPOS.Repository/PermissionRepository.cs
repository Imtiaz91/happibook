using Happibook.Core.Entity;
using Happibook.Core.Infrastructure;
using Happibook.Core.IRepository;
using Recipe.Core.Base.Generic;

namespace Happibook.Repository
{
    public class PermissionRepository : AuditableRepository<Permission, int>, IPermissionRepository
    {
        private ISSHRequestInfo requestInfo;

        public PermissionRepository(ISSHRequestInfo requestInfo)
            : base(requestInfo)
        {
            this.requestInfo = requestInfo;
        }
    }
}
