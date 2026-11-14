using Oracle.ManagedDataAccess.Client;

namespace UniversitySystem.API.Middleware
{
    public class ExceptionMiddleware
    {

        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext ctx)
        {
            try
            {
                await _next(ctx);
            }
            catch (OracleException ex) when (ex.Number >= 20000 && ex.Number <= 20999)
            {
                // أخطاء الباكج التي عرّفتها بنفسك (RAISE_APPLICATION_ERROR)
                ctx.Response.StatusCode = ex.Number switch
                {
                    20207 or 20103 or 20305 or 20408 => StatusCodes.Status404NotFound,   // غير موجود
                    20206 or 20208 or 20102 or 20104 or 20304 or 20306
                        or 20406 or 20407 or 20409 => StatusCodes.Status409Conflict,     // مكرر / لا يمكن الحذف
                    _ => StatusCodes.Status400BadRequest  // فاليديشن
                };

                // نأخذ أول سطر فقط ونشيل "ORA-20206: "
                var firstLine = ex.Message.Split('\n')[0];
                var message = firstLine.Contains(": ")
                    ? firstLine[(firstLine.IndexOf(": ") + 2)..].Trim()
                    : firstLine;

                await ctx.Response.WriteAsJsonAsync(new { error = message });
            }
            catch (Exception ex)
            {
                // أي خطأ غير متوقع: نسجله ونرجع رسالة عامة
                _logger.LogError(ex, "Unhandled exception");
                ctx.Response.StatusCode = StatusCodes.Status500InternalServerError;
                await ctx.Response.WriteAsJsonAsync(new { error = "An unexpected error occurred." });
            }
        }
    }


}

