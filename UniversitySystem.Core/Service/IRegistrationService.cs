using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversitySystem.Core.Models;

namespace UniversitySystem.Core.Service
{
    public interface IRegistrationService
    {
        decimal RegisterStudent(decimal studentId, decimal sectionId);

        List<Registration> GetAllRegistrations();

        Registration? GetRegistrationById(decimal registrationId);

        List<Registration> GetStudentRegistrations(decimal studentId);

        List<Sectionschedule> GetStudentSchedules(decimal studentId);

        void CancelRegistration(decimal registrationId);

        void ChangeSection(decimal registrationId, decimal newSectionId);
    }
}