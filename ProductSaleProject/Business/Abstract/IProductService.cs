using Entities.Concrete;
using Entities.DTOs;
using Entities.ResponseModels.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IProductService
    {
        Task<IDataResult<List<Product>>> GetAllProductsAsync();
        Task<IResult> AddProductAsync(Product product);
        Task<IResult> UpdateProductAsync(Product product);
        Task<IResult> DeleteProductAsync(Product product);
        Task<IDataResult<Product>> GetProductByIdAsync(int id);
        Task<IDataResult<List<Product>>> GetProductByCategoryId(int categoryId); 
        Task<IDataResult<List<Product>>> GetAllProductsByPriceRangeAsync(decimal minPrice, decimal maxPrice);
        Task<IDataResult<List<ProductDetailDto>>> GetProductDetailsAsync();
        Task<bool>  GetProductByNameAsync(string productName);
    }
}
