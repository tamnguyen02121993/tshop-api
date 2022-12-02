namespace TShop.Api.Models;

public class ProductTag
{
    public int TagId { get; set; }
    public Guid ProductId { get; set; }


    public Product Product { get; set; } = new();
    public Tag Tag { get; set; } = new();
}