using BlazingPizza;
using Microsoft.EntityFrameworkCore;
using System;

namespace BlazzingPizza.Server.Data.Repositories
{
    public class PizzaSpecialRepo : IPizzaSpecialRepo
    {
        private readonly ApplicationDbContext? _context;
        public PizzaSpecialRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreatePizzaSpecial(PizzaSpecial pSpecial)
        {
            if (pSpecial == null)
                throw new ArgumentNullException(nameof(pSpecial));
            await _context.Specials.AddAsync(pSpecial);
        }

        public void DeletePizzaSpecial(PizzaSpecial pSpecial)
        {
            if (pSpecial == null)
                throw new ArgumentNullException(nameof(pSpecial));
            _context.Specials.Remove(pSpecial);
        }       

        public async Task<IEnumerable<PizzaSpecial>> GetAllPizzaSpecials()
        {
            return await _context.Specials.ToListAsync();
        }

        public async Task<PizzaSpecial> GetPizzaSpecialById(int Id)
        {
            return await _context.Specials.FirstOrDefaultAsync(c => c.Id == Id);
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}
