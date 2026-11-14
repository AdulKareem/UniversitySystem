using UniversitySystem.Core.DTO;
using UniversitySystem.Core.Repository;
using UniversitySystem.Core.Service;

namespace UniversitySystem.Infra.Service
{
    public class InstructorService : IInstructorService
    {
        private readonly IInstructorRepository instructorRepository;

        public InstructorService(IInstructorRepository _instructorRepository)
        {
            instructorRepository = _instructorRepository;
        }

        public List<InstructorResponseDto> GetAllInstructors()
        {
            return instructorRepository.GetAllInstructors();
        }

        public InstructorResponseDto? GetInstructorById(int instructorId)
        {
            return instructorRepository.GetInstructorById(instructorId);
        }

        public List<InstructorResponseDto> GetInstructorsByDepartment(int departmentId)
        {
            return instructorRepository.GetInstructorsByDepartment(departmentId);
        }

        public int CreateInstructor(InstructorRequestDto dto)
        {
            return instructorRepository.CreateInstructor(dto);
        }

        public void UpdateInstructor(int instructorId, InstructorRequestDto dto)
        {
            instructorRepository.UpdateInstructor(instructorId, dto);
        }

        public void DeleteInstructor(int instructorId)
        {
            instructorRepository.DeleteInstructor(instructorId);
        }
    }
}
