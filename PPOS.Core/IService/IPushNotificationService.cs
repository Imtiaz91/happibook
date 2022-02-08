using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Happibook.Core.DTO;
using Happibook.Core.Entity;
using Happibook.Core.IRepository;
using Recipe.Core.Base.Interface;

namespace Happibook.Core.IService
{
    public interface IPushNotificationService : IService<IPushNotificationRepository, PushNotification, PushNotificationDTO, int>
    {
        Task<IList<PushNotificationDTO>> GetAllByUserId();

        Task<bool> ReadAllPushNotifications();

        Task<int> GetNotificatinoCount();
    }
}
