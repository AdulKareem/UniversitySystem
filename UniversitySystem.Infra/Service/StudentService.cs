using UniversitySystem.Core.DTO;
using UniversitySystem.Core.Repository;
using UniversitySystem.Core.Service;

namespace UniversitySystem.Infra.Service
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository studentRepository;

        public StudentService(IStudentRepository _studentRepository)
        {
            studentRepository = _studentRepository;
        }

        public List<StudentResponseDto> GetAllStudents()
        {
            return studentRepository.GetAllStudents();
        }

        public StudentResponseDto? GetStudentById(int studentId)
        {
            return studentRepository.GetStudentById(studentId);
        }

        public StudentResponseDto? GetStudentByUniversityId(string universityId)
        {
            return studentRepository.GetStudentByUniversityId(universityId);
        }

        public int CreateStudent(StudentRequestDto dto)
        {
            return studentRepository.CreateStudent(dto);
        }

        public void UpdateStudent(int studentId, StudentRequestDto dto)
        {
            studentRepository.UpdateStudent(studentId, dto);
        }

        public void DeleteStudent(int studentId)
        {
            studentRepository.DeleteStudent(studentId);
        }
    }
}
