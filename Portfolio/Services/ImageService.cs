using Portfolio.Exceptions;
using Portfolio.FileStores;
using System.Collections.Generic;
using System.IO;
using System.Web;

namespace Portfolio.Services
{
    public class ImageService : IImageService
    {
        IFileStore _fileStore;
        List<string> _validTypes;
        public Dictionary<string, string> Errors { get; }

        public ImageService(IFileStore fileStore)
        {
            _fileStore = fileStore;
            Errors = new Dictionary<string, string>();

            _validTypes = new List<string>();
            _validTypes.Add(".jpg");
            _validTypes.Add(".png");
            _validTypes.Add(".gif");
        }

        public string Create(HttpPostedFileBase file)
        {
            if(!Validate(file))
            {
                throw new ImageException("Image validation failed");
            }

            return _fileStore.Store(file);
        }

        private bool Validate(HttpPostedFileBase file)
        {
            bool isValid = true;
            string extension = Path.GetExtension(file.FileName).ToLower();
               
            if (!_validTypes.Contains(extension))
            {
                Errors.Add("Image", "Invalid file extension for image. Valid extensions are JPG, PNG, or GIF.");
                isValid = false;
            }

            return isValid;
        }
    }
}