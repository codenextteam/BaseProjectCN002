using Core.Helpers.Results.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IProductService
    {
        IResult AddProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(Product product);
       IDataResult<List<Product>> GetAllProducts();
        IDataResult<Product> GetProductById(int id);
    }
}
