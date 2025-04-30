namespace InternalTraining.Models
{
    public class CourseFeedback
    {
        public int Id { get; set; }
        public string EmployeeId { get; set; }
        public Employee Employee { get; set; }

        public int CourseId { get; set; }
        public Course Course { get; set; }

        public string? Comment { get; set; }
        public int Rating { get; set; }  // 1 to 5 Stars

    }
}
