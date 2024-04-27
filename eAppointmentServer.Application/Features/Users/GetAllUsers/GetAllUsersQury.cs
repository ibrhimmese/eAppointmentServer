using MediatR;
using TS.Result;

namespace eAppointmentServer.Application.Features.Users.GetAllUsers;

public sealed record GetAllUsersQury():IRequest<Result<List<GetAllUsersQueryResponse>>>;
