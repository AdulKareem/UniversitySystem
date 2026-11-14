using Microsoft.AspNetCore.Mvc;
using UniversitySystem.Core.DTO;
using UniversitySystem.Core.Service;

[ApiController]
[Route("api/[controller]")]
public class DepartmentController : ControllerBase
{
    private readonly IDepartmentService departmentService;

    public DepartmentController(IDepartmentService _departmentService)
    {
        departmentService = _departmentService;
    }

    [HttpGet]
    public IActionResult GetAllDepartments()
    {
        return Ok(departmentService.GetAllDepartments());
    }

    [HttpGet("{departmentId:int}")]
    public IActionResult GetDepartmentById(int departmentId)
    {
        var dept = departmentService.GetDepartmentById(departmentId);
        return dept == null ? NotFound(new { error = "Department was not found." }) : Ok(dept);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult CreateDepartment([FromBody] DepartmentRequestDto dto)
    {
        int newId = departmentService.CreateDepartment(dto.DepartmentName);
        return CreatedAtAction(nameof(GetDepartmentById), new { departmentId = newId }, new { departmentId = newId });
    }

    [HttpPut("{departmentId:int}")]
    public IActionResult UpdateDepartment(int departmentId, [FromBody] DepartmentRequestDto dto)
    {
        departmentService.UpdateDepartment(departmentId, dto.DepartmentName);
        return NoContent();
    }

    [HttpDelete("{departmentId:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult DeleteDepartment(int departmentId)
    {
        departmentService.DeleteDepartment(departmentId);
        return NoContent();
    }
}