using eAppointmentServer.Domain.Entities;
using eAppointmentServer.Domain.Repositories;
using GenericRepository;
using MediatR;
using TS.Result;

namespace eAppointmentServer.Application.Features.Doctors.DeleteDoctor;

internal sealed class DeleteDoctorByIdCommandHandler : IRequestHandler<DeleteDoctorByIdCommand, Result<string>>
{
    private readonly IDoctorRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteDoctorByIdCommandHandler(IUnitOfWork unitOfWork, IDoctorRepository repository)
    {
        _unitOfWork = unitOfWork;
        _repository = repository;
    }

    public async Task<Result<string>> Handle(DeleteDoctorByIdCommand request, CancellationToken cancellationToken)
    {
       Doctor? doctor=await _repository.GetByExpressionAsync(p=>p.Id==request.Id, cancellationToken);
        if(doctor==null)
        {
            return Result<string>.Failure("Doktor Bulunamadı");
        }
        _repository.Delete(doctor);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return "Doktor başarıyla silindi";
    }
}
  

