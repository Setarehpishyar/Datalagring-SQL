using ProjectManagementApp.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;


namespace ProjectManagementApp
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private ObservableCollection<Project> _projects;
        public ObservableCollection<Project> Projects
        {
            get { return _projects; }
            set
            {
                _projects = value;
                OnPropertyChanged(nameof(Projects));
            }
        }

        private Project _selectedProject;
        public Project SelectedProject
        {
            get { return _selectedProject; }
            set
            {
                _selectedProject = value;
                OnPropertyChanged(nameof(SelectedProject));
            }
        }

        public ICommand AddProjectCommand { get; set; }
        public ICommand EditProjectCommand { get; set; }
        public ICommand DeleteProjectCommand { get; set; }

        public MainViewModel()
        {
            
            Projects = new ObservableCollection<Project>
            {
                new Project { ProjectNumber = "001", Name = "Project 1", Status = "In Progress" },
                new Project { ProjectNumber = "002", Name = "Project 2", Status = "Completed" }
            };

            // دستورهای دکمه‌ها
            AddProjectCommand = new RelayCommand(_ => AddProject());
            EditProjectCommand = new RelayCommand(_ => EditProject(), _ => SelectedProject != null);
            DeleteProjectCommand = new RelayCommand(_ => DeleteProject(), _ => SelectedProject != null);
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        
        private void AddProject()
        {
            
            var newProject = new Project
            {
                ProjectNumber = "003",
                Name = "New Project",
                Status = "In Progress"
            };
            Projects.Add(newProject);
        }

        private void EditProject()
        {
            if (SelectedProject != null)
            {
                
                SelectedProject.Name = "Updated Project";
            }
        }

        private void DeleteProject()
        {
            if (SelectedProject != null)
            {
                
                Projects.Remove(SelectedProject);
            }
        }
    }
}
