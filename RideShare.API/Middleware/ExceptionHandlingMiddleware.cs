using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RideShare.Application;
using RideShare.Application.Exceptions;
using RideShare.Application.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace RideShare.API.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IErrorLogger _logger;

        public ExceptionHandlingMiddleware(RequestDelegate next, IErrorLogger logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch(ValidationException exception)
            {
                context.Response.StatusCode = 422;
                var errors = exception.Errors.Select(x => new
                {
                    x.ErrorMessage,
                    x.PropertyName
                });

                await context.Response.WriteAsJsonAsync(errors);
            }
            catch (UnauthorizedUseCaseException)
            {
                context.Response.StatusCode = 401;
            }
            catch (UnauthorizedAccessException)
            {
                context.Response.StatusCode = 401;
            }
            catch (EntityAlreadyExistsException)
            {
                context.Response.StatusCode = 422;
            }
            catch (EntityNotFoundException)
            {
                context.Response.StatusCode = 200;
            }
            catch(DeleteOperationException exception)
            {
                context.Response.StatusCode = 409;
                var error = new
                {
                    message = exception.Message.ToString()
                };

                await context.Response.WriteAsJsonAsync(error);
            }
            catch (Exception ex)
            {
                Guid errorId = Guid.NewGuid();
                AppError error = new AppError
                {
                    ErrorId = errorId,
                    Exception = ex
                };

                _logger.Log(error);

                context.Response.StatusCode = 500;
                context.Response.ContentType = "application/json";
                var responseBody = new
                {
                    message = $"There was an error, please contact support with this error code: {errorId}."
                };
                await context.Response.WriteAsJsonAsync(responseBody);
            }
        }
    }
}
