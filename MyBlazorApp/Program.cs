using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using MyBlazorApp;
using MyBlazorApp.Service;
using MyBlazorApp.Services;


var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.Services.AddMudServices();
builder.Services.AddScoped<IBlazorService, BlazorService>();
builder.Services.AddScoped<IRegisterBlazorService, RegisterBlazorService>();
builder.Services.AddScoped<IAuthService, AuthService>();


builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

await builder.Build().RunAsync();
