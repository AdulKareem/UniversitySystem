using Dapper;
using Dapper.Oracle;
using System.Data;
using UniversitySystem.Core.Common;
using UniversitySystem.Core.DTO;
using UniversitySystem.Core.Repository;

namespace UniversitySystem.Infra.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly IDbContext dbContext;

        public DepartmentRepository(IDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public List<DepartmentResponseDto> GetAllDepartments()
        {
            var p = new OracleDynamicParameters();
            p.Add("p_Result", dbType: OracleMappingType.RefCursor, direction: ParameterDirection.Output);

            return dbContext.Connection
                .Query<DepartmentResponseDto>("DEPARTMENT_PACKAGE.GetAllDepartments", p, commandType: CommandType.StoredProcedure)
                .ToList();
        }

        public DepartmentResponseDto? GetDepartmentById(int departmentId)
        {
            var p = new OracleDynamicParameters();
            p.Add("p_DepartmentID", departmentId, OracleMappingType.Int32, ParameterDirection.Input);
            p.Add("p_Result", dbType: OracleMappingType.RefCursor, direction: ParameterDirection.Output);

            return dbContext.Connection
                .Query<DepartmentResponseDto>("DEPARTMENT_PACKAGE.GetDepartmentByID", p, commandType: CommandType.StoredProcedure)
                .FirstOrDefault();
        }

        // ---------- WRITE ----------

        public int CreateDepartment(string departmentName)
        {
            var p = new OracleDynamicParameters();
            p.Add("p_DepartmentName", departmentName, OracleMappingType.Varchar2, ParameterDirection.Input);
            p.Add("p_DepartmentID", dbType: OracleMappingType.Int32, direction: ParameterDirection.Output);

            dbContext.Connection.Execute("DEPARTMENT_PACKAGE.AddDepartment", p, commandType: CommandType.StoredProcedure);
            return p.Get<int>("p_DepartmentID");
        }

        public void UpdateDepartment(int departmentId, string departmentName)
        {
            var p = new OracleDynamicParameters();
            p.Add("p_DepartmentID", departmentId, OracleMappingType.Int32, ParameterDirection.Input);
            p.Add("p_DepartmentName", departmentName, OracleMappingType.Varchar2, ParameterDirection.Input);

            dbContext.Connection.Execute("DEPARTMENT_PACKAGE.UpdateDepartment", p, commandType: CommandType.StoredProcedure);
        }

        public void DeleteDepartment(int departmentId)
        {
            var p = new OracleDynamicParameters();
            p.Add("p_DepartmentID", departmentId, OracleMappingType.Int32, ParameterDirection.Input);

            dbContext.Connection.Execute("DEPARTMENT_PACKAGE.DeleteDepartment", p, commandType: CommandType.StoredProcedure);
        }
    }
}
