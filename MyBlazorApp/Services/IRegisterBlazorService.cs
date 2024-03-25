using ViewModels;
using static MyBlazorApp.Pages.Register;

namespace MyBlazorApp.Services
{
    public interface IRegisterBlazorService
    {

        Task<bool> RegisterAsync(RegisterAccountForm account);






    }
}
