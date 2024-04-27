using eAppointmentServer.Domain.Entities;
using System.Reflection.Metadata.Ecma335;

namespace eAppointmentServer.Application;

public static class Constants
{

    public static List<AppRole> GetRoles()
    {
        List<string> roles = new()
        {
            "Admin",
            "Doctor",
            "Personel",
            "Hasta"
        };
        return roles.Select(s=> new AppRole() { Name=s}).ToList();
    }
    
}


