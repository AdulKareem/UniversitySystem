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
    public class SectionSchedulesRepository : ISectionSchedulesRepository
    {
        private readonly IDbContext dbContext;

        public SectionSchedulesRepository(IDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public List<Sectionschedule> GetSchedulesBySection(decimal sectionId)
        {
            var p = new OracleDynamicParameters();

            p.Add("p_SectionID", sectionId,
                OracleMappingType.Decimal,
                ParameterDirection.Input);

            p.Add("p_Result",
                dbType: OracleMappingType.RefCursor,
                direction: ParameterDirection.Output);

            return dbContext.Connection
                .Query<Sectionschedule>(
                    "SECTIONSCHEDULE_PACKAGE.GetSchedulesBySection",
                    p,
                    commandType: CommandType.StoredProcedure)
                .ToList();
        }

        public List<Sectionschedule> GetSchedulesByCourse(decimal courseId)
        {
            var p = new OracleDynamicParameters();

            p.Add("p_CourseID", courseId,
                OracleMappingType.Decimal,
                ParameterDirection.Input);

            p.Add("p_Result",
                dbType: OracleMappingType.RefCursor,
                direction: ParameterDirection.Output);

            return dbContext.Connection
                .Query<Sectionschedule>(
                    "SECTIONSCHEDULE_PACKAGE.GetSchedulesByCourse",
                    p,
                    commandType: CommandType.StoredProcedure)
                .ToList();
        }

        public decimal CreateSchedule(Sectionschedule schedule)
        {
            var p = new OracleDynamicParameters();

            p.Add("p_DayOfWeek", schedule.Dayofweek,
                OracleMappingType.Varchar2,
                ParameterDirection.Input);

            p.Add("p_StartTime", schedule.Starttime,
                OracleMappingType.Varchar2,
                ParameterDirection.Input);

            p.Add("p_EndTime", schedule.Endtime,
                OracleMappingType.Varchar2,
                ParameterDirection.Input);

            p.Add("p_RoomNumber", schedule.Roomnumber,
                OracleMappingType.Varchar2,
                ParameterDirection.Input);

            p.Add("p_SectionID", schedule.Sectionid,
                OracleMappingType.Decimal,
                ParameterDirection.Input);

            p.Add("p_ScheduleID",
                dbType: OracleMappingType.Decimal,
                direction: ParameterDirection.Output);

            dbContext.Connection.Execute(
                "SECTIONSCHEDULE_PACKAGE.AddSchedule",
                p,
                commandType: CommandType.StoredProcedure);

            return p.Get<decimal>("p_ScheduleID");
        }

        public void UpdateSchedule(Sectionschedule schedule)
        {
            var p = new OracleDynamicParameters();

            p.Add("p_ScheduleID", schedule.Scheduleid,
                OracleMappingType.Decimal,
                ParameterDirection.Input);

            p.Add("p_DayOfWeek", schedule.Dayofweek,
                OracleMappingType.Varchar2,
                ParameterDirection.Input);

            p.Add("p_StartTime", schedule.Starttime,
                OracleMappingType.Varchar2,
                ParameterDirection.Input);

            p.Add("p_EndTime", schedule.Endtime,
                OracleMappingType.Varchar2,
                ParameterDirection.Input);

            p.Add("p_RoomNumber", schedule.Roomnumber,
                OracleMappingType.Varchar2,
                ParameterDirection.Input);

            dbContext.Connection.Execute(
                "SECTIONSCHEDULE_PACKAGE.UpdateSchedule",
                p,
                commandType: CommandType.StoredProcedure);
        }

        public void DeleteSchedule(decimal scheduleId)
        {
            var p = new OracleDynamicParameters();

            p.Add("p_ScheduleID", scheduleId,
                OracleMappingType.Decimal,
                ParameterDirection.Input);

            dbContext.Connection.Execute(
                "SECTIONSCHEDULE_PACKAGE.DeleteSchedule",
                p,
                commandType: CommandType.StoredProcedure);
        }
    }
}