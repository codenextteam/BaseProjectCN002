using Core.Helpers.Results.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
	public interface IServiceHeadService
	{
		IResult AddService(ServiceHead serviceHead);
		IDataResult<List<ServiceHead>> GetServiceHead();
	}
}
