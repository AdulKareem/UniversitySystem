using Dapper;
using Microsoft.EntityFrameworkCore;
using System.Data;
using UniversitySystem.Core.Common;
using UniversitySystem.Core.Models;
using Dapper.Oracle;
using UniversitySystem.Core.Repository;

namespace UniversitySystem.Infra.Repository
{
    public class CourseRepository : ICourseRepository
    {
        private readonly IDbContext dbContext;

        public CourseRepository(IDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public List<Course> GetAllCourses()
        {
            var p = new OracleDynamicParameters();
            p.Add("p_Result", dbType: OracleMappingType.RefCursor, direction: ParameterDirection.Output);

            return dbContext.Connection
                .Query<Course>("COURSE_PACKAGE.GetAllCourses", p, commandType: CommandType.StoredProcedure)
                .ToList();
        }

        public Course? GetCourseById(int courseId)
        {
            var p = new OracleDynamicParameters();
            p.Add("p_CourseID", courseId, OracleMappingType.Int32, ParameterDirection.Input);
            p.Add("p_Result", dbType: OracleMappingType.RefCursor, direction: ParameterDirection.Output);

            return dbContext.Connection
                .Query<Course>("COURSE_PACKAGE.GetCourseByID", p, commandType: CommandType.StoredProcedure)
                .FirstOrDefault();
        }

        public List<Course> GetCoursesByDepartment(int departmentId)
        {
            var p = new OracleDynamicParameters();
            p.Add("p_DepartmentID", departmentId, OracleMappingType.Int32, ParameterDirection.Input);
            p.Add("p_Result", dbType: OracleMappingType.RefCursor, direction: ParameterDirection.Output);

            return dbContext.Connection
                .Query<Course>("COURSE_PACKAGE.GetCoursesByDepartment", p, commandType: CommandType.StoredProcedure)
                .ToList();
        }

        public List<Course> GetFeaturedCourses()
        {
            var p = new OracleDynamicParameters();
            p.Add("p_Result", dbType: OracleMappingType.RefCursor, direction: ParameterDirection.Output);

            return dbContext.Connection
                .Query<Course>("COURSE_PACKAGE.GetFeaturedCourses", p, commandType: CommandType.StoredProcedure)
                .ToList();
        }

        public List<Course> SearchCourses(string? search, int? departmentId, int? creditHours, string sortBy = "CODE")
        {
            var p = new OracleDynamicParameters();
            p.Add("p_Search", search, OracleMappingType.Varchar2, ParameterDirection.Input);
            p.Add("p_DepartmentID", departmentId, OracleMappingType.Int32, ParameterDirection.Input);
            p.Add("p_CreditHours", creditHours, OracleMappingType.Int32, ParameterDirection.Input);
            p.Add("p_SortBy", sortBy, OracleMappingType.Varchar2, ParameterDirection.Input);
            p.Add("p_Result", dbType: OracleMappingType.RefCursor, direction: ParameterDirection.Output);

            return dbContext.Connection
                .Query<Course>("COURSE_PACKAGE.SearchCourses", p, commandType: CommandType.StoredProcedure)
                .ToList();
        }

        // ---------- WRITE ----------

        public int CreateCourse(Course course)
        {
            var p = new OracleDynamicParameters();
            p.Add("p_CourseCode", course.Coursecode, OracleMappingType.Varchar2, ParameterDirection.Input);
            p.Add("p_CourseName", course.Coursename, OracleMappingType.Varchar2, ParameterDirection.Input);
            p.Add("p_CourseDescription", course.Coursedescription, OracleMappingType.Varchar2, ParameterDirection.Input);
            p.Add("p_CreditHours", course.Credithours, OracleMappingType.Int32, ParameterDirection.Input);
            p.Add("p_IsFeatured", course.Isfeatured, OracleMappingType.Int32, ParameterDirection.Input);
            p.Add("p_DepartmentID", course.Departmentid, OracleMappingType.Int32, ParameterDirection.Input);
            p.Add("p_CourseID", dbType: OracleMappingType.Int32, direction: ParameterDirection.Output);

            dbContext.Connection.Execute("COURSE_PACKAGE.AddCourse",p, commandType: CommandType.StoredProcedure);
            return p.Get<int>("p_CourseID");
        }

        public void UpdateCourse(Course course)
        {
            var p = new OracleDynamicParameters();
            p.Add("p_CourseID", course.Courseid, OracleMappingType.Int32, ParameterDirection.Input);
            p.Add("p_CourseCode", course.Coursecode, OracleMappingType.Varchar2, ParameterDirection.Input);
            p.Add("p_CourseName", course.Coursename, OracleMappingType.Varchar2, ParameterDirection.Input);
            p.Add("p_CourseDescription", course.Coursedescription, OracleMappingType.Varchar2, ParameterDirection.Input);
            p.Add("p_CreditHours", course.Credithours, OracleMappingType.Int32, ParameterDirection.Input);
            p.Add("p_IsFeatured", course.Isfeatured, OracleMappingType.Int32, ParameterDirection.Input);
            p.Add("p_DepartmentID", course.Departmentid, OracleMappingType.Int32, ParameterDirection.Input);

            dbContext.Connection.Execute("COURSE_PACKAGE.UpdateCourse", p, commandType: CommandType.StoredProcedure);
        }

        public void DeleteCourse(int courseId)
        {
            var p = new OracleDynamicParameters();
            p.Add("p_CourseID", courseId, OracleMappingType.Int32, ParameterDirection.Input);

            dbContext.Connection.Execute("COURSE_PACKAGE.DeleteCourse", p, commandType: CommandType.StoredProcedure);
        }
    }
}