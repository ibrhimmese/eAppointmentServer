using eAppointmentServer.Domain.Entities;
using eAppointmentServer.Domain.Repositories;
using GenericRepository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TS.Result;

namespace eAppointmentServer.Application.Features.Patients.DeletePatient;

internal sealed class DeletePatientCommandHandler(IPatientRepository patientRepository,
    IUnitOfWork unitOfWork
    
    ) : IRequestHandler<DeletePatientCommand, Result<string>>
{
    public async Task<Result<string>> Handle(DeletePatientCommand request, CancellationToken cancellationToken)
    {
        Patient? patient = await patientRepository.GetByExpressionAsync(p => p.Id == request.Id, cancellationToken);
        if (patient == null)
        {
            return Result<string>.Failure("Hasta Bulunamadı");
        }

       

        patientRepository.Delete(patient);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return "Hasta kaydı başarıyla silindi";
    }
}
