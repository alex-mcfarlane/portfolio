using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Portfolio.Exceptions;
using Portfolio.Models;
using Portfolio.Services;
using Portfolio.ViewModels;

namespace Portfolio.Controllers
{
    public class ProjectsController : Controller
    {
        private readonly PortfolioContext _context;
        private IProjectService _service;

        public ProjectsController(PortfolioContext context, IProjectService projectService)
        {
            _context = context;
            _service = projectService;
        }

        // GET: Projects
        public ActionResult Index()
        {
            return View(_context.Projects.ToList());
        }

        // GET: Projects/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project = _context.Projects.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }

        // GET: Projects/Create
        public ActionResult Create()
        {
            ProjectCreateViewModel vm = new ProjectCreateViewModel();
            vm.Categories = _context.Categories.ToList();

            return View(vm);
        }

        // POST: Projects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProjectCreateViewModel projectCreateVM)
        {
            if (ModelState.IsValid)
            {
                Project project = new Project()
                {
                    Title = projectCreateVM.Title,
                    ExternalLink = projectCreateVM.ExternalLink,
                    Body = projectCreateVM.Body
                };

                try
                {
                    _service.Create(project, projectCreateVM.Image, projectCreateVM.Categories);

                    return RedirectToAction(nameof(Index));
                }
                catch (ProjectException e)
                {
                    foreach (KeyValuePair<string, string> error in _service.Errors)
                    {
                        ModelState.AddModelError(error.Key, error.Value);
                    }
                }
            }

            return View(projectCreateVM);
        }

        // GET: Projects/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project = _context.Projects.Find(id);

            if (project == null)
            {
                return HttpNotFound();
            }

            ProjectEditViewModel vm = new ProjectEditViewModel();
            vm.Categories = _context.Categories.ToList();
            vm.Title = project.Title;
            vm.Body = project.Body;
            vm.ExternalLink = project.ExternalLink;

            return View(vm);
        }

        // POST: Projects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ProjectEditViewModel projectCreateVM)
        {   
            if (ModelState.IsValid)
            {                
                try
                {
                    _service.Update(id, projectCreateVM.Title, projectCreateVM.Body, projectCreateVM.ExternalLink, projectCreateVM.Image, projectCreateVM.Categories);

                    return RedirectToAction(nameof(Index));
                }
                catch (ModelNotFoundException)
                {
                    return HttpNotFound();
                }
                catch(ProjectException)
                {
                    foreach (KeyValuePair<string, string> error in _service.Errors)
                    {
                        ModelState.AddModelError(error.Key, error.Value);
                    }
                }
                
            }
            return View(projectCreateVM);
        }

        // GET: Projects/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project = _context.Projects.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }

        // POST: Projects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Project project = _context.Projects.Find(id);
            _context.Projects.Remove(project);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
