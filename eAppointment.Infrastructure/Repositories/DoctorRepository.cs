using eAppointment.Infrastructure.Context;
using eAppointmentServer.Domain.Entities;
using eAppointmentServer.Domain.Repositories;
using GenericRepository;

namespace eAppointment.Infrastructure.Repositories;

internal class DoctorRepository : Repository<Doctor, ApplicationDbContext>, IDoctorRepository
{
    public DoctorRepository(ApplicationDbContext context) : base(context)
    {
    }
}
