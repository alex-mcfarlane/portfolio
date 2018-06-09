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
        Project Create(Project project, HttpPostedFileBase imageFile, ICollection<Category> categories);
        Project Update(Project project, HttpPostedFileBase imageFile);
        Dictionary<string, string> Errors { get; }
    }
}
