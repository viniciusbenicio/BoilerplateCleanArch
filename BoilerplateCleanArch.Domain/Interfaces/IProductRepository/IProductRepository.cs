﻿using BoilerplateCleanArch.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BoilerplateCleanArch.Domain.Interfaces.IProductRepository
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProductsAsync();
        Task<Product> GetByIdAsync(int? id);
        //Task<Product> GetProductCategoryAsync(int? id);
        Task<Product> CreateAsync(Product product);
        Task<Product> UpdateAsync(Product product);
        Task<Product> RemoveAsync(Product product);
    }
}
