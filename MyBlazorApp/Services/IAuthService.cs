﻿namespace MyBlazorApp.Services
{
    public interface IAuthService
    {
        Task<bool> LoginAsync(string username, string password);

    }
}
 