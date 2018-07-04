using Portfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portfolio.ViewModels
{
    public class HomeIndexViewModel
    {
        public List<Project> Projects { get; set; }
        public List<Category> Categories { get; set; }

        public HomeIndexViewModel()
        {
            Projects = new List<Project>();
            Categories = new List<Category>();
        }
    }
}