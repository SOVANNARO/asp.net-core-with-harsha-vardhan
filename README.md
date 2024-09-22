
### 🟢 Introduction to HTTP
HTTP is an application-protocol that defines set of rules to send request from
to server and send response from server to browser. <br />

Initially developed by Time Berners Lee, later standardized by IETF (Internet Engineering Task Force)
and W3C (World Wide Web Consortiums)

![img_1.png](img_1.png)

### 🟢 HTTP Response

![img_2.png](img_2.png)
![img_3.png](img_3.png)
![img_4.png](img_4.png)

### 🟢 HTTP Status Codes
![img_5.png](img_5.png)

```javascript
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Run(async (HttpContext context) =>
{
    if (1 == 1)
    {
        context.Response.StatusCode = 200;
    }
    else
    {
        context.Response.StatusCode = 400;
    }
    await context.Response.WriteAsync("Hello");
    await context.Response.WriteAsync(" World!");
});

app.Run();

```

### 🟢 HTTP Response Headers
![img_6.png](img_6.png)
![img_7.png](img_7.png)
![img_8.png](img_8.png)

```javascript
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Run(async (HttpContext context) =>
{
    context.Response.Headers["My-Key"] = "my value";
    context.Response.Headers["Server"] = "my server value";
    await context.Response.WriteAsync("<h1>Hello World!</h1>");
    await context.Response.WriteAsync("<h2>Hello World!</h2>");
});

app.Run();
```
### 🟢 HTTP Request
![img_9.png](img_9.png)

```javascript
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Run(async (HttpContext context) =>
{
    string path = context.Request.Path;
    string method = context.Request.Method;
    
    context.Response.Headers["Context-type"] = "text/html";
    await context.Response.WriteAsync($"<p>{path}</p>");
    await context.Response.WriteAsync($"<p>{method}</p>");
});

app.Run();
```

### 🟢 Query String
![img_10.png](img_10.png)

```javascript
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Run(async (HttpContext context) =>
{
    context.Response.Headers["content-type"] = "text/html";
    if (context.Request.Method == "GET")
    {
        if (context.Request.Query.ContainsKey("id"))
        {
            string? id = context.Request.Query["id"];
            await context.Response.WriteAsync($"<h1>{id}</h1>");
        }
    }
});

app.Run();
```

### 🟢 HTTP Request Header

```javascript
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Run(async (HttpContext context) =>
{
    context.Response.Headers["Content-Type"] = "text/html";
    if (context.Request.Headers.ContainsKey("User-Agent"))
    {
        string? userAgent = context.Request.Headers["User-Agent"];
        await context.Response.WriteAsync($"<p>{userAgent}</p>");
    }
});

app.Run();
```

### 🟢 Postman
```javascript
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Run(async (HttpContext context) =>
{
    context.Response.Headers["Content-Type"] = "text/html";
    if (context.Request.Headers.ContainsKey("AuthorizationKey"))
    {
        string? userAgent = context.Request.Headers["AuthorizationKey"];
        await context.Response.WriteAsync($"<p>{userAgent}</p>");
    }
});

app.Run();
```

## 🟢 HTTP Request Methods
![img_11.png](img_11.png)

### 🟢 HTTP Get VS Post
```javascript
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
```