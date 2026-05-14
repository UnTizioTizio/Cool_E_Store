using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CoolEStore.Models;

[Index(nameof(ApplicationUserId), IsUnique = true)]
public class VendorModel
{
    public int Id { get; set; }
    
    [Required]
    [ForeignKey("ApplicationUser")]
    public int ApplicationUserId { get; set; }
    public ApplicationUserModel? ApplicationUser { get; set; }

    public List<WarehouseRecordModel>? WarehouseRecords { get; set; }
    public List<ProductModel>? Products { get; set; }
}