using System.Net;
using Microsoft.AspNetCore.Diagnostics;
using UserSystem.Domain.Entities;
using UserSystem.Domain.Exceptions;

namespace UserSystem.Presentation.Middlewares;

public static class ApiExceptionMiddleware
{
    public static void ConfigureExceptionHandler(this IApplicationBuilder app)
    {
        app.UseExceptionHandler(appError =>
        {
            appError.Run(async context =>
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = "application/json";

                var contextFeature = context.Features.Get<IExceptionHandlerFeature>();

                if (contextFeature != null)
                {
                    var exception = contextFeature.Error;

                    context.Response.StatusCode = exception switch
                    {
                        UserNotFoundException =>
                            StatusCodes.Status404NotFound,
                        
                        _ =>
                            StatusCodes.Status500InternalServerError
                    };

                    await context.Response.WriteAsync(new ErrorDetails()
                    {
                        StatusCode = context.Response.StatusCode,
                        Message = contextFeature.Error.Message,
                        Trace = contextFeature.Error.StackTrace
                    }.ToString());
                }
            });
        });
    }
}
