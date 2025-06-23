using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Employee_Management_System.Models
{
    public class Department
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [StringLength(10)]
        public string DepartmentCode { get; set; } = string.Empty;
        
        [Required]
        [StringLength(100)]
        public string DepartmentName { get; set; } = string.Empty;
        
        [StringLength(500)]
        public string? Description { get; set; }
        
        public int Status { get; set; } = 1;
        
        [Column(TypeName = "date")]
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        
        // Navigation property
        public virtual ICollection<Employee>? Employees { get; set; }
    }
}