namespace JobSeekerApp.Models
{
    public class JobModel
    {
        public int Id { get; set; } // ID роботи
        public string Title { get; set; } // Заголовок роботи
        public decimal Salary { get; set; } // Зарплата
        public string Type { get; set; } // Тип роботи (поточна, бажана тощо)
    }
}