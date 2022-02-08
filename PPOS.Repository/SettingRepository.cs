using Happibook.Core.Entity;
using Happibook.Core.Infrastructure;
using Happibook.Core.IRepository;
using Recipe.Core.Base.Generic;

namespace Happibook.Repository
{
    public class SettingRepository : AuditableRepository<Setting, int>, ISettingRepository
    {
        private ISSHRequestInfo requestInfo;

        public SettingRepository(ISSHRequestInfo requestInfo)
            : base(requestInfo)
        {
            this.requestInfo = requestInfo;
        }
    }
}
