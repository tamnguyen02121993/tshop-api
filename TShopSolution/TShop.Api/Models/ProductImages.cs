namespace TShop.Api.Models;

public class ProductImages
{
    public Guid Id { get; set; }
    public string Url { get; set; } = string.Empty;
    public Guid ProductId { get; set; }

    public Product Product { get; set; } = new Product();
}