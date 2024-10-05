namespace JobSeekerApp.Models
{
    public class SalaryModel
    {
        public int Id { get; set; } // Унікальний ідентифікатор зарплати
        public int UserId { get; set; } // Ідентифікатор користувача
        public decimal CurrentSalary { get; set; } // Поточна зарплата
        public decimal DesiredSalary { get; set; } // Бажана зарплата
    }
}