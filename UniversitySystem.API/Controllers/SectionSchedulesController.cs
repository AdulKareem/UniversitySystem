using Microsoft.AspNetCore.Mvc;
using UniversitySystem.Core.Models;
using UniversitySystem.Core.Service;

namespace UniversitySystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SectionSchedulesController : ControllerBase
    {
        private readonly ISectionSchedulesService sectionSchedulesService;

        public SectionSchedulesController(ISectionSchedulesService sectionSchedulesService)
        {
            this.sectionSchedulesService = sectionSchedulesService;
        }

        // GET: api/SectionSchedules/section/5
        [HttpGet("section/{sectionId}")]
        public IActionResult GetSchedulesBySection(decimal sectionId)
        {
            var result = sectionSchedulesService.GetSchedulesBySection(sectionId);
            return Ok(result);
        }

        // GET: api/SectionSchedules/course/5
        [HttpGet("course/{courseId}")]
        public IActionResult GetSchedulesByCourse(decimal courseId)
        {
            var result = sectionSchedulesService.GetSchedulesByCourse(courseId);
            return Ok(result);
        }

        // POST: api/SectionSchedules
        // [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult CreateSchedule([FromBody] Sectionschedule schedule)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var scheduleId = sectionSchedulesService.CreateSchedule(schedule);

            return Ok(new { ScheduleId = scheduleId });
        }

        // PUT: api/SectionSchedules/5
        // [Authorize(Roles = "Admin")]
        [HttpPut("{scheduleId}")]
        public IActionResult UpdateSchedule(
            decimal scheduleId,
            [FromBody] Sectionschedule schedule)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            schedule.Scheduleid = scheduleId;

            sectionSchedulesService.UpdateSchedule(schedule);

            return Ok("Schedule updated successfully.");
        }

        // DELETE: api/SectionSchedules/5
        // [Authorize(Roles = "Admin")]
        [HttpDelete("{scheduleId}")]
        public IActionResult DeleteSchedule(decimal scheduleId)
        {
            sectionSchedulesService.DeleteSchedule(scheduleId);

            return Ok("Schedule deleted successfully.");
        }
    }
}