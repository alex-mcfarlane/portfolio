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
            HomeIndexViewModel homeVM = new HomeIndexViewModel();

            foreach (Project project in _context.Projects.ToList())
            {
                homeVM.Projects.Add(project);
            }

            foreach (Category category in _context.Categories.ToList())
            {
                homeVM.Categories.Add(category);
            }

            return View(homeVM);
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