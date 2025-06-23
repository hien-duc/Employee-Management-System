using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Employee_Management_System.Models.ViewModels
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Employee Code")]
        public string EmployeeCode { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Full Name")]
        public string FullName { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; } = string.Empty;

        [Required]
        [Phone]
        [Display(Name = "Phone")]
        public string Phone { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Department")]
        public int DepartmentId { get; set; }

        [Required]
        [Display(Name = "Position")]
        public string Position { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Salary")]
        [Range(0, double.MaxValue)]
        public decimal Salary { get; set; }

        [Required]
        [Display(Name = "Hire Date")]
        [DataType(DataType.Date)]
        public DateTime HireDate { get; set; } = DateTime.Now;

        [Display(Name = "Status")]
        public bool Status { get; set; } = true;

        [Display(Name = "Profile Image")]
        public IFormFile? ProfileImageFile { get; set; }

        [Display(Name = "Current Profile Image")]
        public string? ProfileImage { get; set; }

        // For display purposes
        public string? DepartmentName { get; set; }
    }
}