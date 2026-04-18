using System.ComponentModel.DataAnnotations;

namespace CoolEStore.Models;

public class WarehouseRecord
{
    public int Id { get; set; }

    [Range(1, uint.MaxValue)]
    public required int Amount { get; set; }

    public required int ProductId { get; set; }
    public required ProductModel Product { get; set; }

    public required int VendorId { get; set; }
    public required VendorModel Vendor { get; set; }
}