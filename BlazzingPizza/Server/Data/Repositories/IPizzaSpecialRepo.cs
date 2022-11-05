using BlazingPizza;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace BlazzingPizza.Server.Data.Repositories
{
    public interface IPizzaSpecialRepo
    {
        Task SaveChanges();
        Task<PizzaSpecial> GetPizzaSpecialById(int Id);
        Task<IEnumerable<PizzaSpecial>> GetAllPizzaSpecials();
        Task CreatePizzaSpecial(PizzaSpecial pizza);
        void DeletePizzaSpecial(PizzaSpecial pizza);
    }
}
