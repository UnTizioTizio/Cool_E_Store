using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace CoolEStore.Models;

[Index(nameof(Email), nameof(PhoneNumber), IsUnique = true)]
public class UserModel
{
    public int Id { get; set; }
    
    [Required]
    [MaxLength(50), MinLength(3)]
    public required string Username { get; set; }
    
    [Required]
    [EmailAddress]
    public required string Email { get; set; }
    
    [Required]
    public required string Password { get; set; }

    [Required]
    [Phone]
    public required string PhoneNumber { get; set; }

    [Required]
    public uint CAP { get; set; }

    [Required]
    public required string Address { get; set; }
    
    [Required]
    public ushort StreetNumber { get; set; }
}