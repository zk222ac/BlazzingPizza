using System.ComponentModel.DataAnnotations.Schema;

namespace BlazingPizza;

public class Topping
{
    public int Id { get; set; }

    public string? Name { get; set; }

    [Column(TypeName = "decimal(18,4)")]
    public decimal Price { get; set; }

    public string GetFormattedPrice() => Price.ToString("0.00");

}