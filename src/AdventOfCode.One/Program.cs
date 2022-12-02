using AdventOfCode.Domain.Contracts;
using AdventOfCode.Domain.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<IElfFoodService, ElfFoodService>();

var app = builder.Build();

const string fileName = "input.txt";
var elfFoodService = new ElfFoodService();
var answerDayOne = elfFoodService.GetHighestCaloriesCount(fileName);

app.Run();


