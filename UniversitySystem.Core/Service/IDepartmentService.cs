using UniversitySystem.Core.DTO;

namespace UniversitySystem.Core.Service
{
    public interface IDepartmentService
    {
        public List<DepartmentResponseDto> GetAllDepartments();
        public DepartmentResponseDto? GetDepartmentById(int departmentId);
        public int CreateDepartment(string departmentName);
        public void UpdateDepartment(int departmentId, string departmentName);
        public void DeleteDepartment(int departmentId);
    }
}
