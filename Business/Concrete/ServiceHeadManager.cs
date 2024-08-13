using Business.Abstract;
using Core.Helpers.Results.Abstract;
using Core.Helpers.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
	public class ServiceHeadManager : IServiceHeadService
	{
		private readonly IServiceHeadDal _serviceHeadDal;

		public ServiceHeadManager(IServiceHeadDal serviceHeadDal)
		{
			_serviceHeadDal = serviceHeadDal;
		}

		public IResult AddService(ServiceHead serviceHead)
		{
			_serviceHeadDal.Add(serviceHead);
			return new SuccessResult();
		}

		public IDataResult<List<ServiceHead>> GetServiceHead()
		{
			var result = _serviceHeadDal.GetAll(s => s.IsFeautured == true).Take(1).ToList();
			if (result.Count > 0)
			{
				return new SuccessDataResult<List<ServiceHead>>(result);
			}
			else return new ErrorDataResult<List<ServiceHead>>(result);
		}
	}
}
