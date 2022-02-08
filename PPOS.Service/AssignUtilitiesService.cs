using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Happibook.Core.Constant;
using Happibook.Core.DTO;
using Happibook.Core.Entity;
using Happibook.Core.Enum;
using Happibook.Core.Extensions;
using Happibook.Core.Infrastructure;
using Happibook.Core.IRepository;
using Happibook.Core.IService;
using Recipe.Core.Base.Generic;

namespace Happibook.Service
{
    public class AssignUtilitiesService : Service<IAssignUtilitiesRepository, AssignUtilities, AssignUtilitiesDTO, int>, IAssignUtilitiesService
    {
        private readonly ISSHRequestInfo requestInfo;
        private readonly IExceptionHelper exceptionHelper;
        private readonly ISSHUnitOfWork unitOfWork;

        public AssignUtilitiesService(
            ISSHUnitOfWork unitOfWork,
            ISSHRequestInfo requestInfo,
            IExceptionHelper exceptionHelper)
            : base(unitOfWork, unitOfWork.AssignUtilitiesRepository)
        {
            this.requestInfo = requestInfo;
            this.exceptionHelper = exceptionHelper;
            this.unitOfWork = unitOfWork;
        }

        public override async Task<AssignUtilitiesDTO> UpdateAsync(AssignUtilitiesDTO dtoObject)
        {
            // Dr opd & its related entity of that Dr Opd ID
            var assignUtilities = await this.Repository.GetAsync(dtoObject.Id);

            if (assignUtilities == null)
            {
                // Throw exception
                this.exceptionHelper.ThrowAPIException(string.Format(Message.NotFound, "Provided Data not exist"));
            }

            // Getting Max Date from Appointment (Dr. OPD TIME SLOT) By Dr.OPD ID
            // var appointmentEntities = await this.unitOfWork.AppointmentRepository.GetRecordOfMaxDateByDoctorOpd(dtoObject.Id);

            if (assignUtilities != null)
            {
                // If timeSlotEntity = null : Delete All Dates from Dr OPD Dates 
                foreach (var e in assignUtilities.AssignUtilitiesDetail)
                {
                    e.IsDeleted = true;
                    e.LastModifiedOn = DateTime.UtcNow;
                }
            }

            // Master Dr Opd Entity modified for delete
            assignUtilities.VechileId = dtoObject.VechileId;
            assignUtilities.AssignDate = dtoObject.AssignDate;  // Reason to delete
                                                                // doctorOpdEntityList.IsDeleted = true;
            assignUtilities.LastModifiedOn = DateTime.UtcNow;

            this.UnitOfWork.DBContext.Set<AssignUtilities>().Attach(assignUtilities);

            this.UnitOfWork.DBContext.Entry(assignUtilities).Property(x => x.VechileId).IsModified = true;
            this.UnitOfWork.DBContext.Entry(assignUtilities).Property(x => x.AssignDate).IsModified = true;
            //this.UnitOfWork.DBContext.Entry(doctorOpdEntityList).Property(x => x.IsDeleted).IsModified = true;
            this.UnitOfWork.DBContext.Entry(assignUtilities).Property(x => x.LastModifiedOn).IsModified = true;

            foreach (var item in dtoObject.AssignUtilitiesDetail)
            {
                await this.unitOfWork.AssignUtilitiesDetailRepository.Create(item.ConvertToEntity());
            }

            await this.UnitOfWork.SaveAsync();
            await this.unitOfWork.SaveAsync();

            var result = await this.GetAsync(dtoObject.Id);
            return result;
        }
    }
}
