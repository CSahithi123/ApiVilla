using ViewModels;
using MyBlazorApp.Service;
using System.Net.Http.Json;
using MyBlazorApp.Services;
using static MyBlazorApp.Pages.Register;


namespace MyBlazorApp.Service
{
    public class RegisterBlazorService : IRegisterBlazorService
    {
        private readonly HttpClient _httpClient;

        public RegisterBlazorService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> RegisterAsync(RegisterAccountForm account)
        {
            try
            {
                // Assuming you have an API endpoint for registering employees
                HttpResponseMessage response = await _httpClient.PostAsJsonAsync("http://localhost:5085/api/User/register", account);

                // Check if the request was successful
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    // Handle error scenario
                    return false;
                }
            }
            catch (Exception ex)
            {
                // Log or handle the exception
                return false;
            }
        }

    }
}

