using FluentValidation;
using System;

namespace CRM.Api.Middleware
{
    public class ExceptionMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (ValidationException ex)
            {
                await HandleValidationException(context, ex);
            }
            catch (Exception ex)
            {
                //context.Response.StatusCode = 500;
                //context.Response.ContentType = "application/json";
                //var errorResponse = new { message = ex.Message };
                //return context.Response.WriteAsJsonAsync(errorResponse);
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }
        }

        private static async Task HandleValidationException(HttpContext context, ValidationException ex)
        {
            var validationErrors = new Dictionary<string, string[]>();

            if (ex.Errors != null)
            {
                foreach (var error in ex.Errors)
                {
                    if (validationErrors.ContainsKey(error.PropertyName))
                    {
                        var errors = validationErrors[error.PropertyName].ToList();
                        errors.Add(error.ErrorMessage);
                        validationErrors[error.PropertyName] = errors.ToArray();
                    }
                    else
                    {
                        validationErrors[error.PropertyName] = new[] { error.ErrorMessage };
                    }
                }
            }

            context.Response.StatusCode = StatusCodes.Status400BadRequest;

            var validationProblemDetails = new HttpValidationProblemDetails(validationErrors)
            {
                Type = "ValidationFailure",
                Title = "Validation error",
                Status = StatusCodes.Status400BadRequest,
                 Detail = "One or more validation errors occurred."

            };
            
            await context.Response.WriteAsJsonAsync(validationProblemDetails);
        }
    }
}
