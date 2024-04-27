using eAppointment.Infrastructure.Context;
using eAppointmentServer.Domain.Entities;
using eAppointmentServer.Domain.Repositories;
using GenericRepository;

namespace eAppointment.Infrastructure.Repositories;

internal class PatientRepository : Repository<Patient, ApplicationDbContext>, IPatientRepository
{
    public PatientRepository(ApplicationDbContext context) : base(context)
    {
    }
}
