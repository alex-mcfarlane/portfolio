using Portfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portfolio.ViewModels
{
    public class HomeIndexViewModel
    {
        public List<ProjectListingViewModel> Projects { get; set; }
        public List<Category> Categories { get; set; }

        public HomeIndexViewModel()
        {
            Projects = new List<ProjectListingViewModel>();
            Categories = new List<Category>();
        }
    }
}