namespace InternalTraining.Models
{
    public class Lesson
    {
        public int Id { get; set; }
        public int ChapterId { get; set; }
        public Chapter Chapter { get; set; }

        public string Title { get; set; }
        public string ContentUrl { get; set; }

    }
}
