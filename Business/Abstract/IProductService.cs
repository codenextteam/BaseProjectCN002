using Core.Helpers.Results.Abstract;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IProductService
    {
        IResult AddProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(Product product);
        IDataResult<List<Product>> GetAllProducts();
        IDataResult<Product> GetProductById(int id);
        IDataResult<List<Product>> GetAllProductsByIsFeatured();
    }
}
