using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazzingPizza.Shared.Dtos.PizzaSpecial
{
    public class PizzaSpecialReadDto
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal BasePrice { get; set; }

        public string? Description { get; set; }

        public string? ImageUrl { get; set; }

        public string GetFormattedBasePrice() => BasePrice.ToString("0.00");

    }
}
