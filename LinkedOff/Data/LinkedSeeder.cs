using LinkedOff.Data.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkedOff.Data
{
 
    public class LinkedSeeder
    {
        private readonly LinkedContext _ctx;
        private readonly IHostingEnvironment _hosting;
        private readonly UserManager<LinkedUser> _userManager;

        public LinkedSeeder(LinkedContext ctx,
            IHostingEnvironment hosting,
            UserManager<LinkedUser> userManager)
        {
            _ctx = ctx;
            _hosting = hosting;
            _userManager = userManager;
        }

        public async Task Seed()
        {
            //_ctx.Database.EnsureCreated();

            var user = await _userManager.FindByEmailAsync("Vikbe@linkedoff.io");

            if (user == null)
            {
                user = new LinkedUser()
                {
                    FirstName = "Viktor",
                    LastName = "Berglind",
                    UserName = "Vikbe@linkedoff.io",
                    Email = "Vikbe@linkedoff.io"
                };

                var result = await _userManager.CreateAsync(user, "P@ssw0rd!");
                if (result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Failed to create default user");
                }
            }

            _ctx.SaveChanges();
        }

    }
    
}