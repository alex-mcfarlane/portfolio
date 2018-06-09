using Portfolio.Exceptions;
using Portfolio.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Portfolio.Services
{
    public class ProjectService : IProjectService
    {
        private PortfolioContext _context;
        private IImageService _imageService;
        
        public Dictionary<string, string> Errors { get; private set; }

        public ProjectService(PortfolioContext context, IImageService imageService)
        {
            _context = context;
            _imageService = imageService;
            Errors = new Dictionary<string, string>();
        }

        public Project Create(Project project, HttpPostedFileBase imageFile, ICollection<Category> categories)
        {
            try
            {
                string fileName = _imageService.Create(imageFile);

                project.SetImagePath(fileName);

                foreach(Category category in categories)
                {

                }

                _context.Projects.Add(project);
                _context.SaveChangesAsync();

                return project;
            }
            catch (ImageException e)
            {
                Errors = _imageService.Errors;

                throw new ProjectException(e.Message);
            }
        }

        public Project Update(Project project, HttpPostedFileBase imageFile)
        {
            try
            {
                if(imageFile != null)
                {
                    string fileName = _imageService.Create(imageFile);

                    project.SetImagePath(fileName);
                }

                _context.Entry(project).State = EntityState.Modified;
                _context.SaveChanges();

                return project;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjectExists(project.ID))
                {
                    throw new ModelNotFoundException("Project not found");
                }
                else
                {
                    throw;
                }
            }
            catch (ImageException e)
            {
                Errors = _imageService.Errors;

                throw new ProjectException(e.Message);
            }
        }

        private bool ProjectExists(int id)
        {
            return _context.Projects.Any(e => e.ID == id);
        }
    }
}