using System.Collections.Generic;
using System.Threading.Tasks;
using Happibook.Core.DTO;
using Happibook.Core.Entity;
using Happibook.Core.Enum;
using Happibook.Core.IRepository;
using Recipe.Core.Attribute;
using Recipe.Core.Base.Interface;
using Recipe.Core.Enum;

namespace Happibook.Core.IService
{
    public interface IPermissionService : IService<IPermissionRepository, Permission, PermissionDTO, int>
    {
        [AuditOperation(OperationType.Read)]
        Task<PermissionDTO> Get(string name);

        [AuditOperation(OperationType.Read)]
        Task<List<PermissionDTO>> Get(PermissionGroup group);

        [AuditOperation(OperationType.Read)]
        Task<List<PermissionDTO>> GetReportPermissions(string reportName);
    }
}
