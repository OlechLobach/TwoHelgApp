using System.Threading.Tasks;

namespace MyApp.Services
{
    public class AuthService
    {
        public Task<(bool isSuccess, string token, string message)> LoginAsync(LoginModel loginModel)
        {
            // Add actual authentication logic here.
            // This is just a placeholder.
            if (loginModel.Username == "admin" && loginModel.Password == "password")
            {
                return Task.FromResult<(bool, string, string)>((true, "dummy-token", "Login successful"));
            }
            return Task.FromResult<(bool, string, string)>((false, null, "Invalid credentials"));
        }
    }

    public class LoginModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}