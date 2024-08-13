using Business.Abstract;
using Core.Helpers.Results.Abstract;
using Core.Helpers.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
	public class ServiceItemManager : IServiceItemService
	{
		private readonly IServiceItemDal _serviceItemDal;

		public ServiceItemManager(IServiceItemDal serviceItemDal)
		{
			_serviceItemDal = serviceItemDal;
		}

		public IResult Add(ServiceItem serviceItem)
		{
			_serviceItemDal.Add(serviceItem);
			return new SuccessResult();
		}

		public IDataResult<List<ServiceItem>> GetAllServiceItem()
		{
			var result = _serviceItemDal.GetAll(s => s.IsFeatured == true).Take(4).ToList();
			if (result.Count > 0)
			{
				return new SuccessDataResult<List<ServiceItem>>(result);
			}
			else return new ErrorDataResult<List<ServiceItem>>(result);
		}
	}
}
