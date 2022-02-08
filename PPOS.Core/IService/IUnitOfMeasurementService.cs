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
    public interface IUnitOfMeasurementService : IService<IUnitOfMeasurementRepository, UnitOfMeasurement, UnitOfMeasurementDTO, int>
    {
    }
}
