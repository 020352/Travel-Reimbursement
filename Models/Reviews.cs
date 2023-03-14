using System;
using System.ComponentModel.DataAnnotations;
namespace Webapplication.Models
{
    public class Reviews
    {
        [Key]
        public int EmployeeID{get; set;}
        [Required]
        public string ratings{get; set;}
        [Required]
        public string feedback{get; set;}
    }
}