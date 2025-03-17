using System.Windows;
using ProjectManagementApp.Models;
using ProjectManagementApp.ViewModels;
using ProjectManagementApp.Views;

namespace ProjectManagementApp
{
    public partial class MainWindow : Window
    {
        private readonly MainViewModel ViewModel;

        public MainWindow(MainViewModel viewModel)
        {
            InitializeComponent();
            ViewModel = viewModel;
            DataContext = ViewModel;
        }

        private void AddProject_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.AddProject();
        }

        private void EditProject_Click(object sender, RoutedEventArgs e)
        {
            if (ViewModel.SelectedProject == null)
            {
                MessageBox.Show("Please select a project to edit.");
                return;
            }

            var form = new ProjectForm(ViewModel.SelectedProject);
            if (form.ShowDialog() == true)
            {
                ViewModel.EditProject();
            }
        }

        private void DeleteProject_Click(object sender, RoutedEventArgs e)
        {
            if (ViewModel.SelectedProject == null)
            {
                MessageBox.Show("Please select a project to delete.");
                return;
            }

            var result = MessageBox.Show("Are you sure you want to delete this project?", "Confirm Delete",
                MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (result == MessageBoxResult.Yes)
            {
                ViewModel.DeleteProject();
            }
        }
    }
}
