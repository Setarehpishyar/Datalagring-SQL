using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using ProjectManagementApp.Models;

namespace ProjectManagementApp.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        
        private ObservableCollection<Project> _projects = new ObservableCollection<Project>();
        public ObservableCollection<Project> Projects
        {
            get => _projects;
            set
            {
                if (_projects != value)
                {
                    _projects = value;
                    OnPropertyChanged(nameof(Projects));
                }
            }
        }

        private Project? _selectedProject;
        public Project? SelectedProject
        {
            get => _selectedProject;
            set
            {
                if (_selectedProject != value)
                {
                    _selectedProject = value;
                    OnPropertyChanged(nameof(SelectedProject));
                }
            }
        }

        public ICommand AddProjectCommand { get; }
        public ICommand EditProjectCommand { get; }
        public ICommand DeleteProjectCommand { get; }

        public MainViewModel()
        {
            AddProjectCommand = new RelayCommand(_ => AddProject());
            EditProjectCommand = new RelayCommand(_ => EditProject(), _ => SelectedProject != null);
            DeleteProjectCommand = new RelayCommand(_ => DeleteProject(), _ => SelectedProject != null);
        }

        private void AddProject()
        {
            var newProject = new Project
            {
                ProjectNumber = (Projects.Count + 1).ToString("D3"),
                Name = "New Project",
                Status = "In Progress",
                Customer = new Customer { Name = "Default Customer" }
            };

            Projects.Add(newProject);
            OnPropertyChanged(nameof(Projects));
        }

        private void EditProject()
        {
            if (SelectedProject != null)
            {
                SelectedProject.Name = "Updated Project";
                OnPropertyChanged(nameof(SelectedProject));
            }
        }

        private void DeleteProject()
        {
            if (SelectedProject != null)
            {
                Projects.Remove(SelectedProject);
                OnPropertyChanged(nameof(Projects));
            }
        }

        
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

