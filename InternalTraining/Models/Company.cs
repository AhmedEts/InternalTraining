namespace InternalTraining.Models
{
    public class Company
    {
        public string Id { get; set; }  // ForeignKey to ApplicationUser
        public string CompanyName { get; set; }
        public string ProfilePicturePath { get; set; } 
        public ICollection<Employee> Employees { get; set; } 
        public ICollection<CompanyCourse> CompanyCourses { get; set; } = new List<CompanyCourse>();

    }
}
