using Dapper;
using Dapper.Oracle;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using UniversitySystem.Core.Common;
using UniversitySystem.Core.Models;
using UniversitySystem.Core.Repository;

namespace UniversitySystem.Infra.Repository
{
    public class RegistrationRepository : IRegistrationRepository
    {
        private readonly IDbContext dbContext;

        public RegistrationRepository(IDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public decimal RegisterStudent(decimal studentId, decimal sectionId)
        {
            var p = new OracleDynamicParameters();

            p.Add("p_StudentID", studentId,
                OracleMappingType.Decimal,
                ParameterDirection.Input);

            p.Add("p_SectionID", sectionId,
                OracleMappingType.Decimal,
                ParameterDirection.Input);

            p.Add("p_RegistrationID",
                dbType: OracleMappingType.Decimal,
                direction: ParameterDirection.Output);

            dbContext.Connection.Execute(
                "REGISTRATION_PACKAGE.RegisterStudent",
                p,
                commandType: CommandType.StoredProcedure);

            return p.Get<decimal>("p_RegistrationID");
        }

        public List<Registration> GetAllRegistrations()
        {
            var p = new OracleDynamicParameters();

            p.Add("p_Result",
                dbType: OracleMappingType.RefCursor,
                direction: ParameterDirection.Output);

            return dbContext.Connection
                .Query<Registration>(
                    "REGISTRATION_PACKAGE.GetAllRegistrations",
                    p,
                    commandType: CommandType.StoredProcedure)
                .ToList();
        }

        public Registration? GetRegistrationById(decimal registrationId)
        {
            var p = new OracleDynamicParameters();

            p.Add("p_RegistrationID", registrationId,
                OracleMappingType.Decimal,
                ParameterDirection.Input);

            p.Add("p_Result",
                dbType: OracleMappingType.RefCursor,
                direction: ParameterDirection.Output);

            return dbContext.Connection
                .Query<Registration>(
                    "REGISTRATION_PACKAGE.GetRegistrationByID",
                    p,
                    commandType: CommandType.StoredProcedure)
                .FirstOrDefault();
        }

        public List<Registration> GetStudentRegistrations(decimal studentId)
        {
            var p = new OracleDynamicParameters();

            p.Add("p_StudentID", studentId,
                OracleMappingType.Decimal,
                ParameterDirection.Input);

            p.Add("p_Result",
                dbType: OracleMappingType.RefCursor,
                direction: ParameterDirection.Output);

            return dbContext.Connection
                .Query<Registration>(
                    "REGISTRATION_PACKAGE.GetStudentRegistrations",
                    p,
                    commandType: CommandType.StoredProcedure)
                .ToList();
        }

        public List<Sectionschedule> GetStudentSchedules(decimal studentId)
        {
            var p = new OracleDynamicParameters();

            p.Add("p_StudentID", studentId,
                OracleMappingType.Decimal,
                ParameterDirection.Input);

            p.Add("p_Result",
                dbType: OracleMappingType.RefCursor,
                direction: ParameterDirection.Output);

            return dbContext.Connection
                .Query<Sectionschedule>(
                    "REGISTRATION_PACKAGE.GetStudentSchedules",
                    p,
                    commandType: CommandType.StoredProcedure)
                .ToList();
        }

        public void CancelRegistration(decimal registrationId)
        {
            var p = new OracleDynamicParameters();

            p.Add("p_RegistrationID", registrationId,
                OracleMappingType.Decimal,
                ParameterDirection.Input);

            dbContext.Connection.Execute(
                "REGISTRATION_PACKAGE.CancelRegistration",
                p,
                commandType: CommandType.StoredProcedure);
        }

        public void ChangeSection(decimal registrationId, decimal newSectionId)
        {
            var p = new OracleDynamicParameters();

            p.Add("p_RegistrationID", registrationId,
                OracleMappingType.Decimal,
                ParameterDirection.Input);

            p.Add("p_NewSectionID", newSectionId,
                OracleMappingType.Decimal,
                ParameterDirection.Input);

            dbContext.Connection.Execute(
                "REGISTRATION_PACKAGE.ChangeSection",
                p,
                commandType: CommandType.StoredProcedure);
        }
    }
}