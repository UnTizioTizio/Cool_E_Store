using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoolEStore.Models;

public class WarehouseRecordModel
{
    public int Id { get; set; }

    [Range(1, uint.MaxValue)]
    public required int Amount { get; set; }

    [ForeignKey("Product")]
    public required int ProductId { get; set; }
    public required ProductModel Product { get; set; }

    [ForeignKey("Vendor")]
    public required int VendorId { get; set; }
    public required VendorModel Vendor { get; set; }
}