using AltPoint.Api.Middlewares;

namespace AltPoint.Api.Extensions
{
    public static class AppExtension
    {
        public static void UseExceptionHandlerMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionHandlerMiddleware>();
        }
    }
}
