using Portfolio.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace Portfolio.ViewModels
{
    public class ProjectEditViewModel : ProjectViewModel
    {
        public HttpPostedFileBase Image { get; set; }
    }
}
