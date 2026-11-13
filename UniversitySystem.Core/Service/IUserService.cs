using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversitySystem.Core.Models;

namespace UniversitySystem.Core.Service
{
    public interface IUserService
    {
      

      public User? GetUserForLogin(string usernameOrEmail);
      public  User AuthenticateAdmin(string usernameOrEmail, string password);
        //private bool VerifyPassword(string enteredPassword, string storedHash);
    }
}
