using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace InternalTraining.Models
{
    public class Lesson
    {
        public int Id { get; set; }
        public int ChapterId { get; set; }

        [ValidateNever]
        public Chapter Chapter { get; set; }

        public string Title { get; set; }
        public string ContentUrl { get; set; }

    }
}
