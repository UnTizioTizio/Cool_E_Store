using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoolEStore.Models;

public class ShoppingBasketRecordModel
{
    public int Id { get; set; }
    
    [Range(1, uint.MaxValue)]
    public required uint Amount;

    [DataType(DataType.Date)]
    public required DateTime RegistrationDate;

    [ForeignKey("Product")]
    public required int ProductId { get; set; }
    public required ProductModel Product { get; set; }

    [ForeignKey("User")]
    public required int UserId { get; set; }
    public required UserModel User { get; set; }
}