using Microsoft.AspNetCore.Authorization;
using Teste.Domain;
using Teste.Servicies.Interfaces;

namespace Teste.Controllers
{
    [Authorize]
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
            }).RequireAuthorization();

            app.MapPost("/carro", async (ICarroService service, Carro carro) =>
            {
                return await service.Post(carro);
            }).RequireAuthorization();

            app.MapPut("/carro", async (ICarroService service, Carro carro) =>
            {
                return await service.Put(carro);
            }).RequireAuthorization();

            app.MapDelete("/carro/{id}", async (ICarroService service, int id) =>
            {
                await service.Delete(id);
            }).RequireAuthorization();
        }
    }
}
