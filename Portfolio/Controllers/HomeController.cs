using Portfolio.Models;
using Portfolio.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Portfolio.Controllers
{
    public class HomeController : Controller
    {
        private PortfolioContext _context;

        public HomeController(PortfolioContext context)
        {
            _context = context;
        }

        public ActionResult Index()
        {
            List<ProjectsListingViewModel> projectsVM = new List<ProjectsListingViewModel>();

            foreach (Project project in _context.Projects.ToList())
            {
                ProjectsListingViewModel projectVM = new ProjectsListingViewModel
                {
                    Title = project.Title,
                    ExternalLink = project.ExternalLink,
                    ThumbnailPath = project.ImagePath,
                    Body = project.Body
                };

                projectsVM.Add(projectVM);
            }

            return View(projectsVM);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}