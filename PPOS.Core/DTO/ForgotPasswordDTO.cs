using System.ComponentModel.DataAnnotations;
using Happibook.Core.Entity;

namespace Happibook.Core.DTO
{
    public class ForgotPasswordDTO
    {
        [Required]
        [MinLength(5)]
        [MaxLength(20)]
        public string NewPassword { get; set; }
    }
}
