using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Happibook.Core.Entity;
using Newtonsoft.Json;
using Recipe.Core.Base.Abstract;

namespace Happibook.Core.DTO
{
    public class PermissionDTO : DTO<Permission, int>
    {
        public string Name { get; set; }

        [JsonIgnore]
        public string Group { get; set; }

        public static List<PermissionDTO> ConvertEntityListToDTOList(IEnumerable<Permission> permissions)
        {
            var result = new List<PermissionDTO>();
            if (permissions != null)
            {
                foreach (var entity in permissions)
                {
                    var dto = new PermissionDTO();
                    dto.ConvertFromEntity(entity);
                    result.Add(dto);
                }
            }

            return result;
        }

        public override Permission ConvertToEntity(Permission entity)
        {
            entity = base.ConvertToEntity(entity);
            entity.Name = this.Name;
            entity.Group = this.Group;
            return entity;
        }

        public override void ConvertFromEntity(Permission permission)
        {
            base.ConvertFromEntity(permission);

            this.Id = permission.Id;
            this.Name = permission.Name;
            this.Group = permission.Group;
        }
    }
}