using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Employee_Management_System.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [StringLength(10)]
        public string EmployeeCode { get; set; } = string.Empty;
        
        [Required]
        [StringLength(200)]
        public string FullName { get; set; } = string.Empty;
        
        [Required]
        [StringLength(100)]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        
        [StringLength(20)]
        public string? Phone { get; set; }
        
        [Required]
        public int DepartmentId { get; set; }
        
        [StringLength(100)]
        public string? Position { get; set; }
        
        [Column(TypeName = "decimal(12,2)")]
        public decimal Salary { get; set; }
        
        [Column(TypeName = "date")]
        public DateTime HireDate { get; set; } = DateTime.Now;
        
        public int Status { get; set; } = 1;
        
        [StringLength(255)]
        public string? ProfileImage { get; set; }
        
        // Navigation property
        [ForeignKey("DepartmentId")]
        public virtual Department? Department { get; set; }
    }
}