using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Happibook.Core.Entity;
using Recipe.Core.Base.Interface;

namespace Happibook.Core.IRepository
{
    public interface IPushNotificationRepository : IRepository<PushNotification, int>
    {
        Task<IList<PushNotification>> GetAllByUserId(string userId);

        Task<int> GetCountByUserId(string userId);
    }
}
