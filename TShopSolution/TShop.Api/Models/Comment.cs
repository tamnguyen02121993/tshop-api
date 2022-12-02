using TShop.Contracts.Utils.Enums;

namespace TShop.Api.Models;
public class Comment
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public CommentStatus Status { get; set; }
    public Guid ProductId { get; set; }
    public Guid CommentId { get; set; }

    public Product Product { get; set; } = new Product();
    public Comment ParentComment { get; set; } = new Comment();
}
