using System.ComponentModel.DataAnnotations;

namespace UniversitySystem.Core.DTO
{
    // مستخدم لتسجيل الطالب وتعديله
    public class StudentRequestDto
    {
        [Required(ErrorMessage = "University ID is required.")]
        [StringLength(20)]
        public string UniversityId { get; set; } = string.Empty;

        [Required(ErrorMessage = "Student name is required.")]
        [StringLength(100)]
        public string FullName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Email format is invalid.")]
        [StringLength(100)]
        public string Email { get; set; } = string.Empty;

        // التخصص (Major)
        [Range(1, int.MaxValue, ErrorMessage = "Major (department) is required.")]
        public int DepartmentId { get; set; }
    }

    public class StudentResponseDto
    {
        public int StudentId { get; set; }
        public string UniversityId { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int DepartmentId { get; set; }
        public string Major { get; set; } = string.Empty;
    }
}