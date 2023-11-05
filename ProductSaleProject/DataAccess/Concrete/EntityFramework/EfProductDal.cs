using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
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
        public void Add(Product entity)
        {
            _context.Products.Add(entity);  
            _context.SaveChanges();
        }

        public void Delete(Product entity)
        {
            var productToDelete = _context.Products.FirstOrDefault(p=> p.ProductId == entity.ProductId);
            if(productToDelete != null)
            {
                _context.Products.Remove(productToDelete);
                _context.SaveChanges();
            }
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            return _context.Products.FirstOrDefault(filter);
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            return filter == null ? _context.Products.ToList() : _context.Products.Where(filter).ToList();
        }

        public void Update(Product entity)
        {
            var productsToUpdate = _context.Products.FirstOrDefault(p => p.ProductId == entity.ProductId);  
            productsToUpdate.ProductName = entity.ProductName;
            productsToUpdate.UnitPrice = entity.UnitPrice;
            productsToUpdate.UnitsInStock = entity.UnitsInStock;
            productsToUpdate.CategoryId = entity.CategoryId;
            _context.SaveChanges();
        }

        public List<ProductDetailDto> GetProductsWithDetails()
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
            return result.ToList();
        }
    }
}
