using System;
using System.Collections.Generic;

namespace Employee_Management_System.Models.ViewModels
{
    public class DashboardViewModel
    {
        public int TotalEmployees { get; set; }
        public int TotalDepartments { get; set; }
        public List<Employee> RecentlyHiredEmployees { get; set; } = new List<Employee>();
        public List<Carousel> Carousels { get; set; } = new List<Carousel>();
    }
}