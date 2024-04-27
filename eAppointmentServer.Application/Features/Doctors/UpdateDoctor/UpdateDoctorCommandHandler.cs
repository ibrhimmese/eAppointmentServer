using AutoMapper;
using eAppointmentServer.Domain.Entities;
using eAppointmentServer.Domain.Repositories;
using GenericRepository;
using MediatR;
using TS.Result;

namespace eAppointmentServer.Application.Features.Doctors.UpdateDoctor;

internal sealed class UpdateDoctorCommandHandler : IRequestHandler<UpdateDoctorCommand, Result<string>>
{
    private readonly IDoctorRepository _repository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateDoctorCommandHandler(IUnitOfWork unitOfWork, IDoctorRepository repository, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Result<string>> Handle(UpdateDoctorCommand request, CancellationToken cancellationToken)
    {
        Doctor? doctor = await _repository.GetByExpressionWithTrackingAsync(p=>p.Id==request.Id,cancellationToken);
        if (doctor==null)
        {
            return Result<string>.Failure("Doktor Bulunamadı");
        }
        _mapper.Map(request,doctor);

        _repository.Update(doctor);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return "Doktor Güncelleme işlemi başarıyla tamamlandı";
    }
}


