using Microsoft.AspNetCore.Identity;

namespace seaplan.entity.Entities.Identity;

public class AppUser : IdentityUser<string>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string? RefreshToken { get; set; }
    public DateTime? RefreshTokenEndDate { get; set; }
    public ICollection<OrderItem>? OrderItems { get; set; }
    public ICollection<Payment> Payments { get; set; }
}