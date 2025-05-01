namespace InternalTraining.Models
{
    public class Employee
    {
        public string Id { get; set; }  
        public string ProfilePicturePath { get; set; }
        public string Department { get; set; }  
        public ICollection<Certificate> Certificates { get; set; }  


    }
}
