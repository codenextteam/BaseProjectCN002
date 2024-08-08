using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation.FluentValidation;
using Core.CrossCuttingConcern.Validation.FluentValidation;
using Core.Helpers.Results.Abstract;
using Core.Helpers.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class ProductManager(IProductDal productDal) : IProductService
    {
        private readonly IProductDal _productDal = productDal;

        //AOP=> Aspect Oriented Programming
        //cache, log, securedOperation-authoration, optimizasion, transaction
        //crossCuttingConcern => interceptors => araya giren method

        [ValidationAspect<Product>(typeof(ProductValidator))]
        public IResult AddProduct(Product product)
        {
            //ValidationTool.Validation(new ProductValidator(), product);
           
            _productDal.Add(product);
            return new SuccessResult("elave olundu");

        }

        public void DeleteProduct(Product product)
        {
            //------
            //-----
            _productDal.Delete(product);
        }

        public IDataResult<List<Product>> GetAllProducts()
        {
            List<Product> products = _productDal.GetAll(p => p.IsDelete == false);
            if (products.Count > 0)
            {
                return new SuccessDataResult<List<Product>>(products);

            }
            else
            {
                return new ErrorDataResult<List<Product>>(products, "xeta bas verdi");
            }
        }

        public IDataResult<Product> GetProductById(int id)
        {
            var result = _productDal.Get(p => p.Id == id && p.IsDelete == false);
            if (result != null)
            {
                return new SuccessDataResult<Product>(result);
            }
            else
                return new ErrorDataResult<Product>(result, "mehsul tapilmadi");
        }

        public void UpdateProduct(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
