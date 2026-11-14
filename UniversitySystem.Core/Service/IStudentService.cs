using UniversitySystem.Core.DTO;

namespace UniversitySystem.Core.Service
{
    public interface IStudentService
    {
        public List<StudentResponseDto> GetAllStudents();
        public StudentResponseDto? GetStudentById(int studentId);
        public StudentResponseDto? GetStudentByUniversityId(string universityId);
        public int CreateStudent(StudentRequestDto dto);
        public void UpdateStudent(int studentId, StudentRequestDto dto);
        public void DeleteStudent(int studentId);
    }
}
