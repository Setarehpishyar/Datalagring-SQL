using ProjectManagementApp.Data;
using ProjectManagementApp.Models;
using System.Linq;

namespace ProjectManagementApp.Repositories
{
    public class ProjectRepository
    {
        private readonly AppDbContext _context;

        public ProjectRepository(AppDbContext context)
        {
            _context = context;
        }

        public IQueryable<Project> GetAllProjects()
        {
            return _context.Projects;
        }

        public void AddProject(Project project)
        {
            _context.Projects.Add(project);
            _context.SaveChanges();
        }

        public void DeleteProject(Project project)
        {
            _context.Projects.Remove(project);
            _context.SaveChanges();
        }

        public void UpdateProject(Project project)
        {
            _context.Projects.Update(project);
            _context.SaveChanges();
        }

        
        
        public Project ? GetProjectByName(string name)
        {
            var project = _context.Projects.FirstOrDefault(p => p.Name == name);
            return project;
        }
    }
}


