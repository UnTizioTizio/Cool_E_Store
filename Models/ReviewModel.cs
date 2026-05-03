using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoolEStore.Models;

public class ReviewModel
{
    public int Id { get; set; }
    
    [Required]
    [Range(1, 5)]
    public byte NStars { get; set; }
    
    public string? Title { get; set; }
    public string? Comment { get; set;}

    [Required]
    [ForeignKey("Customer")]
    public int CustomerId { get; set; }
    public CustomerModel? Customer { get; set; }

    [Required]
    [ForeignKey("Product")]
    public int ProductId { get; set; }
    public ProductModel? Product { get; set; }
}