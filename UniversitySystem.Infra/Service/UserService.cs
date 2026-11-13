using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversitySystem.Core.Models;
using UniversitySystem.Core.Repository;
using UniversitySystem.Core.Service;
using UniversitySystem.Infra.Repository;
using System.Security.Cryptography;
namespace UniversitySystem.Infra.Service
{
   
public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;

        public UserService(IUserRepository _userRepository)
        {
            userRepository = _userRepository;
        }

        public User? GetUserForLogin(string usernameOrEmail)
        {
            return userRepository.GetUserForLogin(usernameOrEmail);
        }

        public User AuthenticateAdmin(string usernameOrEmail, string password)
        {
            var user = userRepository.GetUserForLogin(usernameOrEmail);

            if (user == null)
            {
                throw new UnauthorizedAccessException("Incorrect username");
            }

            // تشفير كلمة المرور المدخلة ومقارنتها بالـ Hash المخزن في القاعدة
            if (!VerifyPassword(password, user.Passwordhash))
            {
                throw new UnauthorizedAccessException("Incorrect password.");
            }

            if (user.Rolename?.ToUpper() != "ADMIN")
            {
                throw new UnauthorizedAccessException("Sorry, you are not allowed to access the control panel.");
            }

            return user;
        }

        // دالة مقارنة كلمة المرور
        private bool VerifyPassword(string enteredPassword, string storedHash)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(enteredPassword));
                string enteredPasswordHash = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();

                // مقارنة الـ Hash المدخل مع المخزن (مع تجاهل حالة الأحرف إذا لزم الأمر)
                return string.Equals(enteredPasswordHash, storedHash, StringComparison.OrdinalIgnoreCase);
            }
        }
    }

}

