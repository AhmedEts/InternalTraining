namespace InternalTraining.Models
{
    public class Company
    {
        public string Id { get; set; }  // ForeignKey to ApplicationUser
        public string CompanyName { get; set; }
        public string ProfilePicturePath { get; set; }  // Profile picture for the company
        public ICollection<Employee> Employees { get; set; }  // List of employees in this company

    }
}
