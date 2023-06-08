using RideShare.Application.Uploads;
using RideShare.Implementation.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RideShare.Implementation.Uploads
{
    public class Base64FileUploader : IBase64FileUploader
    {
        private List<string> _allowedExtensions = new List<string>
        {
            "jpg", "png"
        };
        public string GetExtension(string base64File)
        {
            return base64File.GetFileExtension();
        }

        public bool IsExtensionValid(string base64File)
        {
            return _allowedExtensions.Contains(GetExtension(base64File));
        }

        public string Upload(string base64File)
        {
            var extension = base64File.GetFileExtension();

            if (!_allowedExtensions.Contains(extension))
            {
                throw new InvalidOperationException("Unsupported file extension.");
            }

            var path = Path.Combine("wwwroot", "images", "cars", Guid.NewGuid().ToString() + "." + extension);

            System.IO.File.WriteAllBytes(path, Convert.FromBase64String(base64File));

            return path;
        }
    }
}
