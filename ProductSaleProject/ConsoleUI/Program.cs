using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

IProductDal productDal = new InMemoryProductDal();
IProductService productService = new ProductManager(productDal);
List<Product> products = await productService.GetAllProductsAsync(); 
foreach (Product product in products)
{
    Console.WriteLine("Product Name: "+product.ProductName);
    Console.WriteLine("Product Price: "+product.UnitPrice);
    Console.WriteLine("Product in Stock: "+product.UnitsInStock);
    Console.WriteLine("--------------------");
}
