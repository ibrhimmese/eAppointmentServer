using eAppointment.WebAPI.Controllers.Abstractions;
using eAppointmentServer.Application.Features.Roles.RoleSync;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eAppointment.WebAPI.Controllers;

[AllowAnonymous]
public sealed class RolesController : ApiController
{
    public RolesController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost]
    public async Task<IActionResult> Sync(RoleSyncCommand request, CancellationToken cancellationToken)
    {
       var response= await _mediator.Send(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }
}

