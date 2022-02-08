using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Happibook.Core.Entity;
using Happibook.Core.Infrastructure;
using Happibook.Core.IRepository;
using Recipe.Core.Base.Generic;

namespace Happibook.Repository
{
    public class AssignUtilitiesRepository : AuditableRepository<AssignUtilities, int>, IAssignUtilitiesRepository
    {
        private ISSHRequestInfo requestInfo;

        public AssignUtilitiesRepository(ISSHRequestInfo requestInfo)
            : base(requestInfo)
        {
            this.requestInfo = requestInfo;
        }

        protected override IQueryable<AssignUtilities> DefaultListQuery
        {
            get
            {
                return base.DefaultListQuery
                    .Include(x => x.AssignUtilitiesDetail);
            }
        }

        protected override IQueryable<AssignUtilities> DefaultSingleQuery
        {
            get
            {
                return base.DefaultSingleQuery
                    .Include(x => x.AssignUtilitiesDetail);
            }
        }
    }
}
