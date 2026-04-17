using System.ComponentModel.DataAnnotations;

namespace CoolEStore.Models;

public class ShoppingBasketRecordModel
{
    public int Id { get; set; }
    
    [Range(1, uint.MaxValue)]
    public required uint Amount;

    [DataType(DataType.Date)]
    public required DateTime RegistrationDate;

    public required int ProductId { get; set; }
    public required ProductModel Product { get; set; }

    public required int UserId { get; set; }
    public required UserModel User { get; set; }
}