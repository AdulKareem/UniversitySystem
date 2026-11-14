using System.ComponentModel.DataAnnotations;

namespace UniversitySystem.Core.DTO
{
    public class InstructorRequestDto
    {
        [Required(ErrorMessage = "Instructor name is required.")]
        [StringLength(100)]
        public string FullName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Instructor email is required.")]
        [EmailAddress(ErrorMessage = "Email format is invalid.")]
        [StringLength(100)]
        public string Email { get; set; } = string.Empty;

        [Range(1, int.MaxValue, ErrorMessage = "Department is required.")]
        public int DepartmentId { get; set; }
    }

    public class InstructorResponseDto
    {
        public int InstructorId { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; } = string.Empty;
    }
}
