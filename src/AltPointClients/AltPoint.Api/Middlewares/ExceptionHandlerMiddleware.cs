using AltPoint.Application.DTOs.Errors;
using FluentValidation;
using System.Net;
using System.Text.Json;

namespace AltPoint.Api.Middlewares
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                var response = context.Response;
                response.ContentType = "application/json";
                var responseModel = new Application.DTOs.Errors.Error();

                switch (error)
                {
                    case ValidationException e: 
                        response.StatusCode = (int)HttpStatusCode.UnprocessableEntity;
                        responseModel.status = (int)HttpStatusCode.UnprocessableEntity;
                        responseModel.code = ErrorCode.VALIDATION_EXCEPTION;
                        responseModel.exceptions = e.Errors.Select(x => new ErrorException
                        {
                            field = x.PropertyName,
                            rule = x.ErrorCode,
                            message = x.ErrorMessage
                        }).ToList();
                        break;
                    case ArgumentNullException e:
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        responseModel.status = (int)HttpStatusCode.NotFound;
                        responseModel.code = ErrorCode.ENTITY_NOT_FOUND;
                        break;
                    default:
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        responseModel.status = (int)HttpStatusCode.InternalServerError;
                        responseModel.code = ErrorCode.INTERNAL_SERVER_ERROR;
                        break;
                }
                var result = JsonSerializer.Serialize(responseModel);

                await response.WriteAsync(result);
            }
        }
    }
}
