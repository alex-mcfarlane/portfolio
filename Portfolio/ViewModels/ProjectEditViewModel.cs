using Portfolio.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace Portfolio.ViewModels
{
    public class ProjectEditViewModel
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string ExternalLink { get; set; }
        [Required]
        public string Body { get; set; }
        public HttpPostedFileBase Image { get; set; }
        public List<Category> Categories;

        public ProjectEditViewModel()
        {
            Categories = new List<Category>();
        }
    }
}
