namespace InternalTraining.Models
{
    public class AnswerOption
    {
        public int Id { get; set; }
        public string CorrectedAnswer { get; set; }  // e.g., "True", "False", "Choice A", etc.
        public bool IsCorrect { get; set; }  // True if this is the correct answer

        public int QuestionId { get; set; }
        public Question Question { get; set; } = null!;

    }
}
