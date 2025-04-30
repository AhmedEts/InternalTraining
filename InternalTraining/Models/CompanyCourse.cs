namespace InternalTraining.Models
{
    public class CompanyCourse
    {
        public int Id { get; set; }
        public string CompanyId { get; set; }
        public Company Company { get; set; }

        public int CourseId { get; set; }
        public Course Course { get; set; }

        public string? PaymentStatus { get; set; }

    }
}
