
using Dapper;
using Dapper.Oracle;
using System.Data;
using UniversitySystem.Core.Common;
using UniversitySystem.Core.Models;
using UniversitySystem.Core.Repository;

namespace UniversitySystem.Infra.Repository
{
    public class SectionRepository : ISectionRepository
    {
        private readonly IDbContext dbContext;

        public SectionRepository(IDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public List<Section> GetAllSections()
        {
            var p = new OracleDynamicParameters();

            p.Add("p_Result",
                dbType: OracleMappingType.RefCursor,
                direction: ParameterDirection.Output);

            return dbContext.Connection
                .Query<Section>(
                    "SECTION_PACKAGE.GetAllSections",
                    p,
                    commandType: CommandType.StoredProcedure)
                .ToList();
        }

        public Section? GetSectionById(Int32 sectionId)
        {
            var p = new OracleDynamicParameters();

            p.Add("p_SectionID", sectionId,
                OracleMappingType.Decimal,
                ParameterDirection.Input);

            p.Add("p_Result",
                dbType: OracleMappingType.RefCursor,
                direction: ParameterDirection.Output);

            return dbContext.Connection
                .Query<Section>(
                    "SECTION_PACKAGE.GetSectionByID",
                    p,
                    commandType: CommandType.StoredProcedure)
                .FirstOrDefault();
        }

        public List<Section> GetSectionsByCourse(Int32 courseId)
        {
            var p = new OracleDynamicParameters();

            p.Add("p_CourseID", courseId,
                OracleMappingType.Decimal,
                ParameterDirection.Input);

            p.Add("p_Result",
                dbType: OracleMappingType.RefCursor,
                direction: ParameterDirection.Output);

            return dbContext.Connection
                .Query<Section>(
                    "SECTION_PACKAGE.GetSectionsByCourse",
                    p,
                    commandType: CommandType.StoredProcedure)
                .ToList();
        }

        public decimal CreateSection(Section section)
        {
            var p = new OracleDynamicParameters();

            p.Add("p_SectionNumber", section.Sectionnumber,
                OracleMappingType.Int32,
                ParameterDirection.Input);

            p.Add("p_Capacity", section.Capacity,
                OracleMappingType.Int32,
                ParameterDirection.Input);

            p.Add("p_CourseID", section.Courseid,
                OracleMappingType.Decimal,
                ParameterDirection.Input);

            p.Add("p_InstructorID", section.Instructorid,
                OracleMappingType.Decimal,
                ParameterDirection.Input);

            p.Add("p_SectionID",
                dbType: OracleMappingType.Decimal,
                direction: ParameterDirection.Output);

            dbContext.Connection.Execute(
                "SECTION_PACKAGE.AddSection",
                p,
                commandType: CommandType.StoredProcedure);

            return p.Get<decimal>("p_SectionID");
        }

        public void UpdateSection(Section section)
        {
            var p = new OracleDynamicParameters();

            p.Add("p_SectionID", section.Sectionid,
                OracleMappingType.Decimal,
                ParameterDirection.Input);

            p.Add("p_SectionNumber", section.Sectionnumber,
                OracleMappingType.Int32,
                ParameterDirection.Input);

            p.Add("p_Capacity", section.Capacity,
                OracleMappingType.Int32,
                ParameterDirection.Input);

            p.Add("p_InstructorID", section.Instructorid,
                OracleMappingType.Decimal,
                ParameterDirection.Input);

            dbContext.Connection.Execute(
                "SECTION_PACKAGE.UpdateSection",
                p,
                commandType: CommandType.StoredProcedure);
        }

        public void DeleteSection(Int32 sectionId)
        {
            var p = new OracleDynamicParameters();

            p.Add("p_SectionID", sectionId,
                OracleMappingType.Decimal,
                ParameterDirection.Input);

            dbContext.Connection.Execute(
                "SECTION_PACKAGE.DeleteSection",
                p,
                commandType: CommandType.StoredProcedure);
        }

        public Section? GetSectionById(decimal sectionId)
        {
            throw new NotImplementedException();
        }

        public List<Section> GetSectionsByCourse(decimal courseId)
        {
            throw new NotImplementedException();
        }

        public void DeleteSection(decimal sectionId)
        {
            throw new NotImplementedException();
        }
    }
}
