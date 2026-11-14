using Microsoft.Extensions.Configuration;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversitySystem.Core.Common;

namespace UniversitySystem.Infra.Common
{

    public class DbContext : IDbContext
    {
        
        private DbConnection connection;
        private readonly IConfiguration configuration;
        public DbContext(IConfiguration _configuration)
        {
            configuration = _configuration;
        }
        public DbConnection Connection
        {
            get
            {
                if (connection == null)
                {
                    connection = new OracleConnection((configuration["ConnectionStrings:DBConnectionString"] ?? configuration["ConnectionStrings:DefaultConnection"]));
                    connection.Open();

                }
                else if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                return connection;
            }
        }

    }
}

