using System.ComponentModel.DataAnnotations;

namespace JobSeekerApp.Models
{
    public class UserModel
    {
        [Key] // Вказуємо, що це первинний ключ
        public int Id { get; set; } // Унікальний ідентифікатор користувача

        public string FirstName { get; set; } // Ім'я користувача
        public string LastName { get; set; } // Прізвище користувача
        public string Location { get; set; } // Місце розташування
        public string PhoneNumber { get; set; } // Номер телефону

        public string CurrentJob { get; set; } // Поточне місце роботи
        public string DesiredJob { get; set; } // Бажане місце роботи
    }
}