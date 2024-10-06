using System;

namespace JobSeekerApp.Data
{
    public class JobModel
    {
        public int Id { get; set; }  
        public int UserId { get; set; }  
        public string Title { get; set; }  
        public string Type { get; set; }  
        public DateTime EffectiveDate { get; set; }  

        public UserModel User { get; set; }  
    }
}