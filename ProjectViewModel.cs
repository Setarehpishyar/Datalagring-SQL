using System.Collections.ObjectModel;
using ProjectManagementApp.Models;
using ProjectManagementApp.Data;

namespace ProjectManagementApp.ViewModels
{
    public class ProjectViewModel
    {
        public ObservableCollection<Project> Projects { get; set; } = new ObservableCollection<Project>();

        private Project _selectedProject;
        public Project SelectedProject
        {
            get { return _selectedProject; }
            set { _selectedProject = value; }
        }

        public ProjectViewModel()
        {
            using (var context = new AppDbContext())
            {
                Projects = new ObservableCollection<Project>(context.Projects.ToList());
            }
        }

        public void AddProject(Project project)
        {
            using (var context = new AppDbContext())
            {
                context.Projects.Add(project);
                context.SaveChanges();
                Projects.Add(project);
            }
        }

        public void UpdateProject(Project project)
        {
            using (var context = new AppDbContext())
            {
                context.Projects.Update(project);
                context.SaveChanges();
            }
        }

        public void DeleteProject(Project project)
        {
            using (var context = new AppDbContext())
            {
                context.Projects.Remove(project);
                context.SaveChanges();
                Projects.Remove(project);
            }
        }
    }
}


