using System.Threading.Tasks;

namespace JobSeekerApp.Services
{
    public class PhoneVerificationService
    {
        public async Task SendVerificationCode(string phoneNumber)
        {
            await Task.Run(() =>
            {
                System.Console.WriteLine($"SMS sent to {phoneNumber} with verification code.");
            });
        }

        public bool VerifyCode(string inputCode, string actualCode)
        {
            return inputCode == actualCode; 
        }
    }
}