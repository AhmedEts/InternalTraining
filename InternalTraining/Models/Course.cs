namespace InternalTraining.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int NumberOfChapters { get; set; }

        public ICollection<Chapter> Chapters { get; set; }
        public ICollection<CourseFeedback> Feedbacks { get; set; }
        public ICollection<Certificate> Certificates { get; set; }  


    }
}
