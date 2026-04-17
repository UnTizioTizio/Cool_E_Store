using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoolEStore.Models;

public class ProductModel
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public decimal BasePrice { get; set; }
    [Range(1, 100)]
    public byte? Sales { get; set; }
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public decimal FinalPrice { get; set; }
    public string? Description { get; set; }
    public ProductCategory Category { get; set; }
    public int VendorId { get; set; }
}

public enum ProductCategory
{
    Books,
    Electronics,
    Comics,
    Movies,
    Videogames
}