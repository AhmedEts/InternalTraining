namespace InternalTraining.Models
{
    public class Exam
    {
        public int Id { get; set; }
        public int ChapterId { get; set; }
        public Chapter Chapter { get; set; }

        public ICollection<Question> Questions { get; set; }

    }
}
