namespace JobSeekerApp.Data
{
    public class ResumeModel
    {
        public int Id { get; set; }  
        public string FilePath { get; set; }  
        public int UserId { get; set; }  

        public UserModel User { get; set; }  
    }
}