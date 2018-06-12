using Portfolio.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Web.Mvc;

namespace Portfolio.ViewModels
{
    public class ProjectCreateViewModel
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string ExternalLink { get; set; }
        [Required]
        public string Body { get; set; }
        [Required]
        public HttpPostedFileBase Image { get; set; }
        public List<SelectListItem> CategoriesSelectList { get; set; }
        public List<int> SelectedItems { get; set; }

        public ProjectCreateViewModel()
        {
            CategoriesSelectList = new List<SelectListItem>();
            SelectedItems = new List<int>();
        }

        public void SetCategoriesSelectList(List<Category> categories)
        {
            foreach(Category category in categories)
            {
                CategoriesSelectList.Add(new SelectListItem { Text = category.Title, Value = category.ID.ToString() });
            }
        }
    }
}
