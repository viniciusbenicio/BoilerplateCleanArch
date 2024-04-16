using BoilerplateCleanArch.Domain.Validation;
using System;

namespace BoilerplateCleanArch.Domain.Entities
{
    public class User : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; } 
        public string Email { get; set; }
        public string Password { get; set; }
        public string? AccessToken { get; set; }
        public DateTime? Expiration { get; set; }
        public bool Active { get; set; }

        public User(string firstName)
        {
            ValidationDomain(firstName);
        }
        public User(int id, string firstName)
        {
            DomainExceptionValidation.When(id < 0, "Invalid Id value");
            Id = id;
            ValidationDomain(firstName);
        }
        public void Update(string firstName)
        {
            ValidationDomain(firstName);
        }
        private void ValidationDomain(string firstName)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(firstName), "Invalid firstName is Required");
            DomainExceptionValidation.When(firstName.Length < 3, $"Invalid firstName, too short, minumum 3 Caracteres");

            FirstName = firstName;
        }
    }
    
}
