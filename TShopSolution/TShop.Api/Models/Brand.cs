using TShop.Contracts.Utils.Enums;

namespace TShop.Api.Models;

public class Brand : Auditable
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Summary { get; set; }
    public Status Status { get; set; }

    public ICollection<Product> Products { get; set; } = new List<Product>();
}