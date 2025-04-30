namespace InternalTraining.Models
{
    public class Chapter
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }

        public string Name { get; set; }
        public int NumberOfLessons { get; set; }

        public ICollection<Lesson> Lessons { get; set; }
        public Exam Exam { get; set; }

    }
}
