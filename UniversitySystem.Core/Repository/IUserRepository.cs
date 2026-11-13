using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversitySystem.Core.Models;

namespace UniversitySystem.Core.Repository
{
    public interface IUserRepository
    {

        User? GetUserForLogin(string usernameOrEmail);

    }
}
