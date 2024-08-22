using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;



namespace Core.Helpers.Business.ImageHelper
{
    public class AddImageHelper (IWebHostEnvironment webHostEnvironment) : IImageAddHelper
    {
		// NuGet\Install-Package Microsoft.AspNetCore.Hosting.WindowsServices -Version 8.0.8 packageManager console-da yuklenmelidir
		private readonly IWebHostEnvironment _webHostEnvironment = webHostEnvironment;
		public void AddImage(IFormFile formFile, string guid)
        {
            if (formFile.Length > 0 && formFile.Name !=null)
            {
                var fileName = guid;
                var wwwFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");
                var imageFolder = Path.Combine(wwwFolder, fileName);
                using var fileStream = new FileStream(imageFolder, FileMode.Create);
                formFile.CopyTo(fileStream);
            }

        }
    }
}
