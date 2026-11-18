using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversitySystem.Core.Models;
using UniversitySystem.Core.Repository;
using UniversitySystem.Core.Service;
namespace UniversitySystem.Infra.Service
{
    public class SectionSchedulesService : ISectionSchedulesService
    {
        private readonly ISectionSchedulesRepository sectionSchedulesRepository;

        public SectionSchedulesService(ISectionSchedulesRepository sectionSchedulesRepository)
        {
            this.sectionSchedulesRepository = sectionSchedulesRepository;
        }

        public List<Sectionschedule> GetSchedulesBySection(decimal sectionId)
        {
            return sectionSchedulesRepository.GetSchedulesBySection(sectionId);
        }

        public List<Sectionschedule> GetSchedulesByCourse(decimal courseId)
        {
            return sectionSchedulesRepository.GetSchedulesByCourse(courseId);
        }

        public decimal CreateSchedule(Sectionschedule schedule)
        {
            return sectionSchedulesRepository.CreateSchedule(schedule);
        }

        public void UpdateSchedule(Sectionschedule schedule)
        {
            sectionSchedulesRepository.UpdateSchedule(schedule);
        }

        public void DeleteSchedule(decimal scheduleId)
        {
            sectionSchedulesRepository.DeleteSchedule(scheduleId);
        }
    }
}