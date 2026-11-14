using Microsoft.AspNetCore.Mvc;
using UniversitySystem.Core.DTO;
using UniversitySystem.Core.Service;

[ApiController]
[Route("api/[controller]")]
public class InstructorController : ControllerBase
{
    private readonly IInstructorService instructorService;

    public InstructorController(IInstructorService _instructorService)
    {
        instructorService = _instructorService;
    }

    [HttpGet]
    public IActionResult GetAllInstructors()
    {
        return Ok(instructorService.GetAllInstructors());
    }

    [HttpGet("{instructorId:int}")]
    public IActionResult GetInstructorById(int instructorId)
    {
        var instructor = instructorService.GetInstructorById(instructorId);
        return instructor == null ? NotFound(new { error = "Instructor was not found." }) : Ok(instructor);
    }

    [HttpGet("department/{departmentId:int}")]
    public IActionResult GetInstructorsByDepartment(int departmentId)
    {
        return Ok(instructorService.GetInstructorsByDepartment(departmentId));
    }

    [HttpPost]
    public IActionResult CreateInstructor([FromBody] InstructorRequestDto dto)
    {
        int newId = instructorService.CreateInstructor(dto);
        return CreatedAtAction(nameof(GetInstructorById), new { instructorId = newId }, new { instructorId = newId });
    }

    [HttpPut("{instructorId:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult UpdateInstructor(int instructorId, [FromBody] InstructorRequestDto dto)
    {
        instructorService.UpdateInstructor(instructorId, dto);
        return NoContent();
    }

    [HttpDelete("{instructorId:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult DeleteInstructor(int instructorId)
    {
        instructorService.DeleteInstructor(instructorId);
        return NoContent();
    }
}
