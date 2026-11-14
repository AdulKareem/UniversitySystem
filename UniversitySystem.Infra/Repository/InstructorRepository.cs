using Dapper;
using Dapper.Oracle;
using System.Data;
using UniversitySystem.Core.Common;
using UniversitySystem.Core.DTO;
using UniversitySystem.Core.Repository;

namespace UniversitySystem.Infra.Repository
{
    public class InstructorRepository : IInstructorRepository
    {
        private readonly IDbContext dbContext;

        public InstructorRepository(IDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public List<InstructorResponseDto> GetAllInstructors()
        {
            var p = new OracleDynamicParameters();
            p.Add("p_Result", dbType: OracleMappingType.RefCursor, direction: ParameterDirection.Output);

            return dbContext.Connection
                .Query<InstructorResponseDto>("INSTRUCTOR_PACKAGE.GetAllInstructors", p, commandType: CommandType.StoredProcedure)
                .ToList();
        }

        public InstructorResponseDto? GetInstructorById(int instructorId)
        {
            var p = new OracleDynamicParameters();
            p.Add("p_InstructorID", instructorId, OracleMappingType.Int32, ParameterDirection.Input);
            p.Add("p_Result", dbType: OracleMappingType.RefCursor, direction: ParameterDirection.Output);

            return dbContext.Connection
                .Query<InstructorResponseDto>("INSTRUCTOR_PACKAGE.GetInstructorByID", p, commandType: CommandType.StoredProcedure)
                .FirstOrDefault();
        }

        public List<InstructorResponseDto> GetInstructorsByDepartment(int departmentId)
        {
            var p = new OracleDynamicParameters();
            p.Add("p_DepartmentID", departmentId, OracleMappingType.Int32, ParameterDirection.Input);
            p.Add("p_Result", dbType: OracleMappingType.RefCursor, direction: ParameterDirection.Output);

            return dbContext.Connection
                .Query<InstructorResponseDto>("INSTRUCTOR_PACKAGE.GetInstructorsByDepartment", p, commandType: CommandType.StoredProcedure)
                .ToList();
        }

        // ---------- WRITE ----------

        public int CreateInstructor(InstructorRequestDto dto)
        {
            var p = new OracleDynamicParameters();
            p.Add("p_FullName", dto.FullName, OracleMappingType.Varchar2, ParameterDirection.Input);
            p.Add("p_Email", dto.Email, OracleMappingType.Varchar2, ParameterDirection.Input);
            p.Add("p_DepartmentID", dto.DepartmentId, OracleMappingType.Int32, ParameterDirection.Input);
            p.Add("p_InstructorID", dbType: OracleMappingType.Int32, direction: ParameterDirection.Output);

            dbContext.Connection.Execute("INSTRUCTOR_PACKAGE.AddInstructor", p, commandType: CommandType.StoredProcedure);
            return p.Get<int>("p_InstructorID");
        }

        public void UpdateInstructor(int instructorId, InstructorRequestDto dto)
        {
            var p = new OracleDynamicParameters();
            p.Add("p_InstructorID", instructorId, OracleMappingType.Int32, ParameterDirection.Input);
            p.Add("p_FullName", dto.FullName, OracleMappingType.Varchar2, ParameterDirection.Input);
            p.Add("p_Email", dto.Email, OracleMappingType.Varchar2, ParameterDirection.Input);
            p.Add("p_DepartmentID", dto.DepartmentId, OracleMappingType.Int32, ParameterDirection.Input);

            dbContext.Connection.Execute("INSTRUCTOR_PACKAGE.UpdateInstructor", p, commandType: CommandType.StoredProcedure);
        }

        public void DeleteInstructor(int instructorId)
        {
            var p = new OracleDynamicParameters();
            p.Add("p_InstructorID", instructorId, OracleMappingType.Int32, ParameterDirection.Input);

            dbContext.Connection.Execute("INSTRUCTOR_PACKAGE.DeleteInstructor", p, commandType: CommandType.StoredProcedure);
        }
    }
}