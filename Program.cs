using Teste.Repositories;
using Teste.Repositories.CarroRepo.Interfaces;
using Teste.Servicies;
using Teste.Servicies.Interfaces;
using Teste.Controllers;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Teste.Repositories.UserRepo.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSqlite<DatabaseContext>("Data Source=database.db");
// Repositories
builder.Services.AddScoped<ICarroRepository, CarroRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
// Servicies
builder.Services.AddScoped<ICarroService, CarroService>();
builder.Services.AddScoped<IUserService, UserService>();
// builder.Services.AddScoped<AuthService>();

// Configure JWT authentication
var key = Encoding.ASCII.GetBytes("SECRET_KEY");
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = false; // Set to true in production
        options.SaveToken = true;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = false, // Set to true in production if you have an issuer
            ValidateAudience = false, // Set to true in production if you have an audience
        };
    });


var app = builder.Build();

app.UseCors(builder => builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin()); // Enable CORS

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.AddRoutes();
app.AddAuthRoutes();
app.Run();
