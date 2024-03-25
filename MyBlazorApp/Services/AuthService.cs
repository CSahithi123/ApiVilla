using ViewModels;
using MyBlazorApp.Service;
using System.Net.Http.Json;
using MyBlazorApp.Services;
using System.Threading.Tasks;
using MyBlazorApp.Services;

namespace MyBlazorApp.Service
{
    public class AuthService : IAuthService
    {
        // You can inject any necessary services here, such as a database context or another service
        public AuthService()
        {
        }

        public async Task<bool> LoginAsync(string username, string password)
        {
            try
            {
                if (username == "Sweety12" && password == "Sweety@123")
                {
                    // Authentication successful
                    return true;
                }
                else
                {
                    // Authentication failed
                    return false;
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions and return false
                Console.WriteLine($"An error occurred during login: {ex.Message}");
                return false;
            }
        }
    }
}
