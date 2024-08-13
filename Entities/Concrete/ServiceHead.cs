using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
	public class ServiceHead : BaseEntity
	{
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string ServicePhotoUrl { get; set; }
        public bool IsFeautured { get; set; }
    }
}
