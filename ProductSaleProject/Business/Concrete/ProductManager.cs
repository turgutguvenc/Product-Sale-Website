using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IProductDal _productDal;
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }
        public async Task AddProductAsync(Product product)
        {
           _productDal.Add(product);
        }

        public async Task DeleteProductAsync(Product product)
        {
            _productDal.Delete(product);
        }

        public async Task<List<Product>> GetAllProductsAsync()
        {
           return _productDal.GetAll();
        }

        public async Task<List<Product>> GetAllProductsByPriceRangeAsync(decimal minPrice, decimal maxPrice)
        {
            return _productDal.GetAll(p=> p.UnitPrice> minPrice && p.UnitPrice < maxPrice);
        }

        public async Task<List<Product>> GetProductByCategoryId(int categoryId)
        {
            return _productDal.GetAll(p => p.CategoryId == categoryId);
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return _productDal.Get(p=> p.ProductId == id);
        }


        public async Task UpdateProductAsync(Product product)
        {
            _productDal.Update(product);
        }
    }
}
