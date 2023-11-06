using Business.Abstract;
using Business.ResponseModels.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Constants.Messages;
using Entities.DTOs;
using Entities.ResponseModels.Abstract;
using Entities.ResponseModels.Concrete;
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
        public async Task<IResult> AddProductAsync(Product product)
        {
            if (product == null)
            {
                return new ErrorResult(ErrorMessages.EntityIsNotValid);
            }    
           var result = await _productDal.AddAsync(product);
            if(result)
            {
                return new SuccessResult(SuccessMessages.EntityAdded);
            }
                return new ErrorResult(ErrorMessages.NoEntityFound);

  
        }

        public async Task<IResult> DeleteProductAsync(Product product)
        {
            if (product == null)
            {
                return new ErrorResult(ErrorMessages.EntityIsNotValid);
            }
           var result = await  _productDal.DeleteAsync(product);
            if(result)
            {
                return new SuccessResult(SuccessMessages.EntityDeleted);
            }
            return new ErrorResult(ErrorMessages.NoEntityFound);
        }

        public async Task<IResult> UpdateProductAsync(Product product)
        {
            if (product == null)
            {
                return new ErrorResult(ErrorMessages.EntityIsNotValid);
            }
            var result = await _productDal.UpdateAsync(product);
            if( result)
            {
                return new SuccessResult(SuccessMessages.EntityUpdated);
            }
            return new ErrorResult(ErrorMessages.NoEntityFound);
        }


        public async Task<IDataResult<List<Product>>> GetAllProductsAsync()
        {
           var products = await _productDal.GetAll();
            if(products.Count < 1)
            {
                return new ErrorDataResult<List<Product>> (products, ErrorMessages.NoEntityFound);
            }
            return new SuccessDataResult<List<Product>>(products,SuccessMessages.EntityAllListed);
        }

        public async Task<IDataResult<List<Product>>> GetAllProductsByPriceRangeAsync(decimal minPrice, decimal maxPrice)
        {
            var products = await _productDal.GetAll(p=> p.UnitPrice> minPrice && p.UnitPrice < maxPrice);
            if (products.Count == 0)
            {
                return new ErrorDataResult<List<Product>>(products, ErrorMessages.NoEntityFound);
            }
            return new SuccessDataResult<List<Product>>(products, SuccessMessages.EntityAllListed);
        }

        public async Task<IDataResult<List<Product>>> GetProductByCategoryId(int categoryId)
        {
            var products =  await _productDal.GetAll(p => p.CategoryId == categoryId);
            if (products.Count == 0)
            {
                return new ErrorDataResult<List<Product>>(products, ErrorMessages.NoEntityFound);
            }
            return new SuccessDataResult<List<Product>>(products, SuccessMessages.CategoryById);
        }

        public async Task<IDataResult<Product>> GetProductByIdAsync(int id)
        {
            var product = await _productDal.Get(p=> p.ProductId == id);
            if(product == null)
            {
                return new ErrorDataResult<Product>(product, ErrorMessages.NoEntityFound);
            }
            return new SuccessDataResult<Product>(product, SuccessMessages.EntityByEntityId);
        }

        public async Task<IDataResult<List<ProductDetailDto>>> GetProductDetailsAsync()
        {
           var products = await _productDal.GetProductsWithDetails();
            if (products.Count == 0)
            {
                return new ErrorDataResult<List<ProductDetailDto>>(products, ErrorMessages.NoEntityFound);
            }
            return new SuccessDataResult<List<ProductDetailDto>>(products, SuccessMessages.EntityAllListed);
        }
    }
}
