using eAppointment.Infrastructure.Context;
using eAppointmentServer.Domain.Entities;
using eAppointmentServer.Domain.Repositories;
using GenericRepository;

namespace eAppointment.Infrastructure.Repositories;

internal sealed class UserRoleRepository : Repository<AppUserRole, ApplicationDbContext>, IUserRoleRepository
{
    public UserRoleRepository(ApplicationDbContext context) : base(context)
    {
    }
}
