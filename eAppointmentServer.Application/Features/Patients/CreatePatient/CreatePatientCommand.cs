﻿using AutoMapper;
using eAppointmentServer.Domain.Entities;
using eAppointmentServer.Domain.Repositories;
using GenericRepository;
using MediatR;
using TS.Result;

namespace eAppointmentServer.Application.Features.Patients.CreatePatient;

public sealed record CreatePatientCommand(
    string FirstName
    , string LastName
    , string IdentityNumber
    , string City
    , string Town
    , string FullAddress
    ) : IRequest<Result<string>>;



internal sealed class CreatePatientCommandHandler(
    IPatientRepository patientRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper
    ) : IRequestHandler<CreatePatientCommand, Result<string>>
{
    public async Task<Result<string>> Handle(CreatePatientCommand request, CancellationToken cancellationToken)
    {
        if (patientRepository.Any(p => p.IdentityNumber == request.IdentityNumber))
        {
            return Result<string>.Failure("Hasta zaten kayıtlı");
        }
        Patient patient = mapper.Map<Patient>(request);
        await patientRepository.AddAsync(patient,cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return "Hasta kaydı başarıyla oluşturuldu";
    }
}
