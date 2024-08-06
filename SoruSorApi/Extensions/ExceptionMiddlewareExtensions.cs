using Entities.ErrorModel;
using Entities.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using System.Net;

namespace SoruSorApi.Extensions
{
    public static class ExceptionMiddlewareExtensions
    {
        /// <summary>
        /// Configures the exception handler middleware to handle exceptions globally.
        /// Logs the exception details and returns a generic error message to the client.
        /// </summary>
        /// <param name="app">The <see cref="WebApplication"/> instance to configure.</param>
        public static void ConfigureExceptionHandler(this WebApplication app)
        {
            app.UseExceptionHandler(appErr =>
            {
                appErr.Run(async context =>
                {
                    context.Response.ContentType = "application/json";

                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();

                    if (contextFeature is not null)
                    {
                        context.Response.StatusCode = contextFeature.Error switch
                        {
                            NotFoundException => StatusCodes.Status404NotFound,
                            _ => StatusCodes.Status500InternalServerError
                        };

                        await context.Response.WriteAsync(new ErrorDetails()
                        {
                            StatusCode = context.Response.StatusCode,
                            Message = contextFeature.Error.Message
                        }.ToString());
                    }
                });
            });
        }
    }
}
