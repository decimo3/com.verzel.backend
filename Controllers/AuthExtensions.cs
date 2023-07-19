using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using System.Security.Cryptography;
using Teste.Auth.Util;
using Teste.Domain;
using Teste.Servicies.Interfaces;

namespace Teste.Controllers
{
    public static class AuthExtensions
    {
        private static readonly string SecretKeyBytes = "dasdasdasdasdasdasdasdadasdasdasdasdasdasdasdasdasdadasdasdasdaddasdasdasdasdasdasdasdadasdasdasdasdasdasdasdasdasdadasdasdasdad"; // Use a sua chave secreta aqui

        [AllowAnonymous]
        public static void AddAuthRoutes(this WebApplication app)
        {
            app.MapPost("/login", async (IUserService service, User user) =>
            {
                // Instanciar o serviço de autenticação
                var jwtAuthenticationService = new JwtAuthenticationService(SecretKeyBytes, "WebApi", "React", 60);
                var authenticationService = new AuthenticationService(jwtAuthenticationService, service);

                // Autenticar o usuário e gerar o token JWT
                var token = await authenticationService.AuthenticateUser(user.Name, user.Password);

                if (token != null)
                {
                    // Se a autenticação for bem-sucedida, retornar o token JWT em formato JSON
                    return Results.Json(new { token });
                }
                else
                {
                    // Se a autenticação falhar, retornar uma resposta não autorizada (401 Unauthorized)
                    return Results.Unauthorized();
                }
            });

            app.MapPost("/register", (IUserService service, User user) =>
            {
                return service.Register(user);
            });
        }
    }
}
