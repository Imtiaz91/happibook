using System.Collections.Generic;
using System.Threading.Tasks;
using Happibook.Core.DTO;
using Happibook.Core.Enum;
using Recipe.Common.Helper;

namespace Happibook.Core.IService
{
    public interface IAuditService
    {
        Task<IList<AuditDTO>> GetAllAsync();

        Task<IList<AuditDTO>> GetAllAsync(JsonApiRequest request);

        Task<AuditDTO> GetAsync(int id);

        Task<List<AuditReportDTO>> GetAuditByUserId(string userId, string startDate = null, string endDate = null);

        Task<List<AuditReportDTO>> GetAccessLog(string userId, string startDate = null, string endDate = null);

        Task<string> GetAuditReportDownload(string userId, EntityReportType reportType, string startDate = null, string endDate = null);
    }
}
