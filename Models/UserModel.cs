using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace CoolEStore.Models;

[Index(nameof(Email), nameof(PhoneNumber), IsUnique = true)]
public class UserModel
{
    public int Id { get; set; }
    public required string Username { get; set; }
    
    [EmailAddress]
    public required string Email { get; set; }
    
    [StringLength(20, MinimumLength = 8)]
    public required string Password { get; set; }

    [Phone]
    public required string PhoneNumber { get; set; }

    public required string Address { get; set; }
}