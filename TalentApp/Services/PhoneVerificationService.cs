using System;

namespace JobSeekerApp.Services
{
    public class PhoneVerificationService
    {
        // Метод для надсилання SMS
        public void SendVerificationCode(string phoneNumber, string code)
        {
            // Логіка надсилання SMS (використовуйте API SMS-провайдера)
            Console.WriteLine($"Verification code {code} sent to {phoneNumber}.");
        }

        // Метод для верифікації коду
        public bool VerifyCode(string inputCode, string actualCode)
        {
            return inputCode == actualCode; // Просте порівняння, розгляньте більш безпечні варіанти
        }
    }
}