using Core.DataAccess.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EF
{
    public class EfOrderDetailDal : BaseEntityRepository<OrderDetail, EcommerceCN002Context>, IOrderDetailDal
    {
        public EfOrderDetailDal(EcommerceCN002Context context) : base(context)
        {
            
        }

        public List<OrderDetailDto> GetAllOrders()
        {
            EcommerceCN002Context context = new EcommerceCN002Context();
            var result = from s in context.OrderDetails where s.IsDelete == false
                         join o in context.Orders
                         on s.OrderId equals o.Id
                         join p in context.Products
                         on s.ProductId equals p.Id
                         select new OrderDetailDto
                         {
                             ProductName = p.ProductName,
                             ProductPrice = p.Price,
                             OrderDate = o.OrderDate,
                             Count = s.Count,
                             IsDisCount = s.IsDiscount,
                             DisCountRate = s.IsDiscount ? s.DiscountRate : 0,
                             TotalPrice = s.TotalPrice,
                             IsDelivery = o.IsDelivery,
                             OrderId = o.Id,
                             ProductId = p.Id

                         };
            return result?.ToList();
        }
    }
}
