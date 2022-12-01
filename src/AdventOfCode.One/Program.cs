using AdventOfCode.One.Contacts;
using AdventOfCode.One.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<IElfFoodScraperService, ElfFoodScraperService>();
builder.Services.AddTransient<IElfFoodService, ElfFoodService>();
builder.Services.AddControllers();

var app = builder.Build();

app.MapGet("/", () =>  Results.Redirect("/ElfFood/Get"));
app.MapControllers();
app.Run();