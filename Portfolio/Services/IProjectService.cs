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
        Project Create(Project project, HttpPostedFileBase imageFile, ICollection<int> categoryIds);
        Project Update(int id, string title, string body, string externalLink, HttpPostedFileBase imageFile, ICollection<Category> categories);
        Dictionary<string, string> Errors { get; }
    }
}
