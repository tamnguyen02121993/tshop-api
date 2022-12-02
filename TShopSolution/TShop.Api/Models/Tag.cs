using TShop.Contracts.Utils.Enums;

namespace TShop.Api.Models;

public class Tag : Auditable
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Slug { get; set; } = string.Empty;
    public Status Status { get; set; }

    public ICollection<ProductTag> ProductTags { get; set; } = new List<ProductTag>();
}