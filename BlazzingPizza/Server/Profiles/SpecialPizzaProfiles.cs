using AutoMapper;
using BlazingPizza;
using BlazzingPizza.Shared.Dtos.PizzaSpecial;

namespace BlazzingPizza.Server.Profiles
{
    public class SpecialPizzaProfiles : Profile
    {
        public SpecialPizzaProfiles()
        {
            // Source --> Target
            CreateMap<PizzaSpecial, PizzaSpecialReadDto>();
        }
    }
}
