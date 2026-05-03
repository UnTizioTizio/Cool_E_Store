using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoolEStore.Models;

public class OrderModel
{
    public int Id { get; set; }
    
    [Required]
    [DataType(DataType.Date)]
    public required DateTime StartDeliveryDate { get; set; }

    [Required]
    [DataType(DataType.Date)]
    public required DateTime EstimatedDeliveryArrival { get; set; }

    [Required]
    [ForeignKey("ShoppingBasketRecord")]
    public int ShoppingBasketRecordId { get; set; }
    public ShoppingBasketRecordModel? ShoppingBasketRecord;

    [Required]
    [ForeignKey("Customer")]
    public int CustomerId { get; set; }
    public CustomerModel? Customer { get; set; }
}