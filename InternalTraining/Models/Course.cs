using System.ComponentModel.DataAnnotations;

namespace InternalTraining.Models
{
    public class Course
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 100 characters.")]
        public string Name { get; set; }

        [Required]
        [Range(3, 20, ErrorMessage = "Number of chapters must be between 3 and 20.")]
        public int NumberOfChapters { get; set; }

        [Required]
        [RegularExpression("^.*\\.(png|jpg)$")]
        public string CourseImage { get; set; }

        [Required]
        [StringLength(300, MinimumLength = 10, ErrorMessage = "Description must be between 10 and 300 characters.")]
        public string Description { get; set; }

        public ICollection<Chapter> Chapters { get; set; } = new List<Chapter>();
        public ICollection<CourseFeedback> Feedbacks { get; set; } = new List<CourseFeedback>();
        public ICollection<Certificate> Certificates { get; set; } = new List<Certificate>();
        public ICollection<CompanyCourse> CompanyCourses { get; set; } = new List<CompanyCourse>();
        public ICollection<EmployeeProgress> Progresses { get; set; } = new List<EmployeeProgress>();
    }

}
