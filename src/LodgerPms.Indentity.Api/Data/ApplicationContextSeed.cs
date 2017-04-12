﻿namespace Microsoft.LodgerPms.Services.Catalog.API.Infrastructure
{
    using AspNetCore.Identity;
    using EntityFrameworkCore;
    using Extensions.Logging;
    using global::LodgerPms.Indentity.Api.Data;
    using global::LodgerPms.Indentity.Api.Models;
    using Microsoft.AspNetCore.Builder;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Threading.Tasks;

    public class ApplicationContextSeed
    {
        private readonly IPasswordHasher<ApplicationUser> _passwordHasher;

        public ApplicationContextSeed(IPasswordHasher<ApplicationUser> passwordHasher)
        {
            _passwordHasher = passwordHasher;
        }

        public async Task SeedAsync(IApplicationBuilder applicationBuilder, ILoggerFactory loggerFactory, int? retry = 0)
        {
            int retryForAvaiability = retry.Value;
            try
            {
                var context = (ApplicationDbContext)applicationBuilder
                    .ApplicationServices.GetService(typeof(ApplicationDbContext));

                context.Database.Migrate();

                if (!context.Users.Any())
                {
                    context.Users.AddRange(
                        GetDefaultUser());

                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                if (retryForAvaiability < 10)
                {
                    retryForAvaiability++;
                    var log = loggerFactory.CreateLogger("catalog seed");
                    log.LogError(ex.Message);
                    await SeedAsync(applicationBuilder, loggerFactory, retryForAvaiability);
                }
            }
        }

        private ApplicationUser GetDefaultUser()
        {
            var user = 
            new ApplicationUser()
            {
                CardHolderName = "DemoUser",
                CardNumber = "4012888888881881",
                CardType = 1,
                City = "Tacom,a",
                Country = "U.S.",
                Email = "demouser@LodgerPms.com",
                Expiration = "12/20",
                Id = Guid.NewGuid().ToString(), 
                LastName = "DemoLastName", 
                Name = "DemoUser", 
                PhoneNumber = "1234567890", 
                UserName = "demouser@LodgerPms.com", 
                ZipCode = "98052", 
                State = "WA", 
                Street = "15703 NE 61st Ct", 
                SecurityNumber = "535", 
                NormalizedEmail = "DEMOUSER@LodgerPms.COM", 
                NormalizedUserName = "DEMOUSER@LodgerPms.COM", 
                SecurityStamp = Guid.NewGuid().ToString("D")
            };

            user.PasswordHash = _passwordHasher.HashPassword(user, "Pass@word1");

            return user;
        }
    }
}
