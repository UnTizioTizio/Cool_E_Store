using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoolEStore.Models;

public class ProductModel
{
    public int Id { get; set; }
    
    [Required]
    [MaxLength(100)]
    public required string Name { get; set; }
    
    [Required]
    [Column(TypeName = "DECIMAL(18, 2)")]
    public decimal BasePrice { get; set; }
    
    [Range(0, 100)]
    public byte? Sales { get; set; }
    
    [Column(TypeName = "DECIMAL(18, 2)")]
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public decimal FinalPrice { get; set; }
    
    public string? Description { get; set; }
    
    [Required]
    public ProductCategory Category { get; set; }
    
    [Required]
    [ForeignKey("Vendor")]
    public int VendorId { get; set; }
    public VendorModel? Vendor { get; set; }
}

public enum ProductCategory
{
    Books,
    Electronics,
    Comics,
    Movies,
    Videogames
}