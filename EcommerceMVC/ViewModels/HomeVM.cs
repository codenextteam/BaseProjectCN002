using Entities.Concrete;

namespace EcommerceMVC.ViewModels
{
    public class HomeVM
    {
        public List<Product> Products { get; set; }
        public List<Product> ProductsGetByIsFeatured { get; set; }
        public Product Product { get; set; }
        public List<ServiceHead> GetServiceHeads { get; set; }
    }
}
