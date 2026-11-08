using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversitySystem.Core.Common
{
    public interface IDbContext
    {
        public DbConnection Connection { get; }
    }
}
