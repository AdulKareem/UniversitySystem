using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversitySystem.Core.Models;

namespace UniversitySystem.Core.Service
{
    public interface ISectionSchedulesService
    {
        public List<Sectionschedule> GetSchedulesBySection(decimal sectionId);

        public List<Sectionschedule> GetSchedulesByCourse(decimal courseId);

        public decimal CreateSchedule(Sectionschedule schedule);

        public  void UpdateSchedule(Sectionschedule schedule);

        public void DeleteSchedule(decimal scheduleId);
    }
}
