namespace InternalTraining.Models
{
    public class Employee
    {
        public string Id { get; set; }  // ForeignKey to ApplicationUser
        public string ProfilePicturePath { get; set; }
        public string Department { get; set; }  // Example of additional fields specific to Employees
        public ICollection<Certificate> Certificates { get; set; }  // ← Add this


    }
}
