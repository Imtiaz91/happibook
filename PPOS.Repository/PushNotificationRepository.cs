using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Happibook.Core.Entity;
using Happibook.Core.Infrastructure;
using Happibook.Core.IRepository;
using Recipe.Core.Base.Generic;

namespace Happibook.Repository
{
    public class PushNotificationRepository : AuditableRepository<PushNotification, int>, IPushNotificationRepository
    {
        public PushNotificationRepository(ISSHRequestInfo requestInfo)
            : base(requestInfo)
        {
        }

        protected override IQueryable<PushNotification> DefaultListQuery
        {
            get
            {
                return base.DefaultListQuery
                    .Include(x => x.ApplicationUser).OrderByDescending(x => x.Id);
            }
        }

        protected override IQueryable<PushNotification> DefaultSingleQuery
        {
            get
            {
                return base.DefaultSingleQuery
                    .Include(x => x.ApplicationUser).OrderByDescending(x => x.Id);
            }
        }

        public async Task<IList<PushNotification>> GetAllByUserId(string userId)
        {
            return await this.DefaultListQuery.Where(x => x.ApplicationUserId == userId && !x.IsRead).ToListAsync();
        }

        public async Task<int> GetCountByUserId(string userId)
        {
            return await this.DefaultListQuery.CountAsync(x => x.ApplicationUserId == userId && !x.IsRead);
        }
    }
}