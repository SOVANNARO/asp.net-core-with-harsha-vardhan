using Microsoft.Extensions.Primitives;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Run(async (HttpContext context) =>
{
    StreamReader reader = new StreamReader(context.Request.Body);
    string body = await reader.ReadToEndAsync();

    Dictionary<string, StringValues> queryDict = Microsoft.AspNetCore.WebUtilities.QueryHelpers.ParseQuery(body);
    if (queryDict.TryGetValue("firstName", out StringValues firstNameValues))
    {
        string? firstName = firstNameValues.FirstOrDefault();
        await context.Response.WriteAsync(firstName ?? "Unknown");
    }
    else
    {
        await context.Response.WriteAsync("First name not provided.");
    }
});

app.Run();