﻿using BoilerplateCleanArch.Domain.Validation;
using System.Collections.Generic;

namespace BoilerplateCleanArch.Domain.Entities
{
    public sealed class Category : Entity
    {
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

        public void Update(string name)
        {
            ValidationDomain(name);
        }

        private void ValidationDomain(string name)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Invalid name.Name is Required");
            DomainExceptionValidation.When(name.Length < 3, $"Invalid name, too short, minumum 3 Caracteres");

            Name = name;
        }
    }
}
