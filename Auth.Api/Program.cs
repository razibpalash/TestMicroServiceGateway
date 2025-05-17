var builder = WebApplication.CreateBuilder(args);


var app = builder.Build();

app.MapGet("/login", () => "Auth Service: Login Successful");
app.MapGet("/status", () => "Auth Service: Active");

app.Run();
