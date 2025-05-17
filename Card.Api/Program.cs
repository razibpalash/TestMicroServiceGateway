var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.MapGet("/balance", () => "Card Service: Balance is $1000");
app.MapGet("/transactions", () => "Card Service: Last 5 transactions");
app.MapGet("/status", () => "Card Service: Connected");

app.Run();
