using Core.DataAccess.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EF
{
    public class EfProductDal : BaseEntityRepository<Product, EcommerceCN002Context>, IProductDal
    {
        public List<Product> GetAllProductsByCategory(int categoryId)
        {
            throw new NotImplementedException();
        }
    }
}
