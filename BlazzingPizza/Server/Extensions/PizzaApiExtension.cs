using AutoMapper;
using BlazzingPizza.Server.Data.Repositories;
using BlazzingPizza.Shared.Dtos.PizzaSpecial;

namespace BlazzingPizza.Server.Extensions
{
    public static class PizzaApiExtension
    {
        public static WebApplication MapPizzaApi(this WebApplication app)
        {
            // Specials
            //app.MapGet("/specials", async (PizzaStoreContext db) => {

            //    var specials = await db.Specials.ToListAsync();
            //    return Results.Ok(specials);

            //});
            // Get Specials 
            app.MapGet("api/specials", async (IPizzaSpecialRepo repo, IMapper mapper) =>
            {
                var pSpecials = await repo.GetAllPizzaSpecials();
                return Results.Ok(mapper.Map<IEnumerable<PizzaSpecialReadDto>>(pSpecials));
            });
            return app;
        }
    }
}
