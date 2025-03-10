using System;
using System.ComponentModel.DataAnnotations;

namespace ProjectManagementApp.Models
{
    public class Project
    {
        [Key]
        public int Id { get; set; }
        public string ProjectNumber { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Manager { get; set; } = string.Empty;
        public string Customer { get; set; } = string.Empty;
        public string Service { get; set; } = string.Empty;
        public decimal TotalPrice { get; set; }
        public string Status { get; set; } = "In Progress";
    }
}



