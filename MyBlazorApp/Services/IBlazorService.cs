using ViewModels;

namespace MyBlazorApp.Services
{
    public interface IBlazorService
    {
        Task<List<VillaVM>> GetAll();
        Task<int> Add(VillaVM villa);
        Task Delete(int villaId);

        Task<VillaVM> GetVillaById(int villaId);

        Task Update(VillaVM updatedVilla);


    }
}
