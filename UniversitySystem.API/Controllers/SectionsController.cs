
using Microsoft.AspNetCore.Mvc;
using UniversitySystem.Core.Models;
using UniversitySystem.Core.Service;

namespace UniversitySystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SectionsController : ControllerBase
    {
        private readonly ISectionService sectionService;

        public SectionsController(ISectionService sectionService)
        {
            this.sectionService = sectionService;
        }

        // GET: api/Sections
        [HttpGet]
        public IActionResult GetAllSections()
        {
            var result = sectionService.GetAllSections();
            return Ok(result);
        }

        // GET: api/Sections/5
        [HttpGet("{sectionId}")]
        public IActionResult GetSectionById(decimal sectionId)
        {
            var result = sectionService.GetSectionById(sectionId);

            if (result == null)
                return NotFound("Section not found.");

            return Ok(result);
        }

        // GET: api/Sections/course/5
        [HttpGet("course/{courseId}")]
        public IActionResult GetSectionsByCourse(decimal courseId)
        {
            var result = sectionService.GetSectionsByCourse(courseId);
            return Ok(result);
        }

        // POST: api/Sections
        // Future Authorization:
        //[Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult CreateSection([FromBody] Section section)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var sectionId = sectionService.CreateSection(section);

            return CreatedAtAction(
                nameof(GetSectionById),
                new { sectionId = sectionId },
                new { SectionId = sectionId }
            );
        }

        // PUT: api/Sections/5
        // Future Authorization:
        // [Authorize(Roles = "Admin")]
        [HttpPut("{sectionId}")]
        public IActionResult UpdateSection(
            decimal sectionId,
            [FromBody] Section section)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            section.Sectionid = sectionId;

            sectionService.UpdateSection(section);

            return Ok("Section updated successfully.");
        }

        // DELETE: api/Sections/5
        // Future Authorization:
        // [Authorize(Roles = "Admin")]
        [HttpDelete("{sectionId}")]
        public IActionResult DeleteSection(decimal sectionId)
        {
            sectionService.DeleteSection(sectionId);

            return Ok("Section deleted successfully.");
        }
    }
}
