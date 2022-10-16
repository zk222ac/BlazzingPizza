using System.ComponentModel.DataAnnotations.Schema;

namespace BlazingPizza;

/// <summary>
/// Represents a pre-configured template for a pizza a user can order
/// </summary>
public class PizzaSpecial
{
    public int Id { get; set; }

    public string? Name { get; set; }

    [Column(TypeName = "decimal(18,4)")]
    public decimal BasePrice { get; set; }

    public string? Description { get; set; }

    public string? ImageUrl { get; set; }

    public string GetFormattedBasePrice() => BasePrice.ToString("0.00");
}