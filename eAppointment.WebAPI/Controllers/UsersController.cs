using eAppointment.WebAPI.Controllers.Abstractions;
using eAppointmentServer.Application.Features.Doctors.CreateDoctor;
using eAppointmentServer.Application.Features.Doctors.DeleteDoctor;
using eAppointmentServer.Application.Features.Doctors.GetAllDoctor;
using eAppointmentServer.Application.Features.Doctors.UpdateDoctor;
using eAppointmentServer.Application.Features.Users.CreateUser;
using eAppointmentServer.Application.Features.Users.DeleteUserById;
using eAppointmentServer.Application.Features.Users.GetAllRolesForUsers;
using eAppointmentServer.Application.Features.Users.GetAllUsers;
using eAppointmentServer.Application.Features.Users.UpdateUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace eAppointment.WebAPI.Controllers;

public sealed class UsersController : ApiController
{
    public UsersController(IMediator mediator) : base(mediator)
    {
    }


    [HttpPost]
    public async Task<IActionResult> GetAll(GetAllUsersQury request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [HttpPost]
    public async Task<IActionResult> GetAllRoles(GetAllRolesForUsersQuery request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }


    [HttpPost]
    public async Task<IActionResult> Create(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [HttpPost]
    public async Task<IActionResult> DeleteById(DeleteUserByIdCommand request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [HttpPost]
    public async Task<IActionResult> Update(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }
}
