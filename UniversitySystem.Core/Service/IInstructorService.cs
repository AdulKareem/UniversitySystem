using UniversitySystem.Core.DTO;

namespace UniversitySystem.Core.Service
{
    public interface IInstructorService
    {
        public List<InstructorResponseDto> GetAllInstructors();
        public InstructorResponseDto? GetInstructorById(int instructorId);
        public List<InstructorResponseDto> GetInstructorsByDepartment(int departmentId);
        public int CreateInstructor(InstructorRequestDto dto);
        public void UpdateInstructor(int instructorId, InstructorRequestDto dto);
        public void DeleteInstructor(int instructorId);
    }
}
