﻿namespace ManangementService.Data
{
    using Microsoft.AspNetCore.Identity;

    public static class IdentityOptionsProvider
    {
        public static void GetIdentityOptions(IdentityOptions options, bool isInProduction)
        {
            options.Password.RequireDigit = false;
            options.Password.RequireLowercase = false;
            options.Password.RequireUppercase = false;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequiredLength = 6;

            options.SignIn.RequireConfirmedAccount = false;// isInProduction;
            options.SignIn.RequireConfirmedEmail = false;// isInProduction;

            options.Lockout.MaxFailedAccessAttempts = 15;
            options.Lockout.DefaultLockoutTimeSpan = new System.TimeSpan(hours: 1, 0, 0);
        }
    }
}
