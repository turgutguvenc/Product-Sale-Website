using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System.Linq.Expressions;

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
Console.WriteLine("-------------------------Expressions--------------------------------");
Func<int> total = () => 10;
Student student = new Student()
{
    StudentID = 1,
    StudentName = "Abraham Anderson",
    Age = 19
};
Func<Student, bool> isTeenAger = s => s.Age > 12 && s.Age < 20;
Expression<Func<Student, bool>> isTeenAgerExpr = s => s.Age > 12 && s.Age < 20;
Console.WriteLine(isTeenAger(student));
Console.WriteLine(isTeenAgerExpr.Compile());


public class Student
{
    public int StudentID { get; set; }
    public string StudentName { get; set; }
    public int Age { get; set; }
}
