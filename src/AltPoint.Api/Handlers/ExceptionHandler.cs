using AltPoint.Application.DTOs.Errors;
using FluentValidation;
using Microsoft.AspNetCore.Diagnostics;
using System.Net;

namespace AltPoint.Api.Handlers
{
    public static class ExceptionHandler
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();

                    if (contextFeature.Error is ValidationException validationException)
                    {
                        context.Response.StatusCode = (int)HttpStatusCode.UnprocessableEntity;
                        var errors = validationException.Errors
                            .Select(x => new ValidationExceptions
                            {
                                field = x.PropertyName,
                                rule = x.ErrorCode,
                                message = x.ErrorMessage
                            })
                            .ToList();

                        var response = new ValidationError { status = (int)HttpStatusCode.UnprocessableEntity, code = ErrorCode.VALIDATION_EXCEPTION, exceptions = errors };

                        if (response != null)
                        {
                            await context.Response.WriteAsJsonAsync(response);
                        }
                    }
                });
            });
        }
    }
}
