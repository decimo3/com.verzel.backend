using Teste.Domain;
using Teste.Servicies.Interfaces;

namespace Teste.Controllers
{
    public static class RoutesExtension
    {
        public static WebApplication AddRoutes(this WebApplication app)
        {
            app.MapGet("/carros", async (ICarroService service) =>
            {
                return new List<Carro>();
                var result = await service.GetAll();
                return result;
            });

            app.MapGet("/carro/{id}", async (ICarroService service, int id) =>
            {
                var result = await service.GetById(id);
                return result;
            });

            app.MapPost("carro", async (ICarroService service, Carro carro) =>
            {
                return await service.Post(carro);
            });

            app.MapPut("carro", async (ICarroService service, Carro carro) =>
            {
                return await service.Put(carro);
            });

            app.MapDelete("carro/{id}", async (ICarroService service, int id) =>
            {
                await service.Delete(id);
            });

            return app;
        }
    }
}