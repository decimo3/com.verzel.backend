using Teste.Repositories;
using Teste.Repositories.CarroRepo.Interfaces;
using Teste.Servicies;
using Teste.Servicies.Interfaces;
using Teste.Controllers;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Teste.Repositories.UserRepo.Interfaces;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebAPI", Version = "v1" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description =
                        "JWT Authorization Header - utilizado com Bearer Authentication.\r\n\r\n" +
                        "Digite 'Bearer' [espaço] e então seu token no campo abaixo.\r\n\r\n" +
                        "Exemplo (informar sem as aspas): 'Bearer 12345abcdef'",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});
builder.Services.AddSqlite<DatabaseContext>("Data Source=database.db");
// Repositories
builder.Services.AddScoped<ICarroRepository, CarroRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
// Servicies
builder.Services.AddScoped<ICarroService, CarroService>();
builder.Services.AddScoped<IUserService, UserService>();
// builder.Services.AddScoped<AuthService>();

// Configure JWT authentication
var key = Encoding.ASCII.GetBytes("dasdasdasdasdasdasdasdadasdasdasdasdasdasdasdasdasdadasdasdasdaddasdasdasdasdasdasdasdadasdasdasdasdasdasdasdasdasdadasdasdasdad");
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