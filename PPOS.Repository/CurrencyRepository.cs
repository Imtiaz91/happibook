using Happibook.Core.Entity;
using Happibook.Core.Infrastructure;
using Happibook.Core.IRepository;
using Recipe.Core.Base.Generic;

namespace Happibook.Repository
{
    public class CurrencyRepository : AuditableRepository<Currency, int>, ICurrencyRepository
    {
        private ISSHRequestInfo requestInfo;

        public CurrencyRepository(ISSHRequestInfo requestInfo)
            : base(requestInfo)
        {
            this.requestInfo = requestInfo;
        }
    }
}
