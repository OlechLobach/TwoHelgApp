namespace JobSeekerApp.Data
{
    public class UserModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Location { get; set; }
        public decimal CurrentSalary { get; set; }
        public decimal DesiredSalary { get; set; }
        public string CurrentJob { get; set; }
        public string DesiredJob { get; set; }
        public string PhoneNumber { get; set; }

        public string FullName => $"{FirstName} {LastName}"; 
    }
}