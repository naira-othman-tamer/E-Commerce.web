using Domain.Exceptions;
using Shared.ErrorModels;
namespace E_Commerce.Web.CustomMiddlewares;

public class CustomExceptionHandlerMiddleware(RequestDelegate _next ,
	ILogger<CustomExceptionHandlerMiddleware> _logger) //: IMiddleware
{
    public async Task InvokeAsync(HttpContext context)//, RequestDelegate next)
    {
		try
        {
            await _next.Invoke(context);
            await HandleNotFoundEndPointAsync(context);
        }
        catch (Exception ex)
        {
            //1- Set Status Code for response.2-set content type for response. 3- Response object. 4-Return object as json
            _logger.LogError(ex, "something went wrong");
            await HandleExceptionAsync(context, ex);
        }
    }

    private static async Task HandleExceptionAsync(HttpContext context, Exception ex)
    {
        var Response = new ErrorToReturn()
        {
            ErrorMessage = ex.Message
        }; 
        context.Response.StatusCode = ex switch
        {
            NotFoundException => StatusCodes.Status404NotFound,
            UnauthorizedException => StatusCodes.Status401Unauthorized,
            BadRequestException badRequestException => GetBadRequestErrors(badRequestException, Response),
            _ => StatusCodes.Status500InternalServerError
        };
        Response.statusCode = context.Response.StatusCode;
     
        await context.Response.WriteAsJsonAsync(Response);
    }

    private static int GetBadRequestErrors(BadRequestException badRequestException, ErrorToReturn response)
    {
        response.Errors = badRequestException.Errors;
        return  StatusCodes.Status400BadRequest;
    }

    private static async Task HandleNotFoundEndPointAsync(HttpContext context)
    {
        if (context.Response.StatusCode == StatusCodes.Status404NotFound)
        {
            var Response = new ErrorToReturn()
            {
                statusCode = StatusCodes.Status404NotFound,
                ErrorMessage = $"EndPoint '{context.Request.Path}' is Not Found"
            };
            await context.Response.WriteAsJsonAsync(Response);
        }
    }
}
