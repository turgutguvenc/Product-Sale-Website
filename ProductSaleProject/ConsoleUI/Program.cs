
using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Tests;

IProductDal productDal = new EfProductDal(new NorthwindDbContext());
IProductService productService = new ProductManager(productDal);
Console.WriteLine("-----------------Test starts------------------");
AllProductTest productTest = new AllProductTest(productDal,productService);
//productTest.TestGettingAllProductsFromDatabase();
//productTest.TestGetProductByCategoryFromDatabase(2);
//productTest.TestGetProductByIdFromDatabase(2);
//productTest.TestGetProductInDetails();
productTest.TestGetProductsByPriceRange(50, 100);



