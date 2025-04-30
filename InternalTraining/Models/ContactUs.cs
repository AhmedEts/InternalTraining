using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace InternalTraining.Models
{
    public class ContactUs
    {
        public int Id { get; set; }

        public string CompanyName { get; set; }  // Fixed typo in "CompanyName"
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public int NumberOfEmployees { get; set; }
        public DateTime ExpectedTrainingDate { get; set; }
        [ValidateNever]
        public ICollection<Course> DesiredCourses { get; set; }
        public string Message { get; set; }

    }
}
