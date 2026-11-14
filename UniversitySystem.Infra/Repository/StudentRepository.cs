using Dapper;
using Dapper.Oracle;
using System.Data;
using UniversitySystem.Core.Common;
using UniversitySystem.Core.DTO;
using UniversitySystem.Core.Repository;

namespace UniversitySystem.Infra.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly IDbContext dbContext;

        public StudentRepository(IDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public List<StudentResponseDto> GetAllStudents()
        {
            var p = new OracleDynamicParameters();
            p.Add("p_Result", dbType: OracleMappingType.RefCursor, direction: ParameterDirection.Output);

            return dbContext.Connection
                .Query<StudentResponseDto>("STUDENT_PACKAGE.GetAllStudents", p, commandType: CommandType.StoredProcedure)
                .ToList();
        }

        public StudentResponseDto? GetStudentById(int studentId)
        {
            var p = new OracleDynamicParameters();
            p.Add("p_StudentID", studentId, OracleMappingType.Int32, ParameterDirection.Input);
            p.Add("p_Result", dbType: OracleMappingType.RefCursor, direction: ParameterDirection.Output);

            return dbContext.Connection
                .Query<StudentResponseDto>("STUDENT_PACKAGE.GetStudentByID", p, commandType: CommandType.StoredProcedure)
                .FirstOrDefault();
        }

        public StudentResponseDto? GetStudentByUniversityId(string universityId)
        {
            var p = new OracleDynamicParameters();
            p.Add("p_UniversityID", universityId, OracleMappingType.Varchar2, ParameterDirection.Input);
            p.Add("p_Result", dbType: OracleMappingType.RefCursor, direction: ParameterDirection.Output);

            return dbContext.Connection
                .Query<StudentResponseDto>("STUDENT_PACKAGE.GetStudentByUniversityID", p, commandType: CommandType.StoredProcedure)
                .FirstOrDefault();
        }

        // ---------- WRITE ----------

        public int CreateStudent(StudentRequestDto dto)
        {
            var p = new OracleDynamicParameters();
            p.Add("p_UniversityID", dto.UniversityId, OracleMappingType.Varchar2, ParameterDirection.Input);
            p.Add("p_FullName", dto.FullName, OracleMappingType.Varchar2, ParameterDirection.Input);
            p.Add("p_Email", dto.Email, OracleMappingType.Varchar2, ParameterDirection.Input);
            p.Add("p_DepartmentID", dto.DepartmentId, OracleMappingType.Int32, ParameterDirection.Input);
            p.Add("p_StudentID", dbType: OracleMappingType.Int32, direction: ParameterDirection.Output);

            dbContext.Connection.Execute("STUDENT_PACKAGE.AddStudent", p, commandType: CommandType.StoredProcedure);
            return p.Get<int>("p_StudentID");
        }

        public void UpdateStudent(int studentId, StudentRequestDto dto)
        {
            var p = new OracleDynamicParameters();
            p.Add("p_StudentID", studentId, OracleMappingType.Int32, ParameterDirection.Input);
            p.Add("p_UniversityID", dto.UniversityId, OracleMappingType.Varchar2, ParameterDirection.Input);
            p.Add("p_FullName", dto.FullName, OracleMappingType.Varchar2, ParameterDirection.Input);
            p.Add("p_Email", dto.Email, OracleMappingType.Varchar2, ParameterDirection.Input);
            p.Add("p_DepartmentID", dto.DepartmentId, OracleMappingType.Int32, ParameterDirection.Input);

            dbContext.Connection.Execute("STUDENT_PACKAGE.UpdateStudent", p, commandType: CommandType.StoredProcedure);
        }

        public void DeleteStudent(int studentId)
        {
            var p = new OracleDynamicParameters();
            p.Add("p_StudentID", studentId, OracleMappingType.Int32, ParameterDirection.Input);

            dbContext.Connection.Execute("STUDENT_PACKAGE.DeleteStudent", p, commandType: CommandType.StoredProcedure);
        }
    }
}
