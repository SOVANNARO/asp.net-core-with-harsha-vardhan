namespace asp.net_core_with_harsha_vardhan.CustomeMiddleware;

public class MyCustomMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        await context.Response.WriteAsync("My Custom Middleware! Start\n");
        await next(context);
        await context.Response.WriteAsync("My Custom Middleware! End");
    }
}