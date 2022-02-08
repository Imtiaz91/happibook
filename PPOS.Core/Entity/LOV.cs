using System.ComponentModel.DataAnnotations;
using Recipe.Core.Base.Abstract;

namespace Happibook.Core.Entity
{
    public class LOV : EntityBase<int>
    {
        [Required]
        public string Key { get; set; }

        [Required]
        public string Value { get; set; }

        [Required]
        public string Group { get; set; }

        public bool IsActive { get; set; }
    }
}
