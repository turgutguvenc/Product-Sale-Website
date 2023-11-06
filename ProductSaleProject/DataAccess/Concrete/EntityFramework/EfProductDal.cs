using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : IProductDal
    {
        private readonly NorthwindDbContext _context;
        public EfProductDal(NorthwindDbContext context)
        {
            _context = context;
        }
        public async Task<bool> AddAsync(Product entity)
        {
            var result = await CheckProductExistsAsync(entity);
            if(result )
            {
                await _context.Products.AddAsync(entity);
                await _context.SaveChangesAsync();
            }
            return result;
        }

        public async Task<bool> DeleteAsync(Product entity)
        {
            var productToDelete = await _context.Products.FirstOrDefaultAsync(p=> p.ProductId == entity.ProductId);
            if(productToDelete != null)
            {
                _context.Products.Remove(productToDelete);
                await _context.SaveChangesAsync();
            }
            return productToDelete != null;
        }

        public async Task<Product> Get(Expression<Func<Product, bool>> filter)
        {
            return _context.Products.FirstOrDefault(filter);
        }

        public async Task<List<Product>> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            if(filter == null)
            {
                return  _context.Products.ToList();
            }
            else
            {
               return  _context.Products.Where(filter).ToList();
            }

        }

        public async Task<bool> UpdateAsync(Product entity)
        {
            var productsToUpdate = _context.Products.FirstOrDefault(p => p.ProductId == entity.ProductId);
            if (productsToUpdate != null)
            {

                productsToUpdate.ProductName = entity.ProductName;
                productsToUpdate.UnitPrice = entity.UnitPrice;
                productsToUpdate.UnitsInStock = entity.UnitsInStock;
                productsToUpdate.CategoryId = entity.CategoryId;
            }
           await  _context.SaveChangesAsync();
            return productsToUpdate != null;
        }

        public async Task<List<ProductDetailDto>> GetProductsWithDetails()
        {
            var result = from p in _context.Products
                         join c in _context.Categories
                         on p.CategoryId equals c.CategoryId
                         select new ProductDetailDto
                         {
                             ProductId = p.ProductId,
                             CategoryName = c.CategoryName,
                             UnitsInStock = p.UnitsInStock,
                             UnitPrice = p.UnitPrice,
                             ProductName = p.ProductName,
                         };
            return  result.ToList();
        }

        public async Task<bool> CheckProductExistsAsync(Product product)
        {
            var result = await _context.Products.SingleOrDefaultAsync(p => p.ProductId == product.ProductId);
            return result != null;
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }

    }
}
