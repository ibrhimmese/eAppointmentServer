using eAppointmentServer.Domain.Entities;
using eAppointmentServer.Domain.Repositories;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Data;
using TS.Result;

namespace eAppointmentServer.Application.Features.Users.GetAllUsers;

internal sealed class GetAllUsersQuryHandler(
    UserManager<AppUser> userManager,
    IUserRoleRepository userRoleRepository,
    RoleManager<AppRole> roleManager
    ) : IRequestHandler<GetAllUsersQury, Result<List<GetAllUsersQueryResponse>>>
{
    public async Task<Result<List<GetAllUsersQueryResponse>>> Handle(GetAllUsersQury request, CancellationToken cancellationToken)
    {
        List<AppUser> users = await userManager.Users.OrderBy(p=>p.FirstName).ToListAsync(cancellationToken);
        List<GetAllUsersQueryResponse> response = users.Select(s => new GetAllUsersQueryResponse()
        {
            Id = s.Id,
            FirstName = s.FirstName,
            LastName = s.LastName,
            FullName=s.FullName,
            UserName = s.UserName,
            Email = s.Email,

        }).ToList();

        foreach(var user in response)
        {
            List<AppUserRole> userRoles = await userRoleRepository.Where(p => p.UserId == user.Id).ToListAsync(cancellationToken);

            List<Guid> stringRoles = new();
            List<string?> stringRoleNames = new();

            foreach (var userRole in userRoles)
            {
                AppRole? role = await roleManager.Roles.Where(p=>p.Id==userRole.RoleId).FirstOrDefaultAsync(cancellationToken);

                if(role is not null)
                {
                    stringRoles.Add(role.Id);
                    stringRoleNames.Add(role.Name);
                }
            }
            user.RoleIds = stringRoles;
            user.RoleNames = stringRoleNames;
        }
        return response;
        
    }
}
