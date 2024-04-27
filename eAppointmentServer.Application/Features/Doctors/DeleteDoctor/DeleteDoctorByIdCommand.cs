using MediatR;
using TS.Result;

namespace eAppointmentServer.Application.Features.Doctors.DeleteDoctor;

public sealed record DeleteDoctorByIdCommand(
    Guid Id
    ):IRequest<Result<string>>;
  

