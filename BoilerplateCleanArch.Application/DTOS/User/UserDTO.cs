using System.ComponentModel.DataAnnotations;

namespace BoilerplateCleanArch.Application.DTOS.User
{
    public class UserDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The Name is Required")]
        [MinLength(3)]
        [MaxLength(100)]
        public string Name { get; set; }
    }
}
