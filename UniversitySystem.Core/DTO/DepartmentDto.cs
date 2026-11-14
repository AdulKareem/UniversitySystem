using System.ComponentModel.DataAnnotations;

namespace UniversitySystem.Core.DTO
{
    // مستخدم للإضافة والتعديل
    public class DepartmentRequestDto
    {
        [Required(ErrorMessage = "Department name is required.")]
        [StringLength(100)]
        public string DepartmentName { get; set; } = string.Empty;
    }

    // مستخدم للعرض (فيه عدد المواد)
    public class DepartmentResponseDto
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; } = string.Empty;
        public int CourseCount { get; set; }
    }
}
