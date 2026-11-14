using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UniversitySystem.Core.DTO;
using UniversitySystem.Core.Repository;
using UniversitySystem.Core.Service;
using UniversitySystem.Infra.Service;

namespace UniversitySystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserService userServic;
        public UserController(IUserService _userServic)
        {
            userServic = _userServic;
        }


        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDto model)
        {
            // 1. التحقق من صحة المدخلات الأساسية
            if (model == null || string.IsNullOrWhiteSpace(model.UsernameOrEmail) || string.IsNullOrWhiteSpace(model.Password))
            {
                return BadRequest(new { message = "Username and password are required." });
            }

            try
            {
                // 2. استدعاء طبقة الخدمة لتنفيذ عملية التحقق وتوليد التوكن
                var token = userServic.AuthenticateAdmin(model.UsernameOrEmail, model.Password);

                // 3. إرجاع التوكن بنجاح للفرونت إند (Angular)
                return Ok(new
                {
                    success = true,
                    message = "You have been logged in successfully",
                    token = token
                });
            }
            catch (UnauthorizedAccessException ex)
            {
                // التعامل مع أخطاء فشل المصادقة أو الصلاحيات
                return Unauthorized(new
                {
                    success = false,
                    message = ex.Message
                });
            }
            catch (Exception ex)
            {
                // التعامل مع أي أخطاء غير متوقعة في الخادم
                return StatusCode(500, new
                {
                    success = false,
                    message = "An internal server error occurred.",
                    error = ex.Message
                });
            }
        }


    }
}
