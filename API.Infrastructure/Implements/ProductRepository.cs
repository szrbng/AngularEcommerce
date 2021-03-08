﻿using API.Core.DataModels;
using API.Core.Interfaces;
using API.Infrastructure.DataContext;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Infrastructure.Implements
{
    public class ProductRepository : IProductRepository
    {
        private readonly StoreContext _context;

        public ProductRepository(StoreContext storeContext)
        {
            _context = storeContext;
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _context.Products
                
                .Include(p=>p.ProductBrand)
                .Include(p=>p.ProductType)
                .FirstOrDefaultAsync(f => f.Id == id);
        }
        public async Task<IReadOnlyList<Product>> GetProductAsync()
        {
            return await _context.Products
                
                .Include(p=>p.ProductBrand)
                .Include(p=>p.ProductType)

                .ToListAsync();
        }

        public async Task<IReadOnlyList<ProductBrand>> GetProductBrandAsync()
        {
            return await _context.ProductBrands.ToListAsync();
        }

        public async Task<IReadOnlyList<ProductType>> GetProductTypeAsync()
        {
            return await _context.ProductTypes.ToListAsync();
        }
    }
}
