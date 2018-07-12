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

        public Project Create(string title, string body, string externalLink, HttpPostedFileBase imageFile, ICollection<int> categoryIds)
        {
            Project project = new Project()
            {
                Title = title,
                ExternalLink = externalLink,
                Body = body
            };

            try
            {
                // create image and set path on project
                string fileName = _imageService.Create(imageFile);

                project.SetImagePath(fileName);

                // add categories to project
                foreach(int categoryId in categoryIds)
                {
                    Category category = _context.Categories.Find(categoryId);
                    if(category != null)
                    {
                        project.Categories.Add(category);
                    }
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

        public Project Update(int id, string title, string body, string externalLink, HttpPostedFileBase imageFile, ICollection<int> categoryIds)
        {
            Project project = _context.Projects.Find(id);

            try
            {
                if (project == null)
                {
                    throw new ModelNotFoundException("Project not found");
                }

                if (imageFile != null)
                {
                    string fileName = _imageService.Create(imageFile);

                    project.SetImagePath(fileName);
                }

                project.Title = title;
                project.Body = body;
                project.ExternalLink = externalLink;

                // add categories that are in the request but not on the project
                IEnumerable<int> existingCatIds = project.Categories.Select(c => c.ID);
                var catIdsToAdd = categoryIds.Where(c => !existingCatIds.Contains(c));
                _context.Categories.Where(c => catIdsToAdd.Contains(c.ID))
                    .ToList().ForEach(c => project.Categories.Add(c));

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