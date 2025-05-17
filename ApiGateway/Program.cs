using Microsoft.AspNetCore.HttpOverrides;
using Yarp.ReverseProxy;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddReverseProxy().LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));
// Log loaded routes
var routes = builder.Configuration.GetSection("ReverseProxy:Routes").GetChildren();
foreach (var route in routes)
{
    Console.WriteLine($"Loaded Route ID: {route.Key}");
}

var app = builder.Build();

// Enable forwarding for proxy headers (optional, for Docker/K8s)
app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
});

app.MapGet("/", () => "API Gateway Running");

// Use YARP Reverse Proxy
app.MapReverseProxy();

app.Run();
