using System.ComponentModel;

namespace CoolEStore.ViewModels;

public class ApplicationUserViewModel
{
    public int Id;
    
    [DisplayName("Username")]
    public string UserName { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    [DisplayName("Phone number")]
    public string PhoneNumber { get; set; } = string.Empty;

    public string CAP { get; set; } = string.Empty;

    public string Address { get; set; } = string.Empty;

    [DisplayName("Street number")]    
    public ushort StreetNumber { get; set; }

    public Models.UserType Type { get; set; }
}