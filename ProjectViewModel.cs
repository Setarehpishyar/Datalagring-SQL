using System.ComponentModel;
using System.Collections.ObjectModel;
using ProjectManagementApp.Models;
using ProjectManagementApp.Data;
using System.Linq;

namespace ProjectManagementApp.ViewModels
{
    public class ProjectViewModel : INotifyPropertyChanged
    {
        
        public event PropertyChangedEventHandler? PropertyChanged = delegate { };

        private readonly AppDbContext _context; 

        
        public ObservableCollection<Project> Projects { get; set; } = new ObservableCollection<Project>();

        private Project _selectedProject;
        public Project SelectedProject
        {
            get { return _selectedProject; }
            set
            {
                if (_selectedProject != value)
                {
                    _selectedProject = value;
                    OnPropertyChanged(nameof(SelectedProject));  
                }
            }
        }

      
        public ProjectViewModel(AppDbContext context)
        {
            _context = context;

            
            Projects = new ObservableCollection<Project>(_context.Projects.ToList());
        }

        public ProjectViewModel()
        {
        }

        public void AddProject(Project project)
        {
            _context.Projects.Add(project);
            _context.SaveChanges();
            Projects.Add(project);
            OnPropertyChanged(nameof(Projects));
        }

        public void UpdateProject(Project project)
        {
            _context.Projects.Update(project);
            _context.SaveChanges();
            OnPropertyChanged(nameof(Projects));
        }

        public void DeleteProject(Project project)
        {
            _context.Projects.Remove(project);
            _context.SaveChanges();
            Projects.Remove(project);
            OnPropertyChanged(nameof(Projects));
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
