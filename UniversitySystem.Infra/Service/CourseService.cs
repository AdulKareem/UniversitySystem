using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversitySystem.Core.Models;
using UniversitySystem.Core.Repository;
using UniversitySystem.Core.Service;

namespace UniversitySystem.Infra.Service
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository courseRepository;
        public CourseService(ICourseRepository _courseRepository)
        {

            courseRepository = _courseRepository;
        }

        public List<Course> GetAllCourses()
        {
        return courseRepository.GetAllCourses();
        
        }
        public Course? GetCourseById(int courseId)
        {
            return courseRepository.GetCourseById(courseId);    
        }
        public List<Course> GetCoursesByDepartment(int departmentId)
        {
            return courseRepository.GetCoursesByDepartment(departmentId);
        }
        public List<Course> GetFeaturedCourses()
        {

            return courseRepository.GetFeaturedCourses();
        }
        public List<Course> SearchCourses(string? search, int? departmentId, int? creditHours, string sortBy = "CODE")
        {
            return courseRepository.SearchCourses(search, departmentId, creditHours, sortBy);
        }

        public int CreateCourse(Course course)
        {
            return courseRepository.CreateCourse(course);
        }

        public void UpdateCourse(Course course)
        {
            courseRepository.UpdateCourse(course);
        }
        public void DeleteCourse(int courseId)
        {
            courseRepository.DeleteCourse(courseId);
        }

    }
}
