using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CoolEStore.Models;

public class ApplicationUserModel : IdentityUser<int>
{
    [Required]
    [StringLength(5)]
    public string CAP { get; set; } = null!;

    [Required]
    public string Address { get; set; } = null!;
    
    [Required]
    public ushort StreetNumber { get; set; }

    [Required]
    public UserType Type { get; set; }
}

public enum UserType
{
    Customer,
    Vendor
}