using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Employee_Management_System.Models
{
    public class Carousel
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [Column(TypeName = "nvarchar(MAX)")]
        public string Title { get; set; } = string.Empty;
        
        [Column(TypeName = "nvarchar(MAX)")]
        public string? Description { get; set; }
        
        [StringLength(255)]
        public string? ImagePath { get; set; }
        
        public bool IsActive { get; set; } = true;
        
        public int Status { get; set; } = 0;
        
        [Column(TypeName = "date")]
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}