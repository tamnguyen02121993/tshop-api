namespace TShop.Api.Models;

public class OrderDetail
{
    public Guid Id { get; set; }
    public Guid ProductId { get; set; }
    public Guid OrderId { get; set; }
    public decimal Price { get; set; }
    public decimal? SalePrice { get; set; }
    public int Quantity { get; set; }


    public Product Product { get; set; } = new Product();
    public Order Order { get; set; } = new Order();
}

