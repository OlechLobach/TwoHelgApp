using System;

namespace JobSeekerApp.Data
{
    public class RegistrationModel
    {
        public int Id { get; set; } 
        public int UserId { get; set; } 
        public DateTime RegistrationDate { get; set; } 

        public UserModel User { get; set; }
    }
}
