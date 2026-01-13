using System.ComponentModel.DataAnnotations;

namespace Coink.Dtos
{
    public class UserDto
    {
        [Required]
        [MinLength(3)]
        public string Name { get; set; }

        [Required]
        [Phone]
        public string Phone { get; set; }

        [Required]
        public string Address { get; set; }

        [Required(ErrorMessage = "MunicipalityId is required")]
        public int? MunicipalityId { get; set; }
    }
}
