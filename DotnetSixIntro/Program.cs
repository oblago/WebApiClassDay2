// See https://aka.ms/new-console-template for more information
var builder = WebApplication.CreateBuilder();

var dev = new Developer("14", "Bob", "Smith", 52, "bob@aol.com");

Console.WriteLine($"The oncall developer is {dev}");


var app = builder.Build();

app.MapGet("/oncalldeveloper", () => dev);

app.Run();
