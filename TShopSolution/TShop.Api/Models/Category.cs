using TShop.Contracts.Utils.Enums;

namespace TShop.Api.Models;

public class Category: Auditable
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string SeoUrl { get; set; } = string.Empty;
    public string? Description { get; set; }
    public Status Status { get; set; }

    public ICollection<Product> Products { get; set; } = new List<Product>();
}