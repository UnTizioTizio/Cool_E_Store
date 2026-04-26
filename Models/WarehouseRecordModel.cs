using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoolEStore.Models;

public class WarehouseRecordModel
{
    public int Id { get; set; }

    [Required]
    [Range(1, uint.MaxValue)]
    public int Amount { get; set; }

    [Required]
    [ForeignKey("Product")]
    public int ProductId { get; set; }
    public ProductModel Product { get; set; } = null!;

    [Required]
    [ForeignKey("Vendor")]
    public int VendorId { get; set; }
    public VendorModel Vendor { get; set; } = null!;
}