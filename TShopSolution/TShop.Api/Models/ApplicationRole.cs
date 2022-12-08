using Microsoft.AspNetCore.Identity;

namespace TShop.Api.Models;

public class ApplicationRole: IdentityRole<int>
{
    public string Description { get; set; } = string.Empty;
}
