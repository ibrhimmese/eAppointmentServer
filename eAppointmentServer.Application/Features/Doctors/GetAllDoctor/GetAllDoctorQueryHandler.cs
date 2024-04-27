using eAppointmentServer.Domain.Entities;
using eAppointmentServer.Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TS.Result;

namespace eAppointmentServer.Application.Features.Doctors.GetAllDoctor;

internal sealed class GetAllDoctorQueryHandler : IRequestHandler<GetAllDoctorQuery, Result<List<Doctor>>>
{
    private readonly IDoctorRepository _repository;

    public GetAllDoctorQueryHandler(IDoctorRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<List<Doctor>>> Handle(GetAllDoctorQuery request, CancellationToken cancellationToken)
    {
      List<Doctor> doctors=  await _repository.GetAll().OrderBy(p => p.Department).ThenBy(p => p.FirstName).ToListAsync(cancellationToken);
        return doctors;
    }
}
    

