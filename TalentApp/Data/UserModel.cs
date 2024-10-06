using System;
using System.Collections.Generic;

namespace JobSeekerApp.Data
{
    public class UserModel
    {
        public int Id { get; set; } 
        public string FirstName { get; set; } 
        public string LastName { get; set; }
        public string Location { get; set; } 
        public string PhoneNumber { get; set; } 

        public ICollection<RegistrationModel> Registrations { get; set; } 
        public ICollection<SalaryModel> Salaries { get; set; } 
        public ICollection<JobModel> Jobs { get; set; } 
    }
}