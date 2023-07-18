using Microsoft.AspNetCore.Authorization;
using Teste.Domain;
using Teste.Servicies.Interfaces;

namespace Teste.Controllers
{
    [Authorize(Roles = "Admin, User")]
    public static class RoutesExtension
    {
        public static void AddRoutes(this WebApplication app)
        {
            app.MapGet("/carros", async (ICarroService service) =>
            {
                var result = await service.GetAll();
                return result.ToList();
            });

            app.MapGet("/carro/{id}", async (ICarroService service, int id) =>
            {
                var result = await service.GetById(id);
                return result;
            });

            app.MapPost("/carro", async (ICarroService service, Carro carro) =>
            {
                return await service.Post(carro);
            });

            app.MapPut("/carro", async (ICarroService service, Carro carro) =>
            {
                return await service.Put(carro);
            });

            app.MapDelete("/carro/{id}", async (ICarroService service, int id) =>
            {
                await service.Delete(id);
            });
        }
    }
}
