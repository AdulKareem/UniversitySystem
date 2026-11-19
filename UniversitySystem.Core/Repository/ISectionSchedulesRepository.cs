using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversitySystem.Core.Models;


namespace UniversitySystem.Core.Repository
{
    public interface ISectionSchedulesRepository
    {
        List<Sectionschedule> GetSchedulesBySection(decimal sectionId);

        List<Sectionschedule> GetSchedulesByCourse(decimal courseId);

        decimal CreateSchedule(Sectionschedule schedule);

        void UpdateSchedule(Sectionschedule schedule);

        void DeleteSchedule(decimal scheduleId);
    }
}