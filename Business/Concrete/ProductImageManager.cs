using Business.Abstract;
using Core.Helpers.Business.ImageHelper;
using Core.Helpers.Results.Abstract;
using Core.Helpers.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductImageManager(IProductImageDal productImageDal, IImageAddHelper imageAddHelper) : IProductImageService
    {
        private readonly IProductImageDal _productImageDal = productImageDal;
        private readonly IImageAddHelper _imageAddHelper = imageAddHelper;
        public IResult AddProductImage(ProductImageAddDto productImageAddDto)
        {
            var guid = Guid.NewGuid() + "_" + productImageAddDto.Photo.FileName;
            _imageAddHelper.AddImage(productImageAddDto.Photo, guid);
            ProductImage productImage = new()
            {
                ProductId = productImageAddDto.ProductId,
                PhotoUrl = "/images/" + guid,
                
            };
            _productImageDal.Add(productImage);
            return new SuccessResult();
        }

        public IDataResult<List<ProductImageGetAllDto>> GetAllProductImages()
        {
            var result = _productImageDal.GetAllImageProduct();
            if (result.Count>0)
            {
                return new SuccessDataResult<List<ProductImageGetAllDto>>(result);
            }
            else return new ErrorDataResult<List<ProductImageGetAllDto>>(result);
        }
    }
}
