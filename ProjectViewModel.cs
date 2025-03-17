using ProjectManagementApp.Models;
using ProjectManagementApp.Data;
using System.Collections.ObjectModel;
using System.Linq;

namespace ProjectManagementApp.ViewModels
{
    public class ProjectViewModel
    {
        private readonly AppDbContext _context;

        public ObservableCollection<Project> Projects { get; set; } = new ObservableCollection<Project>();

        private Project _selectedProject;
        public Project SelectedProject
        {
            get { return _selectedProject; }
            set
            {
                _selectedProject = value;
            }
        }

        public ProjectViewModel(AppDbContext context)
        {
            _context = context;
            Projects = new ObservableCollection<Project>(_context.Projects.ToList());
        }

        public void AddProject(Project project)
        {
            _context.Projects.Add(project);
            _context.SaveChanges();
            Projects.Add(project);
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
            Projects.Remove(project);
        }
    }
}

