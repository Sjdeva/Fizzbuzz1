using MyApi.Core.Services;

var builder = WebApplication.CreateBuilder(args);

// Register individual strategies for dependency injection collection matching the pattern
builder.Services.AddScoped<IFizzBuzzStrategy, InvalidInputStrategy>();
builder.Services.AddScoped<IFizzBuzzStrategy, MathematicalFizzBuzzStrategy>();
builder.Services.AddScoped<IFizzBuzzStrategy, DivisionStepStrategy>();

// Register structural components
builder.Services.AddScoped<IFizzBuzzStrategyFactory, FizzBuzzStrategyFactory>();
builder.Services.AddScoped<IFizzBuzzProcessor, FizzBuzzProcessor>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();

app.Run();