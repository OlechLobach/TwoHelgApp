using System;

namespace JobSeekerApp.Services
{
    public class PhoneVerificationService
    {
        // Метод для верифікації коду
        public bool VerifyCode(string enteredCode)
        {
            // Тут можна додати логіку для перевірки коду, якщо потрібно
            // Наприклад, ви можете зберігати код у пам'яті або використовувати його для подальшої перевірки
            if (enteredCode.Length == 6 && int.TryParse(enteredCode, out _))
            {
                return true; // Якщо код 6-значний, повертаємо true
            }
            return false; // Інакше повертаємо false
        }
    }
}