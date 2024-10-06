using asp.net_core_with_harsha_vardhan.CustomeMiddleware;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<MyCustomMiddleware>();
var app = builder.Build();

// middleware 1
app.Use(async (HttpContext context, RequestDelegate next) =>
{
    await context.Response.WriteAsync("Hello from Middleware 1!\n");
    await next(context);
});

// middleware 2
app.Use(async (HttpContext context, RequestDelegate next) =>
{
    await context.Response.WriteAsync("Hello from Middleware 2!\n");
    await next(context);
});

// middleware with custom
// app.UseMiddleware<MyCustomMiddleware>();
app.UseHelloCustomMiddleware();

// middleware useWhen
app.UseWhen(context => context.Request.Query.ContainsKey("username"), app =>
{
    app.Use(async (context, next) =>
    {
        await context.Response.WriteAsync("Hello from Middleware Branch \n");
        await next(context);
    });
});

// middleware 3
app.Run(async (HttpContext context) => { await context.Response.WriteAsync("Hello from Middleware 3!\n"); });

app.Run();