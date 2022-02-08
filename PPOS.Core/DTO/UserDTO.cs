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
    public class UserDTO : DTO<ApplicationUser, string>
    {
        public UserDTO()
        {
        }

        public UserDTO(ApplicationUser entity) : base(entity)
        {
        }
        
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string FullName
        {
            get
            {
                return string.Format("{0} {1} {2}", this.FirstName, this.MiddleName, this.LastName);
            }
        }
        
        public string Email { get; set; }

        public string Password { get; set; }

        [Required]
        public List<UserRoleDTO> Roles { get; set; }
        
        public string CellNumber { get; set; }
        
        public string CreatedOn { get; set; }

        public UserStatus Status { get; set; }

        public string Picture { get; set; }

        public override ApplicationUser ConvertToEntity(ApplicationUser entity)
        {
            entity = base.ConvertToEntity(entity);

            entity.FirstName = this.FirstName;
            entity.LastName = this.LastName;
          
            if (!string.IsNullOrEmpty(entity.Id) && this.Roles.Any())
            {
                foreach (var role in this.Roles)
                {
                    entity.Roles.Add(new ApplicationUserRole { RoleId = role.Id, UserId = entity.Id });
                }
            }

            entity.Email = this.Email;
            entity.UserName = this.Email;
            entity.EmailConfirmed = true;
            entity.CellNumber = this.CellNumber;
            entity.CreatedOn = DateTime.UtcNow;
            entity.Status = (int)this.Status;
            entity.Picture = this.Picture;

            return entity;
        }

        public override void ConvertFromEntity(ApplicationUser entity)
        {
            base.ConvertFromEntity(entity);
            this.FirstName = entity.FirstName;
            this.LastName = entity.LastName;
            this.Email = entity.Email;
            
            if (entity.Roles != null && entity.Roles.Count > 0)
            {
                this.Roles = entity.Roles.Select(x => new UserRoleDTO { Id = x.RoleId, UserId = x.UserId }).ToList();
            }

            this.CellNumber = entity.CellNumber;
            this.CreatedOn = entity.CreatedOn.ToString(Validations.DateFormat);
            this.Status = (UserStatus)entity.Status;
            this.Picture = entity.Picture;
        }

        private string SetStatus(int status)
        {
            Enum.UserStatus statusText = (Enum.UserStatus)status;
            return statusText.ToString();
        }
    }
}