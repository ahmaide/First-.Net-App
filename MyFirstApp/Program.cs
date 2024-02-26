var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Wassssup");

app.MapGet("/method", (HttpContext context) => {
    string path = context.Request.Path;
    string method = context.Request.Method;
    return "(Path: " + path + ", Method: " + method + ")";

});

app.MapGet("/userAgent", (HttpContext context) =>{
    var userAgent = "";
    if (context.Request.Headers.ContainsKey("User-Agent"))
        userAgent = context.Request.Headers["User-Agent"];
    return "User Agent: " + userAgent;
});

app.MapGet("/html", (HttpContext context) =>
{
    context.Response.Headers["Content-Type"] = "text/html";
    return "<h1>It is Henry<h1>";
});

/*app.Run(async (HttpContext context) =>
{
    string[] paths = new string[5] { "/", "/method", "/userAgent", "/html"};
    string path = context.Request.Path;

    if (!paths.Contains(path)){
        context.Response.Headers["Content-Type"] = "text/html";
        await context.Response.WriteAsync("<h1>This Page isn't Available<h1>");
    }

});*/


app.Run();
