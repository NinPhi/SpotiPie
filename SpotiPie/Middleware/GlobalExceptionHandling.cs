namespace SpotiPie.Middleware;

public class GlobalExceptionHandling : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception)
        {
            throw;
        }
    }
}
