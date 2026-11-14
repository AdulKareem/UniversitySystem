using UniversitySystem.Core.DTO;
using UniversitySystem.Core.Repository;
using UniversitySystem.Core.Service;

namespace UniversitySystem.Infra.Service
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository departmentRepository;

        public DepartmentService(IDepartmentRepository _departmentRepository)
        {
            departmentRepository = _departmentRepository;
        }

        public List<DepartmentResponseDto> GetAllDepartments()
        {
            return departmentRepository.GetAllDepartments();
        }

        public DepartmentResponseDto? GetDepartmentById(int departmentId)
        {
            return departmentRepository.GetDepartmentById(departmentId);
        }

        public int CreateDepartment(string departmentName)
        {
            return departmentRepository.CreateDepartment(departmentName);
        }

        public void UpdateDepartment(int departmentId, string departmentName)
        {
            departmentRepository.UpdateDepartment(departmentId, departmentName);
        }

        public void DeleteDepartment(int departmentId)
        {
            departmentRepository.DeleteDepartment(departmentId);
        }
    }
}