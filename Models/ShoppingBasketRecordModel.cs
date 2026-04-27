using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoolEStore.Models;

public class ShoppingBasketRecordModel
{
    public int Id { get; set; }
    
    [Required]
    [Range(1, uint.MaxValue)]
    public uint Amount;

    [Required]
    [DataType(DataType.Date)]
    public required DateTime RegistrationDate;

    [Required]
    [ForeignKey("Product")]
    public int ProductId { get; set; }
    public ProductModel? Product { get; set; }

    [Required]
    [ForeignKey("User")]
    public int UserId { get; set; }
    public UserModel? User { get; set; }
}