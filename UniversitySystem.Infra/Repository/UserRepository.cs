using Dapper;
using Dapper.Oracle;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversitySystem.Core.Common;
using UniversitySystem.Core.Models;
using UniversitySystem.Core.Repository;

namespace UniversitySystem.Infra.Repository
{
    public class UserRepository : IUserRepository
    {

        private readonly IDbContext dbContext;

        public UserRepository(IDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public User? GetUserForLogin(string usernameOrEmail)
        {
            var p = new OracleDynamicParameters();
            p.Add("p_UsernameOrEmail", value: usernameOrEmail,
                  dbType: OracleMappingType.Varchar2, direction: ParameterDirection.Input);
            p.Add("p_Result", dbType: OracleMappingType.RefCursor,
                  direction: ParameterDirection.Output);

            try
            {
                return dbContext.Connection
                    .QueryFirstOrDefault<User>("USER_PACKAGE.GetUserForLogin", p,
                                               commandType: CommandType.StoredProcedure);
            }
            catch (OracleException ex) when (ex.Number == 20002)
            {
                // المستخدم غير موجود: نرجع Null ويتعامل معه الـ Service
                return null;
            }
        }

        //public User? GetUserForLogin(string usernameOrEmail)
        //{
        //    var p = new OracleDynamicParameters();
        //    p.Add("p_UsernameOrEmail", value: usernameOrEmail,
        //          dbType: OracleMappingType.Varchar2, direction: ParameterDirection.Input);
        //    p.Add("p_Result", dbType: OracleMappingType.RefCursor,
        //          direction: ParameterDirection.Output);

        //    try
        //    {
        //        return dbContext.Connection
        //            .QueryFirstOrDefault<User>("USER_PACKAGE.GetUserForLogin", p,
        //                                       commandType: CommandType.StoredProcedure);
        //    }
        //    catch (OracleException ex) when (ex.Number == 20002 || ex.Number == 20001)
        //    {
        //        // إذا لم يتم العثور على الأدمن أو خطأ في المدخلات نرجع Null
        //        return null;
        //    }
        //}






    }
}

