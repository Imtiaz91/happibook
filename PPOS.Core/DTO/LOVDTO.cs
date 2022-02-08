using System.Collections.Generic;
using Happibook.Core.Constant;
using Happibook.Core.Entity;
using Happibook.Core.Enum;
using Happibook.Core.Helper;
using Recipe.Core.Base.Abstract;
using Recipe.Core.Base.Interface;

namespace Happibook.Core.DTO
{
    public class LOVDTO : DTO<LOV, int>
    {
        public string Key { get; set; }

        public string Value { get; set; }

        public string Group { get; set; }
        
        public bool IsActive { get; set; }

        public string Status { get; set; }

        public System.DateTime Date { get; set; }

        public string CreatedOn { get; set; }

        public static string GetLOVGroup(string id)
        {
            LOVGroup lov;
            System.Enum.TryParse(id, out lov);
            return lov.ToString();
        }

        public static List<LOVDTO> ConvertEntityListToDTOList(IEnumerable<LOV> entityList)
        {
            var result = new List<LOVDTO>();
            if (entityList != null)
            {
                foreach (var entity in entityList)
                {
                    var dto = new LOVDTO();
                    dto.ConvertFromEntity(entity);
                    result.Add(dto);
                }
            }

            return result;
        }

        public override void ConvertFromEntity(LOV entity)
        {
            base.ConvertFromEntity(entity);
            this.Id = entity.Id;
            this.Key = entity.Key;
            this.Value = entity.Value;
            this.Group = entity.Group;
            this.IsActive = entity.IsActive;
            this.Date = entity.LastModifiedOn == null ? entity.CreatedOn : entity.LastModifiedOn;
            this.Status = entity.IsActive ? LOVStatus.Active.ToString() : LOVStatus.Inactive.ToString();
            this.CreatedOn = entity.CreatedOn.ToString(Validations.DateFormat);
        }

        public override LOV ConvertToEntity(LOV entity)
        {
            entity = base.ConvertToEntity(entity);
            entity.Key = this.Key;
            entity.Value = this.Value;
            entity.Group = GetLOVGroup(this.Group);
            entity.Id = this.Id;
            entity.IsActive = this.IsActive;
            return entity;
        }    
    }
}
