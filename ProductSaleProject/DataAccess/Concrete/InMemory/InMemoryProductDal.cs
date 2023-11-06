using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;
        public InMemoryProductDal()
        {
            _products = new List<Product>()
            {
                new Product(){ ProductId = 1, ProductName = "Computer",CategoryId = 1,UnitPrice = 7653, UnitsInStock = 32 },
                 new Product(){ ProductId = 2, ProductName = "Mouse",CategoryId = 3,UnitPrice = 321, UnitsInStock = 2 },
                  new Product(){ ProductId = 3, ProductName = "Secreen",CategoryId = 2,UnitPrice = 3564, UnitsInStock = 675 },
                   new Product(){ ProductId = 4, ProductName = "Keyboard",CategoryId = 3,UnitPrice = 765, UnitsInStock = 9090 },
                  new Product(){ ProductId = 5, ProductName = "Laptop",CategoryId = 1,UnitPrice = 11000, UnitsInStock = 56 },
            };
        }
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            var productToDelete = _products.FirstOrDefault(p => p.ProductId == product.ProductId);
            if (productToDelete != null)
            {
                _products.Remove(productToDelete);  
            }
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetByCategory(int categoryId)
        {
            return _products.Where(p => p.CategoryId == categoryId).ToList();
        }

        public Product Get(int productId)
        {
            var product = _products.FirstOrDefault(p => p.ProductId == productId);
            return product;
        }

        public void Update(Product product)
        {
            var productsToUpdate = _products.FirstOrDefault(p=> p.ProductId == product.ProductId);
            if(productsToUpdate != null)
            {
                productsToUpdate.UnitPrice = product.UnitPrice;
                productsToUpdate.UnitsInStock = product.UnitsInStock;
                productsToUpdate.ProductName = product.ProductName;
                productsToUpdate.CategoryId = product.CategoryId;
            }
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<ProductDetailDto> GetProductsWithDetails()
        {
            throw new NotImplementedException();
        }

        public Task<List<ProductDetailDto>> GetProductsWithDetailsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> CheckProductExistsAsync(Product product)
        {
            throw new NotImplementedException();
        }

        public Task<List<Product>> GetAllAsync(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetAsync(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AddAsync(Product entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(Product entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(Product entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        Task<List<ProductDetailDto>> IProductDal.GetProductsWithDetails()
        {
            throw new NotImplementedException();
        }

        Task<List<Product>> IEntityRepositoryDal<Product>.GetAll(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        Task<Product> IEntityRepositoryDal<Product>.Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }
    }
}
