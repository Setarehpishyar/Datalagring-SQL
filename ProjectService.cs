using ProjectManagementApp.Data;
using ProjectManagementApp.Models;
using System;
using System.Linq;

namespace ProjectManagementApp.Services
{
    public class ProjectService
    {
        private readonly AppDbContext _context;

        public ProjectService(AppDbContext context)
        {
            _context = context;
        }

        public void AddProject(Project project)
        {
            _context.Projects.Add(project);
            _context.SaveChanges();
        }

        public void UpdateProject(Project project)
        {
            _context.Projects.Update(project);
            _context.SaveChanges();
        }

        public void DeleteProject(Project project)
        {
            _context.Projects.Remove(project);
            _context.SaveChanges();
        }

        public IQueryable<Project> GetProjects()
        {
            return _context.Projects;
        }
    }
}

