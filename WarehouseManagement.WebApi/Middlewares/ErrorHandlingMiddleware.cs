namespace WarehouseManagement.WebApi.Middlewares;
public class ErrorHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ErrorHandlingMiddleware> _logger;

    public ErrorHandlingMiddleware(
    RequestDelegate next,
    ILogger<ErrorHandlingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
          //  _logger.LogError(ex, "Unhandled exception occurred");

            int statusCode = ex switch
            {
                NotFoundException => StatusCodes.Status404NotFound,
                UnauthorizedException => StatusCodes.Status401Unauthorized,
                BusinessException => StatusCodes.Status400BadRequest,
                _ => StatusCodes.Status500InternalServerError
            };

            string message = statusCode switch
            {
                StatusCodes.Status400BadRequest =>
                    ex.Message.IsPersian() ? ex.Message : "درخواست ارسال شده نامعتبر است.",

                StatusCodes.Status401Unauthorized =>
                   ex.Message.IsPersian() ? ex.Message : "شما مجوز دسترسی به این بخش را ندارید. لطفاً وارد حساب کاربری خود شوید.",

                StatusCodes.Status404NotFound =>
                    ex.Message.IsPersian() ? ex.Message : "منبع یا اطلاعات مورد نظر یافت نشد.",

                StatusCodes.Status500InternalServerError =>
                  ex.Message.IsPersian() ? ex.Message : "خطای غیرمنتظره‌ای در سرور رخ داده است. لطفاً بعداً دوباره تلاش کنید.",

                _ =>
                    "خطایی در پردازش درخواست رخ داده است."
            };

            /*
               200 → موفق
               400 → خطای کاربر / درخواست نامعتبر
               401 → عدم احراز هویت / عدم دسترسی
               404 → منبع پیدا نشد
               500 → خطای داخلی سرور
            */
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = statusCode;
            await context.Response.WriteAsJsonAsync(OkApiResult<string>.Fail(
                 null, message));
        }
    }
}