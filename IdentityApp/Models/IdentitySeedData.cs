using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace IdentityApp.Models
{
    public static class IdentitySeedData{
        private const string adminUser = "Admin";
        private const string adminPassword = "Admin_123";

        public static async void IdentityTestUser(IApplicationBuilder app){

            var context = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<IdentityContext>();

            if(context.Database.GetAppliedMigrations().Any()){
                context.Database.Migrate();
            }

            var userManager = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<UserManager<AppUser>>();

            var adminUser = "admin";

            var user = await userManager.FindByNameAsync(adminUser);

            if(user == null){
                user = new AppUser{
                    FullName = "Ahmet Kaya",
                    UserName = adminUser,
                    Email = "admin@ahmetkaya.com",
                    PhoneNumber = "321654987"
                };

                await userManager.CreateAsync(user, adminPassword);
            }
        }
    }
}