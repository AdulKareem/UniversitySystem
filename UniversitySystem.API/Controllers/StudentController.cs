using Microsoft.AspNetCore.Mvc;
using UniversitySystem.Core.DTO;
using UniversitySystem.Core.Service;

[ApiController]
[Route("api/[controller]")]
public class StudentController : ControllerBase
{
    private readonly IStudentService studentService;

    public StudentController(IStudentService _studentService)
    {
        studentService = _studentService;
    }

    [HttpGet]
    public IActionResult GetAllStudents()
    {
        return Ok(studentService.GetAllStudents());
    }

    [HttpGet("{studentId:int}")]
    public IActionResult GetStudentById(int studentId)
    {
        var student = studentService.GetStudentById(studentId);
        return student == null ? NotFound(new { error = "Student was not found." }) : Ok(student);
    }

    // البحث بالرقم الجامعي (تطابق تام، بغض النظر عن حالة الأحرف)
    [HttpGet("university/{universityId}")]
    public IActionResult GetStudentByUniversityId(string universityId)
    {
        var student = studentService.GetStudentByUniversityId(universityId);
        return student == null ? NotFound(new { error = "Student was not found." }) : Ok(student);
    }

    // تسجيل طالب جديد
    [HttpPost]
    public IActionResult CreateStudent([FromBody] StudentRequestDto dto)
    {
        int newId = studentService.CreateStudent(dto);
        return CreatedAtAction(nameof(GetStudentById), new { studentId = newId }, new { studentId = newId });
    }

    [HttpPut("{studentId:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult UpdateStudent(int studentId, [FromBody] StudentRequestDto dto)
    {
        studentService.UpdateStudent(studentId, dto);
        return NoContent();
    }

    [HttpDelete("{studentId:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult DeleteStudent(int studentId)
    {
        studentService.DeleteStudent(studentId);
        return NoContent();
    }
}