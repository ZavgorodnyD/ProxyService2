using ProxyService2.Interfaces;
using ProxyService2.Services;
using Serilog;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Налаштовуємо Serilog
Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File("../logs/WebAppLog-.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

// Налаштовуємо Serilog як логер для програми
builder.Host.UseSerilog();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Реєструємо HttpClient та сервіси
builder.Services.AddHttpClient();
builder.Services.AddScoped<IUserService, UserService>(); // Реєструємо наш сервіс


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

Log.Information("Starting web host");
app.Run();
