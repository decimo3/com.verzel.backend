using Teste.Repositories;
using Teste.Repositories.CarroRepo.Interfaces;
using Teste.Servicies;
using Teste.Servicies.Interfaces;
using Teste.Controllers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSqlite<DatabaseContext>("Data Source=database.db");
builder.Services.AddScoped<ICarrosRepository, CarrosRepository>();
builder.Services.AddScoped<ICarroService, CarroService>();
// builder.Services.AddScoped<AuthService>();

var app = builder.Build();

app.UseCors(builder => builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin()); // Enable CORS

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();
app.AddRoutes();
app.Run();
