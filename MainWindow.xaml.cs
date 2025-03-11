using System.Windows;
using ProjectManagementApp.Models;
using ProjectManagementApp.ViewModels;
using ProjectManagementApp.Views;

namespace ProjectManagementApp
{
    public partial class MainWindow : Window
    {
        private readonly ProjectViewModel ViewModel;

        public MainWindow(ProjectViewModel viewModel)
        {
            InitializeComponent();
            ViewModel = viewModel;
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
            if (ViewModel.SelectedProject is null)
            {
                MessageBox.Show("Please select a project to edit.");
                return;
            }

            var form = new ProjectForm(ViewModel.SelectedProject);
            if (form.ShowDialog() == true)
            {
                ViewModel.UpdateProject(ViewModel.SelectedProject);
            }
        }

        private void DeleteProject_Click(object sender, RoutedEventArgs e)
        {
            if (ViewModel.SelectedProject is null)
            {
                MessageBox.Show("Please select a project to delete.");
                return;
            }

            var result = MessageBox.Show("Are you sure you want to delete this project?", "Confirm Delete",
                MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (result == MessageBoxResult.Yes)
            {
                ViewModel.DeleteProject(ViewModel.SelectedProject);
            }
        }
    }
}
