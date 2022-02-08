using System;
using System.Threading.Tasks;
using Happibook.Core.Entity;
using Happibook.Core.Infrastructure;
using Happibook.Core.IRepository;
using Recipe.Core.Base.Generic;

namespace Happibook.Repository
{
    public class CityRepository : AuditableRepository<City, int>, ICityRepository
    {
        private ISSHRequestInfo requestInfo;

        public CityRepository(ISSHRequestInfo requestInfo)
            : base(requestInfo)
        {
            this.requestInfo = requestInfo;
        }
    }
}
