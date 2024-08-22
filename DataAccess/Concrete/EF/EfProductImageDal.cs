using Core.DataAccess.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EF
{
	public class EfProductImageDal(EcommerceCN002Context context) : BaseEntityRepository<ProductImage, EcommerceCN002Context>(context), IProductImageDal
	{
		public List<ProductImageGetAllDto> GetAllImageProduct()
		{
			using EcommerceCN002Context context = new();
			var result = from i in context.ProductImages
						 where i.IsDelete == false
						 join p in context.Products
						 on i.ProductId equals p.Id
						 select new ProductImageGetAllDto
						 {
							 ProductId = i.ProductId,
							 ProductImageId = i.Id,
							 ProductName = p.ProductName,
							 Description = p.Description,
							 DiscountRate = p.DiscountRate,
							 IsDiscount = p.IsDiscount,
							 IsFeatured = p.IsFeatured,
							 Price = p.Price,
							 ProductCount = p.ProductCount,
							 PhotoUrl = i.PhotoUrl,
						 };
			return result.ToList();
		}
	}
}
