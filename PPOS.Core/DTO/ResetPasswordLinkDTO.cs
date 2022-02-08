using System.ComponentModel.DataAnnotations;
using Happibook.Core.Entity;

namespace Happibook.Core.DTO
{
    public class ResetPasswordLinkDTO
    {
        [Required]
        [RegularExpression(Constant.Validations.EmailAddress, ErrorMessage = "")]
        public string UserName { get; set; }
    }
}
