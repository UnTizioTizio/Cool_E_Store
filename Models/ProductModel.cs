using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoolEStore.Models;

public class ProductModel
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required decimal BasePrice { get; set; }
    
    [Range(1, 100)]
    public byte? Sales { get; set; }
    
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public required decimal FinalPrice { get; set; }
    
    public string? Description { get; set; }
    public required ProductCategory Category { get; set; }
    
    [ForeignKey("Vendor")]
    public required int VendorId { get; set; }
    public required VendorModel Vendor { get; set; }
}

public enum ProductCategory
{
    Books,
    Electronics,
    Comics,
    Movies,
    Videogames
}