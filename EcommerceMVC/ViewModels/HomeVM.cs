using Entities.Concrete;
using Entities.Dto;

namespace EcommerceMVC.ViewModels
{
    public class HomeVM
    {
        public List<Product> Products { get; set; }
        public List<Product> ProductsGetByIsFeatured { get; set; }
        public List<ProductImageGetAllDto> ProductImages { get; set; }
        public Product Product { get; set; }
        public List<ServiceHead> GetServiceHeads { get; set; }
    }
}
