using CleanArchMVC.Domain.Validation;
using System;
using System.Collections.Generic;

namespace CleanArchMVC.Domain.Entities
{
    public sealed class Category
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public ICollection<Product> Products { get; set; }

        public Category(string name)
        {
            ValidationDomain(name);
        }

        public Category(int id, string name)
        {
            DomainExceptionValidation.When(id < 0, "Invalid Id value");
            Id = id;
            ValidationDomain(name);
        }

        private void ValidationDomain(string name)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), $"Invalid {name}.Name is Required");
            DomainExceptionValidation.When(name.Length < 3, $"Invalid name, too short, minumum 3 Caracteres");

            name = Name;
        }
    }
}
