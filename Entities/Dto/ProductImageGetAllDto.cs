using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dto
{
	public class ProductImageGetAllDto : IDto
	{
        public int ProductId { get; set; }
        public int ProductImageId { get; set; }
        public string ProductName { get; set; }
		public string Description { get; set; }
		public int ProductCount { get; set; }
		public bool IsFeatured { get; set; }
		public decimal Price { get; set; }
		public bool IsDiscount { get; set; }
		public int DiscountRate { get; set; }
		public string PhotoUrl { get; set; }
	}
}
