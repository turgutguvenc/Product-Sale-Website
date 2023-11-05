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
                List<Product> products = await _productService.GetAllProductsAsync();
                if (products == null)
                {
                    Console.WriteLine("No products found");
                    return;
                }
                foreach (Product product in products)
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

                var product = await _productService.GetProductByIdAsync(productId);
                if (product == null)
                {
                    Console.WriteLine("No product found");
                    return;
                }
                Console.WriteLine("--------------------Single Product--------------");
                Console.WriteLine("Product Id: " + product.ProductId);
                Console.WriteLine("Product Name: " + product.ProductName);
                Console.WriteLine("Product Price: " + product.UnitPrice);
                Console.WriteLine("Product in Stock: " + product.UnitsInStock);
            }

            public async Task TestGetProductByCategoryFromDatabase(int categoryId)
            {
                List<Product> productsByCategory = await _productService.GetProductByCategoryId(categoryId);
                if (productsByCategory == null)
                {
                    Console.WriteLine($"No product found by category id {categoryId}");
                    return;
                }
                Console.WriteLine($"--------------------Category {categoryId} Product--------------");
                foreach (var product in productsByCategory)
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
                List<Product> productsByPricerange = await _productService.GetAllProductsByPriceRangeAsync(min,max);
                if (productsByPricerange == null)
                {
                    Console.WriteLine($"No product found by this range between price {min} and price {max}");
                    return;
                }
                Console.WriteLine("--------------------Category 1 Product--------------");
                foreach (var product in productsByPricerange)
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
                List<ProductDetailDto> productsInDetails = await _productService.GetProductDetails();
                if (productsInDetails == null)
                {
                    Console.WriteLine("No products found");
                    return;
                }
                Console.WriteLine("--------------------Product in Detail--------------");
                foreach (var product in productsInDetails)
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
