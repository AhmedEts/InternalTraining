using InternalTraining.Data.Enums;

namespace InternalTraining.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public QuestionType QuestionType { get; set; }

        public int ExamId { get; set; }
        public Exam Exam { get; set; }

        public ICollection<AnswerOption> AnswerOptions { get; set; }

    }
}
