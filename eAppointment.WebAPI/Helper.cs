using eAppointmentServer.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace eAppointment.WebAPI
{
    public static class Helper
    {
        public static async Task CreateUserAsync(WebApplication app)
        {
            //Kullanıcı yoksa bu bilgilerde kullanıcı oluşturur admin 1
            using (var scoped = app.Services.CreateScope())
            {
                var userManager = scoped.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
                if (!userManager.Users.Any())
                {
                   await userManager.CreateAsync(new()
                    {
                        FirstName = "Admin",
                        LastName = "Admin",
                        Email = "admin@admin.com",
                        UserName = "admin"
                    }, "1");
                }
            }
        }
    }
}
