using Core.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System.Net;

namespace Core.Utilities.Middlewares;

public class GlobalExceptionHandlerMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
		try
		{
			await next(context);
		}
		catch (Exception ex)
		{
		    await HandlingException(context, ex);
        }
    }

	public async Task HandlingException(HttpContext context, Exception exception)
	{
		context.Response.ContentType = "application/json";
		context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
		string message = "Internal server error";
		if (exception is ArgumentNullException)
		{
			message = "Argument is null";
		}
	    await context.Response.WriteAsync(
			new ErrorDetail
			{
				Message = message,
				StatusCode = context.Response.StatusCode
			}.ToString()
			);
	}
}
