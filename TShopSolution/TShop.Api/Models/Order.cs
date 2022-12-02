using TShop.Contracts.Utils.Enums;

namespace TShop.Api.Models;

public class Order: Auditable
{
    public Guid Id { get; set; }
    public string Address { get; set; } = string.Empty;
    public decimal Total { get; set; }
    public float Tax { get; set; }
    public decimal? Discount { get; set; }
    public OrderStatus Status { get; set; }

    public ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}