using UniversitySystem.Core.Models;

namespace UniversitySystem.Core.Repository
{
    public interface ICourseRepository
    {
        public List<Course> GetAllCourses();
        public Course? GetCourseById(int courseId);
        public List<Course> GetCoursesByDepartment(int departmentId);
        public List<Course> GetFeaturedCourses();
        public List<Course> SearchCourses(string? search, int? departmentId, int? creditHours, string sortBy = "CODE");
        public int CreateCourse(Course course);
        public void UpdateCourse(Course course);
        public void DeleteCourse(int courseId);
    }
}
