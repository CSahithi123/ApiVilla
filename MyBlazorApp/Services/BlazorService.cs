using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using MyBlazorApp.Services;
using System.Net.Http.Json;
using ViewModels;



public class BlazorService : IBlazorService

{
    private readonly HttpClient _httpClient;
    private readonly IJSRuntime _jsRuntime;
   
    private List<VillaVM> villas;
    public BlazorService(HttpClient httpClient, IJSRuntime jsRuntime)
    {
        _httpClient = httpClient;
        villas = new List<VillaVM>();
        _jsRuntime = jsRuntime;
    }
    public async Task<List<VillaVM>> GetAll()
    {

        var fetchedVillas = await _httpClient.GetFromJsonAsync<List<VillaVM>>("http://localhost:5085/api/Villa");
        villas.Clear();
        villas.AddRange(fetchedVillas);
        return villas;

    }

    public async Task<int> Add(VillaVM villa)
    {
        var response = await _httpClient.PostAsJsonAsync("http://localhost:5085/api/Villa", villa);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<VillaVM>();
        if (responseData != null && !string.IsNullOrEmpty(responseData.Name))
        {
            return responseData.Name.GetHashCode();
        }
        else
        {
            throw new InvalidOperationException("Unable to extract ID from the API response.");
        }
    }

    public async Task Delete(int villaId)
    {
        try
        {
            var response = await _httpClient.DeleteAsync($"http://localhost:5085/api/Villa/{villaId}");
            response.EnsureSuccessStatusCode(); 
            var deletedVilla = villas.FirstOrDefault(p => p.Id == villaId);
            if (deletedVilla != null)
            {
                villas.Remove(deletedVilla);

            }

        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error deleting product: {ex.Message}");
        }

    }
   public async Task<VillaVM> GetVillaById(int villaId)
    {
        var villa = await _httpClient.GetFromJsonAsync<VillaVM>($"http://localhost:5085/api/Villa/{villaId}");
        return villa;
    }

    public async Task Update(VillaVM updatedVilla)
    {
        try
        {

            int villaId = updatedVilla.Id;
            var response = await _httpClient.PutAsJsonAsync($"http://localhost:5085/api/Villa/{villaId}", updatedVilla);
            response.EnsureSuccessStatusCode();
            var existingVilla = villas.FirstOrDefault(p => p.Id == updatedVilla.Id);
            if (existingVilla != null)

            {

                existingVilla.Name = updatedVilla.Name;
                existingVilla.Price = updatedVilla.Price;
                existingVilla.Description = updatedVilla.Description;
                existingVilla.Sqft = updatedVilla.Sqft;
                existingVilla.Occupancy = updatedVilla.Occupancy;
                existingVilla.ImageUrl = updatedVilla.ImageUrl;

               

            }

            await _jsRuntime.InvokeVoidAsync("showSuccessToast", "Villa Updated");

        }

        catch (Exception ex)//if exception
        {
            Console.WriteLine($"Error updating product: {ex.Message}");
        }

    }

}

