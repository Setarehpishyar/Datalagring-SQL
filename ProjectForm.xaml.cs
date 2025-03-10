using System;
using System.Windows;
using System.Windows.Controls;
using ProjectManagementApp.Models;

namespace ProjectManagementApp.Views
{
    public partial class ProjectForm : Window
    {
        public Project Project { get; set; }

        public ProjectForm(Project project = null)
        {
            InitializeComponent();
            Project = project ?? new Project(); 

            
            if (Project != null)
            {
                txtName.Text = Project.Name;
                dpStartDate.SelectedDate = Project.StartDate;
                dpEndDate.SelectedDate = Project.EndDate;
                txtManager.Text = Project.Manager;
                txtCustomer.Text = Project.Customer;
                txtService.Text = Project.Service;
                txtTotalPrice.Text = Project.TotalPrice.ToString();
                cmbStatus.SelectedItem = Project.Status;
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            
            if (string.IsNullOrEmpty(txtName.Text) || dpStartDate.SelectedDate == null || dpEndDate.SelectedDate == null)
            {
                MessageBox.Show("Please fill in all required fields.");
                return;
            }

            
            Project.Name = txtName.Text;
            Project.StartDate = dpStartDate.SelectedDate.Value;
            Project.EndDate = dpEndDate.SelectedDate.Value;
            Project.Manager = txtManager.Text;
            Project.Customer = txtCustomer.Text;
            Project.Service = txtService.Text;
            Project.TotalPrice = decimal.TryParse(txtTotalPrice.Text, out decimal totalPrice) ? totalPrice : 0;
            Project.Status = Project.Status = cmbStatus.SelectedItem.ToString();


            
            DialogResult = true;
            Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            
            DialogResult = false;
            Close();
        }
    }
}

