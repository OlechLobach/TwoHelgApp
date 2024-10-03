namespace JobSeekerApp.Data
{
    public class ResumeModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string FilePath { get; set; }  // Шлях до файлу з резюме
        public DateTime UploadDate { get; set; }
    }
}