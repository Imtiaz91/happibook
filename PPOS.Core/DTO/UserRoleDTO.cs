using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Happibook.Core.Constant;
using Happibook.Core.Entity;
using Happibook.Core.Enum;
using Recipe.Core.Base.Abstract;

namespace Happibook.Core.DTO
{
    public class UserRoleDTO
    {
        public string UserId { get; set; }

        public string Id { get; set; }

        public string Name { get; set; }

        public ApplicationUserRole ConvertToEntity(ApplicationUserRole entity)
        {
            //entity = base.ConvertToEntity(entity);
            entity.RoleId = this.Id;
            entity.UserId = this.UserId;
            
            return entity;
        }

        public void ConvertFromEntity(ApplicationUserRole entity)
        {
            //base.ConvertFromEntity(entity);
            this.Id = entity.RoleId;
            this.UserId = entity.UserId;
        }
    }
}