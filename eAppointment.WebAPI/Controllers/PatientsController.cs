using eAppointment.WebAPI.Controllers.Abstractions;
using eAppointmentServer.Application.Features.Doctors.CreateDoctor;
using eAppointmentServer.Application.Features.Doctors.DeleteDoctor;
using eAppointmentServer.Application.Features.Doctors.GetAllDoctor;
using eAppointmentServer.Application.Features.Doctors.UpdateDoctor;
using eAppointmentServer.Application.Features.Patients.CreatePatient;
using eAppointmentServer.Application.Features.Patients.DeletePatient;
using eAppointmentServer.Application.Features.Patients.GetAllPatient;
using eAppointmentServer.Application.Features.Patients.UpdatePatient;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace eAppointment.WebAPI.Controllers;

public class PatientsController : ApiController
{
    public PatientsController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost]
    public async Task<IActionResult> GetAll(GetAllPatientQuery request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }


    [HttpPost]
    public async Task<IActionResult> Create(CreatePatientCommand request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [HttpPost]
    public async Task<IActionResult> DeleteById(DeletePatientCommand request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [HttpPost]
    public async Task<IActionResult> Update(UpdatePatientCommand request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

}
