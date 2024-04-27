using AutoMapper;
using eAppointmentServer.Domain.Entities;
using eAppointmentServer.Domain.Repositories;
using GenericRepository;
using MediatR;
using TS.Result;

namespace eAppointmentServer.Application.Features.Doctors.CreateDoctor;

internal sealed class CreateDoctorCommandHandler : IRequestHandler<CreateDoctorCommand, Result<string>>
{
    private readonly IDoctorRepository _repository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateDoctorCommandHandler(IUnitOfWork unitOfWork, IDoctorRepository repository, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Result<string>> Handle(CreateDoctorCommand request, CancellationToken cancellationToken)
    {
        Doctor doctor = _mapper.Map<Doctor>(request);
        await _repository.AddAsync(doctor,cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return "Doctor başarıyla eklendi";
    }
}

