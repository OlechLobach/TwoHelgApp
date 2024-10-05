namespace JobSeekerApp.Models
{
    public class ResumeModel
    {
        public int Id { get; set; } // Унікальний ідентифікатор резюме
        public int UserId { get; set; } // Ідентифікатор користувача
        public string FileName { get; set; } // Ім'я файлу резюме
        public byte[] ResumeFile { get; set; } // Файл резюме у вигляді масиву байтів
    }
}