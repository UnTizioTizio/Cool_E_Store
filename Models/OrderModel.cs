using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoolEStore.Models;

public class OrderModel
{
    public int Id { get; set; }
    
    [DataType(DataType.Date)]
    public required DateTime StartDeliveryDate { get; set; }

    [DataType(DataType.Date)]
    public required DateTime EstimatedDeliveryArrival { get; set; }

    public required int ShoppingBasketRecordId { get; set; }
    public required ShoppingBasketRecordModel ShoppingBasketRecord;

    [ForeignKey("User")]
    public required int UserId { get; set; }
    public required UserModel User { get; set; }
}