using ProxyService2.Interfaces;
using ProxyService2.Services;
using Serilog;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// ����������� Serilog
Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File("../logs/WebAppLog-.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

// ����������� Serilog �� ����� ��� ��������
builder.Host.UseSerilog();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// �������� HttpClient �� ������
builder.Services.AddHttpClient();
builder.Services.AddScoped<IUserService, UserService>(); // �������� ��� �����


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
