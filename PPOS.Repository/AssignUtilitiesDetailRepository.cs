using Happibook.Core.Entity;
using Happibook.Core.Infrastructure;
using Happibook.Core.IRepository;
using Recipe.Core.Base.Generic;

namespace Happibook.Repository
{
    public class AssignUtilitiesDetailRepository : AuditableRepository<AssignUtilitiesDetail, int>, IAssignUtilitiesDetailRepository
    {
        private ISSHRequestInfo requestInfo;

        public AssignUtilitiesDetailRepository(ISSHRequestInfo requestInfo)
            : base(requestInfo)
        {
            this.requestInfo = requestInfo;
        }
    }
}
