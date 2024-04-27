using AutoMapper;
using eAppointmentServer.Domain.Entities;
using eAppointmentServer.Domain.Repositories;
using GenericRepository;
using MediatR;
using TS.Result;

namespace eAppointmentServer.Application.Features.Patients.UpdatePatient;

internal sealed class UpdatePatientCommandHandler(
    IPatientRepository patientRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper

    ) : IRequestHandler<UpdatePatientCommand, Result<string>>
{
    public async Task<Result<string>> Handle(UpdatePatientCommand request, CancellationToken cancellationToken)
    {
        Patient? patient = await patientRepository.GetByExpressionWithTrackingAsync(p => p.Id == request.Id,cancellationToken);
        if(patient == null )
        {
            return Result<string>.Failure("Hasta bulunamadı");
        }

        if(patient.IdentityNumber != request.IdentityNumber)
        {
            if (patientRepository.Any(p => p.IdentityNumber == request.IdentityNumber))
            {
                return Result<string>.Failure("Bu Tc ye kayıtlı hasta bulunmaktadır");
            }
        }

        mapper.Map(request, patient);
        patientRepository.Update(patient);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return "Hasta başarıyla güncellendi";

    }
}
