using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CoolEStore.DTOs;

public record class CustomRegisterRequest
{
    [Required]
    [MaxLength(256)]
    public string UserName { get; set; } = string.Empty;

    [Required]
    [EmailAddress]
    [MaxLength(256)]
    public string Email { get; set; } = string.Empty;

    [Required]
    [StringLength(100, MinimumLength = 8)]
    public string Password { get; set; } = string.Empty;

    [Required]
    [Phone]
    public string PhoneNumber { get; set; } = string.Empty;

    [Required]
    [StringLength(5)]
    public string CAP { get; set; } = null!;

    [Required]
    public string Address { get; set; } = null!;
    
    [Required]
    public ushort StreetNumber { get; set; }

    [Required]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public Models.UserType Type { get; set; }
}