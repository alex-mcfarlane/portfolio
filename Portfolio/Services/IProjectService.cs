using Portfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Portfolio.Services
{
    public interface IProjectService
    {
        Project Create(string title, string body, string externalLink, HttpPostedFileBase imageFile, ICollection<int> categoryIds);
        Project Update(int id, string title, string body, string externalLink, HttpPostedFileBase imageFile, ICollection<int> categoryIds);
        Dictionary<string, string> Errors { get; }
    }
}
