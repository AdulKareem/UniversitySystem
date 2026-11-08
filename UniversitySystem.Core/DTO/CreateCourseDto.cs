using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversitySystem.Core.DTO
{
    public class CreateCourseDto
    {
        [Required(ErrorMessage = "Course code is required.")]
        [StringLength(20)]
        public string CourseCode { get; set; } = string.Empty;

        [Required(ErrorMessage = "Course name is required.")]
        [StringLength(200)]
        public string CourseName { get; set; } = string.Empty;

        [StringLength(1000)]
        public string? CourseDescription { get; set; }

        [Range(1, 6, ErrorMessage = "Credit hours must be between 1 and 6.")]
        public int CreditHours { get; set; }

        [Range(0, 1, ErrorMessage = "IsFeatured must be 0 or 1.")]
        public int IsFeatured { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Department is required.")]
        public int DepartmentId { get; set; }

    }
}
