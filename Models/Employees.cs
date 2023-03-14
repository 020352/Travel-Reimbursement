using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Http;
namespace Webapplication.Models
{
    public class Employees
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int ReimbursementNo{get; set;}
        [Required]
        public string EmployeeID  {get; set;}
        [Required]
        [RegularExpression(@"[a-zA-Z ]*$",ErrorMessage ="Employee name should not contain numbers")]
        public string EmployeeName{get; set;}
        [Required]
        public string startdate{get; set;}
        [Required]
        public string enddate{get; set;}
        [Required]
        [RegularExpression(@"[a-zA-Z ]*$",ErrorMessage ="Project Title should not contain numbers")]
        public string Projecttitle{get; set;}
        [Required]
        public string Tripto{get; set;}
        [Required]
        public string Description1{get; set;}
        [Required]
        public decimal Cost1{get; set;}
        public string Description2{get; set;}
        public decimal? Cost2{get; set;}
        public string Description3{get; set;}
        public decimal? Cost3{get; set;}
        [Required]
        public decimal TotalCost{get; set;}
        [Required]
        [RegularExpression(@"([a-zA-Z0-9\s_\\.\-:])+(.doc|.docx|.pdf)$",ErrorMessage ="Only pdf and doc format are allowed")]
        public string Attachment{get; set;}
        [NotMapped]
        [Required]
        public IFormFile file{get; set;}
        public DateTime SubmittedDate{get; set;}
        [Required]
        public string Suggesstion{get; set;}
        public string Status{get; set;}
    }
}