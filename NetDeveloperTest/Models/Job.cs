using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NetDeveloperTest.Models
{
    public class Job
    {
        [Key]
        public int JobID { get; set; }
        [Required(ErrorMessage = "Title is required")]
        [Display(Name ="Title")]
        public string JobTitle { get; set; }
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Created date is required")]
        [DataType(DataType.Date)]
        public DateTime CreatedAt { get; set; }
        [DataType(DataType.Date)]
        public DateTime ExpiresAt { get; set; }
    }
}
