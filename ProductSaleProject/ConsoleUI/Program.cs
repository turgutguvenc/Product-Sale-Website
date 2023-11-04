using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System.Linq.Expressions;

IProductDal productDal = new EfProductDal(new NorthwindDbContext());
IProductService productService = new ProductManager(productDal);
//List<Product> products = await productService.GetAllProductsAsync(); 
//foreach (Product product in products)
//{
//    Console.WriteLine("Product Id: " + product.ProductId);
//    Console.WriteLine("Product Name: "+product.ProductName);
//    Console.WriteLine("Product Price: "+product.UnitPrice);
//    Console.WriteLine("Product in Stock: "+product.UnitsInStock);
//    Console.WriteLine("--------------------");
//}
var product2 = await productService.GetProductByIdAsync(97);
Console.WriteLine("--------------------Sngle Product--------------");
Console.WriteLine("Product Id: " + product2.ProductId);
Console.WriteLine("Product Name: " + product2.ProductName);
Console.WriteLine("Product Price: " + product2.UnitPrice);
Console.WriteLine("Product in Stock: " + product2.UnitsInStock);
List<Product> productsByCategory = await productService.GetProductByCategoryId(1);
Console.WriteLine("--------------------Category 1 Product--------------");
foreach (var product in productsByCategory)
{
    Console.WriteLine("Product Id: " + product.ProductId);
    Console.WriteLine("Product Name: " + product.ProductName);
    Console.WriteLine("Product Price: " + product.UnitPrice);
    Console.WriteLine("Product in Stock: " + product.UnitsInStock);
    Console.WriteLine("Category Id: " + product.CategoryId);
    Console.WriteLine("--------------------");
}
List<Product> productsByPricerange = await productService.GetAllProductsByPriceRangeAsync(10,60);
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

