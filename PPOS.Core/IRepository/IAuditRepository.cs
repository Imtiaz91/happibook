using System.Collections.Generic;
using System.Threading.Tasks;
using Happibook.Core.Entity;
using Recipe.Core.Base.Interface;

namespace Happibook.Core.IRepository
{
    public interface IAuditRepository : IRepository<Audit, int>
    {
        Task<Audit> GetSecondLastRecordAsync(int auditId, string referenceId, string tableName);

        Task<IEnumerable<Audit>> GetAuditByUserId(string userId);

        Task<IEnumerable<Audit>> GetAccessLogByUserId(string userId);

        Task<IEnumerable<Audit>> GetAuditByUserIdAndDate(string userId, string startDate, string endDate);

        Task<IEnumerable<Audit>> GetAccessLogByUserIdAndDate(string userId, string startDate, string endDate);
    }
}
