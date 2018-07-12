using Portfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portfolio.ViewModels
{
    public class ProjectListingViewModel
    {
        public string Title;
        public string ExternalLink;
        public string ThumbnailPath;
        public string Body;
        public IEnumerable<Category> Categories;

        public string GetCategoriesAsClass()
        {
            return String.Join(" ", Categories.Select(c => c.ID));
        }
    }
}