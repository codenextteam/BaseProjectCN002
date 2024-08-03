
using Business.Concrete;
using DataAccess.Concrete.EF;
using Entities.Concrete;

ProductManager productManager = new ProductManager(new EfProductDal());


Product product1 = new() {ProductName = "I", Description = "256ssd", Price = 2220, ProductCount = 20, IsDiscount = false, DiscountRate = 0, IsDelete = false };
//productManager.AddProduct(product1);
//productManager.DeleteProduct(product1);
//Console.WriteLine(productManager.AddProduct(product1).Message);

//Console.WriteLine("ssss");
var allProducts = productManager.GetAllProducts();
//foreach (var item in allProducts)
//{
//    if (item.Id == 14)
//    {
//        item.IsDelete = true;
//        productManager.DeleteProduct(item);

//    }
//}


Console.WriteLine(allProducts.Message);

foreach (var item in allProducts.Data)
{
    
    Console.WriteLine(item.ProductName);
}

//productManager.AddProduct(product1);



//var products = productManager.GetAllProducts();





//foreach (var product in products)
//{
//    Console.WriteLine(product.ProductName);
//}

//CategoryManager categoryManager = new(new EfCategoryDal());
//Category category1 = new() { Id = 1, CategoryName = "Telefon", Description = "smart telefonlar" };
//categoryManager.AddCategory(category1);
