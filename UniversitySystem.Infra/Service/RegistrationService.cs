using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using UniversitySystem.Core.Models;
using UniversitySystem.Core.Repository;
using UniversitySystem.Core.Service;

namespace UniversitySystem.Infra.Service
{
    public class RegistrationService : IRegistrationService
    {
        private readonly IRegistrationRepository registrationRepository;

        public RegistrationService(IRegistrationRepository registrationRepository)
        {
            this.registrationRepository = registrationRepository;
        }

        public decimal RegisterStudent(decimal studentId, decimal sectionId)
        {
            return registrationRepository.RegisterStudent(studentId, sectionId);
        }

        public List<Registration> GetAllRegistrations()
        {
            return registrationRepository.GetAllRegistrations();
        }

        public Registration? GetRegistrationById(decimal registrationId)
        {
            return registrationRepository.GetRegistrationById(registrationId);
        }

        public List<Registration> GetStudentRegistrations(decimal studentId)
        {
            return registrationRepository.GetStudentRegistrations(studentId);
        }

        public List<Sectionschedule> GetStudentSchedules(decimal studentId)
        {
            return registrationRepository.GetStudentSchedules(studentId);
        }

        public void CancelRegistration(decimal registrationId)
        {
            registrationRepository.CancelRegistration(registrationId);
        }

        public void ChangeSection(decimal registrationId, decimal newSectionId)
        {
            registrationRepository.ChangeSection(registrationId, newSectionId);
        }
    }
}
