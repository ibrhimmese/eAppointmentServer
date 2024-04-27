using eAppointment.Infrastructure.Context;
using eAppointmentServer.Domain.Entities;
using eAppointmentServer.Domain.Repositories;
using GenericRepository;

namespace eAppointment.Infrastructure.Repositories;

internal class AppointmentRepository : Repository<Appointment, ApplicationDbContext>, IAppointmentRepository
{
    public AppointmentRepository(ApplicationDbContext context) : base(context)
    {
    }
}
