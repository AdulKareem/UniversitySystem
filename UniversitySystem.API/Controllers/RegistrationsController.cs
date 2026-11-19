using Microsoft.AspNetCore.Mvc;
using UniversitySystem.Core.Models;
using UniversitySystem.Core.Service;

namespace UniversitySystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationsController : ControllerBase
    {
        private readonly IRegistrationService registrationService;

        public RegistrationsController(IRegistrationService registrationService)
        {
            this.registrationService = registrationService;
        }

        // GET: api/Registrations
        [HttpGet]
        public IActionResult GetAllRegistrations()
        {
            var result = registrationService.GetAllRegistrations();
            return Ok(result);
        }

        // GET: api/Registrations/5
        [HttpGet("{registrationId}")]
        public IActionResult GetRegistrationById(decimal registrationId)
        {
            var result = registrationService.GetRegistrationById(registrationId);

            if (result == null)
                return NotFound("Registration not found.");

            return Ok(result);
        }

        // GET: api/Registrations/student/5
        [HttpGet("student/{studentId}")]
        public IActionResult GetStudentRegistrations(decimal studentId)
        {
            var result = registrationService.GetStudentRegistrations(studentId);
            return Ok(result);
        }

        // GET: api/Registrations/student/5/schedules
        [HttpGet("student/{studentId}/schedules")]
        public IActionResult GetStudentSchedules(decimal studentId)
        {
            var result = registrationService.GetStudentSchedules(studentId);
            return Ok(result);
        }

        // POST: api/Registrations
        [HttpPost]
        public IActionResult RegisterStudent([FromBody] Registration registration)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var registrationId = registrationService.RegisterStudent(
                registration.Studentid,
                registration.Sectionid);

            return CreatedAtAction(
                nameof(GetRegistrationById),
                new { registrationId = registrationId },
                new { RegistrationId = registrationId }
            );
        }

        // PUT: api/Registrations/5/cancel
        [HttpPut("{registrationId}/cancel")]
        public IActionResult CancelRegistration(decimal registrationId)
        {
            registrationService.CancelRegistration(registrationId);

            return Ok("Registration cancelled successfully.");
        }

        // PUT: api/Registrations/5/change-section/2
        // Future Authorization:
        // [Authorize(Roles = "Admin")]
        [HttpPut("{registrationId}/change-section/{newSectionId}")]
        public IActionResult ChangeSection(decimal registrationId, decimal newSectionId)
        {
            registrationService.ChangeSection(registrationId, newSectionId);

            return Ok("Section changed successfully.");
        }
    }
}