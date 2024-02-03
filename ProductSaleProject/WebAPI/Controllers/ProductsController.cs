using AutoMapper;
using Business.Abstract;
using Entities.Concrete;
using Entities.Constants.Messages;
using Entities.DTOs;
using Entities.ResponseModels.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        public ProductsController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<DataResult<List<Product>>>> GetAllProducts()
        {
            var result = await _productService.GetAllProductsAsync();
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("category/{id}")]
        public async Task<ActionResult<DataResult<List<Product>>>> GetProductsByCategory(int id)
        {
            var result = await _productService.GetProductByCategoryId(id);
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("{productId}")]
        public async Task<ActionResult<DataResult<Product>>> GetSingleProduct(int productId)
        {
            var result = await _productService.GetProductByIdAsync(productId);
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [Authorize]
        [HttpPost("addproduct")]
        public async Task<ActionResult<Result>> CreateProduct(AddProductDto productDto)
        {
           var existProduct = await _productService.GetProductByNameAsync(productDto.ProductName);
            if (existProduct)
            {
                return BadRequest(ErrorMessages.EntityAlreadyExists);
            }
            var finalProduct = _mapper.Map<Product>(productDto);
           var result = await _productService.AddProductAsync(finalProduct);
            if (result.Success) {
                var createdFinalProduct = _mapper.Map<ProductDto>(finalProduct);
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpPut("update")]
        public async Task<ActionResult<Result>> UpdateProduct(Product product)
        {
            var result =  await _productService.UpdateProductAsync(product);
            if (result.Success) {
                return Ok(result);
             }
            return BadRequest(result.Message);
        }
        [HttpDelete("delete")]
        public async Task<ActionResult<Result>> DeleteProduct(Product product)
        {
            var result = await _productService.DeleteProductAsync(product);
            if (result.Success) { 
               return(Ok(result));
            }
            return BadRequest(result.Message);
        }
    }
}
