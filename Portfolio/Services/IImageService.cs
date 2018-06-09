using System.Collections.Generic;
using System.Web;

namespace Portfolio.Services
{
    public interface IImageService
    {
        string Create(HttpPostedFileBase file);
        Dictionary<string, string> Errors { get; }
    }
}
