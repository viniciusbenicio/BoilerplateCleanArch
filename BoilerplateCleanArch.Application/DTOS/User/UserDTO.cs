using System;
using System.ComponentModel.DataAnnotations;

namespace BoilerplateCleanArch.Application.DTOS.User
{
    public class UserDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "The Name is Required")]
        [MinLength(3)]
        [MaxLength(100)]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool Active { get; set; }
    }
}
