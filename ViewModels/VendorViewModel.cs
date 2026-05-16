using CoolEStore.Models;

namespace CoolEStore.ViewModels;
public class VendorViewModel
{
    public int Id { get; set; }
    public required ApplicationUserViewModel ApplicationUserViewModel { get; set; }
    public List<ProductViewModel>? ProductViewModels { get; set; }
}