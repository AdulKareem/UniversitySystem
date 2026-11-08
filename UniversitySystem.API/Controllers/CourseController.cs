using Microsoft.AspNetCore.Mvc;
using UniversitySystem.Core.DTO;
using UniversitySystem.Core.Models;
using UniversitySystem.Core.Service;

[ApiController]
[Route("api/[controller]")]
public class CourseController : ControllerBase
{
    private readonly ICourseService courseService;

    public CourseController(ICourseService _courseService)
    {
        courseService = _courseService;
    }

    [HttpGet]
    public IActionResult GetAllCourses()
    {
        return Ok(courseService.GetAllCourses());
    }

    [HttpGet("{courseId:int}")]
    public IActionResult GetCourseById(int courseId)
    {
        return Ok(courseService.GetCourseById(courseId));
    }

    [HttpGet("department/{departmentId:int}")]
    public IActionResult GetCoursesByDepartment(int departmentId)
    {
        return Ok(courseService.GetCoursesByDepartment(departmentId));
    }

    [HttpGet("featured")]
    public IActionResult GetFeaturedCourses()
    {
        return Ok(courseService.GetFeaturedCourses());
    }

    [HttpGet("search")]
    public IActionResult SearchCourses([FromQuery] string? search, [FromQuery] int? departmentId,
                                       [FromQuery] int? creditHours, [FromQuery] string sortBy = "CODE")
    {
        return Ok(courseService.SearchCourses(search, departmentId, creditHours, sortBy));
    }

    [HttpPost]
    public IActionResult CreateCourse([FromBody] CreateCourseDto dto)
    {
        var course = new Course
        {
           Coursecode  = dto.CourseCode,
           Coursename = dto.CourseName,
           Coursedescription = dto.CourseDescription,
            Credithours = dto.CreditHours,
            Isfeatured = dto.IsFeatured,
            Departmentid = dto.DepartmentId
        };

        int newId = courseService.CreateCourse(course);
        return CreatedAtAction(nameof(GetCourseById), new { courseId = newId }, new { courseId = newId });
    }


    [HttpPut("{courseId:int}")]
    public IActionResult UpdateCourse(int courseId, [FromBody] UpdateCourseDto dto)
    {
        var course = new Course
        {
            Courseid = courseId,
            Coursecode = dto.CourseCode,
            Coursename = dto.CourseName,
            Coursedescription = dto.CourseDescription,
            Credithours = dto.CreditHours,
            Isfeatured = dto.IsFeatured,
            Departmentid = dto.DepartmentId
        };

        courseService.UpdateCourse(course);
        return NoContent();
    }

    [HttpDelete("{courseId:int}")]
    public IActionResult DeleteCourse(int courseId)
    {
        courseService.DeleteCourse(courseId);
        return NoContent();
    }
}
