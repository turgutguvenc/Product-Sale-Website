using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    public class AllProductTest
    {


            private readonly IProductDal _productDal;
            private readonly IProductService _productService;
            public AllProductTest(IProductDal productDal, IProductService productService)
            {
                _productDal = productDal;
                _productService = productService;
            }

            public async Task TestGettingAllProductsFromDatabase()
            {
                var result = await _productService.GetAllProductsAsync();
                if (result.Success == false)
                {
                    Console.WriteLine("No products found");
                    return;
                }
                foreach (Product product in result.Data)
                {
                    Console.WriteLine("Product Id: " + product.ProductId);
                    Console.WriteLine("Product Name: " + product.ProductName);
                    Console.WriteLine("Product Price: " + product.UnitPrice);
                    Console.WriteLine("Product in Stock: " + product.UnitsInStock);
                    Console.WriteLine("--------------------");
                }
            }

            public async Task TestGetProductByIdFromDatabase(int productId)
            {

                var result = await _productService.GetProductByIdAsync(productId);
                if (result.Success == false)
                {
                    Console.WriteLine("No product found");
                    return;
                }
                Console.WriteLine("--------------------Single Product--------------");
                Console.WriteLine("Product Id: " + result.Data.ProductId);
                Console.WriteLine("Product Name: " + result.Data.ProductName);
                Console.WriteLine("Product Price: " + result.Data.UnitPrice);
                Console.WriteLine("Product in Stock: " + result.Data.UnitsInStock);
            }

            public async Task TestGetProductByCategoryFromDatabase(int categoryId)
            {
                var result = await _productService.GetProductByCategoryId(categoryId);
                if (result.Success == false)
                {
                    Console.WriteLine($"No product found by category id {categoryId}");
                    return;
                }
                Console.WriteLine($"--------------------Category {categoryId} Product--------------");
                foreach (var product in result.Data)
                {
                    Console.WriteLine("Product Id: " + product.ProductId);
                    Console.WriteLine("Product Name: " + product.ProductName);
                    Console.WriteLine("Product Price: " + product.UnitPrice);
                    Console.WriteLine("Product in Stock: " + product.UnitsInStock);
                    Console.WriteLine("Category Id: " + product.CategoryId);
                    Console.WriteLine("--------------------");
                }
            }

            public async Task TestGetProductsByPriceRange(decimal min, decimal max)
            {
                var result = await _productService.GetAllProductsByPriceRangeAsync(min,max);
                if (result.Success == false)
                {
                    Console.WriteLine($"No product found by this range between price {min} and price {max}");
                    return;
                }
                Console.WriteLine("--------------------Category 1 Product--------------");
                foreach (var product in result.Data)
                {
                    Console.WriteLine("Product Id: " + product.ProductId);
                    Console.WriteLine("Product Name: " + product.ProductName);
                    Console.WriteLine("Product Price: " + product.UnitPrice);
                    Console.WriteLine("Product in Stock: " + product.UnitsInStock);
                    Console.WriteLine("Category Id: " + product.CategoryId);
                    Console.WriteLine("--------------------");
                }
            }

            public async Task TestGetProductInDetails()
            {
                var result = await _productService.GetProductDetailsAsync();
                if (result.Success == false)
                {
                    Console.WriteLine("No products found");
                    return;
                }
                Console.WriteLine("--------------------Product in Detail--------------");
                foreach (var product in result.Data)
                {
                    Console.WriteLine("Product Id: " + product.ProductId);
                    Console.WriteLine("Product Name: " + product.ProductName);
                    Console.WriteLine("Product Price: " + product.UnitPrice);
                    Console.WriteLine("Product in Stock: " + product.UnitsInStock);
                    Console.WriteLine("Category Name: " + product.CategoryName);
                    Console.WriteLine("--------------------");
                }
            }
        }

}
