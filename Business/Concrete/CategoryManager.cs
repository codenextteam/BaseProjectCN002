using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CategoryManager(ICategoryDal categoryDal) : ICategoryService
    {
        private readonly ICategoryDal _categoryDal= categoryDal;
        public void AddCategory(Category category)
        {
            if (category.CategoryName.Length>3)
            {
                _categoryDal.Add(category);
            }
        }
    }
}
