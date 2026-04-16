using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoolEStore.Models;

public class ProductModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal BasePrice { get; set; }
    [Range(1, 100)]
    public byte? Sales { get; set; }
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public decimal FinalPrice { get; set; }
    public string? Description { get; set; }
    public string Category { get; set; }
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public float AvgReviewStars { get; set; }
    public int VendorId { get; set; }
}