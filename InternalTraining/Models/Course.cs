namespace InternalTraining.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int NumberOfChapters { get; set; }
        public string CourseImage { get; set; }
        public string Description {get; set; }
        public ICollection<Chapter> Chapters { get; set; } 
        public ICollection<CourseFeedback> Feedbacks { get; set; }
        public ICollection<Certificate> Certificates { get; set; }

        public ICollection<CompanyCourse> CompanyCourses { get; set; } = new List<CompanyCourse>();

        public ICollection<EmployeeProgress> Progresses { get; set; } = new List<EmployeeProgress>();



    }
}
