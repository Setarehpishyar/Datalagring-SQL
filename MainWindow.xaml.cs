using System.Windows;
using ProjectManagementApp.Models;
using ProjectManagementApp.ViewModels;
using ProjectManagementApp.Views;

namespace ProjectManagementApp
{
    public partial class MainWindow : Window
    {
        private ProjectViewModel ViewModel = new ProjectViewModel();

        public MainWindow()
        {
            InitializeComponent();
            DataContext = ViewModel;
        }

        private void AddProject_Click(object sender, RoutedEventArgs e)
        {
            var newProject = new Project();
            var form = new ProjectForm(newProject);
            if (form.ShowDialog() == true)
            {
                ViewModel.AddProject(newProject);
            }
        }

        private void EditProject_Click(object sender, RoutedEventArgs e)
        {
            if (ViewModel.SelectedProject != null)
            {
                var form = new ProjectForm(ViewModel.SelectedProject);
                if (form.ShowDialog() == true)
                {
                    ViewModel.UpdateProject(ViewModel.SelectedProject);
                }
            }
            else
            {
                MessageBox.Show("Please Select A Project");
            }
        }

        private void DeleteProject_Click(object sender, RoutedEventArgs e)
        {
            if (ViewModel.SelectedProject != null)
            {
                ViewModel.DeleteProject(ViewModel.SelectedProject);
            }
            else
            {
                MessageBox.Show("Please Select A Project");
            }
        }
    }
}
