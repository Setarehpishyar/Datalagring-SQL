using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using ProjectManagementApp.Models;
using ProjectManagementApp.Data;

namespace ProjectManagementApp.ViewModels
{
    public class MainViewModel
    {
        private readonly AppDbContext _context;

        private ObservableCollection<Project> _projects = new ObservableCollection<Project>();
        public ObservableCollection<Project> Projects
        {
            get => _projects;
            set
            {
                _projects = value;
            }
        }

        private Project? _selectedProject;
        public Project? SelectedProject
        {
            get => _selectedProject;
            set
            {
                _selectedProject = value;
            }
        }

        public ICommand AddProjectCommand { get; }
        public ICommand EditProjectCommand { get; }
        public ICommand DeleteProjectCommand { get; }

        // Constructor
        public MainViewModel(AppDbContext context)
        {
            _context = context;
            Projects = new ObservableCollection<Project>(_context.Projects.ToList());

            AddProjectCommand = new RelayCommand(_ => AddProject());
            EditProjectCommand = new RelayCommand(_ => EditProject(), _ => SelectedProject != null);
            DeleteProjectCommand = new RelayCommand(_ => DeleteProject(), _ => SelectedProject != null);
        }

        public void AddProject()
        {
            var newProject = new Project
            {
                ProjectNumber = (Projects.Count + 1).ToString("D3"),
                Name = "New Project",
                Status = "In Progress",
                Customer = new Customer { Name = "Default Customer" }
            };

            _context.Projects.Add(newProject);
            _context.SaveChanges();
            Projects.Add(newProject);
        }

        public void EditProject()
        {
            if (SelectedProject != null)
            {
                SelectedProject.Name = "Updated Project Name";
                _context.Projects.Update(SelectedProject);
                _context.SaveChanges();
            }
        }

        public void DeleteProject()
        {
            if (SelectedProject != null)
            {
                _context.Projects.Remove(SelectedProject);
                _context.SaveChanges();
                Projects.Remove(SelectedProject);
            }
        }
    }
}



