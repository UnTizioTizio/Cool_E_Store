using System.ComponentModel.DataAnnotations;
using CoolEStore.Models;

namespace CoolEStore.ViewModels;

public class ProductCardViewModel
{
    public int Id { get; set; }
    public required string Name { get; set; }

    [DisplayFormat(DataFormatString="{0:C}")]
    public decimal BasePrice { get; set; }
    
    [DisplayFormat(DataFormatString="-{0}%")]
    public byte Discount { get; set; }

    [DisplayFormat(DataFormatString="{0:C}")]
    public decimal FinalPrice { get; set; }
    
    public string? Description { get; set; }
    public ProductCategory Category { get; set; }
    
    public VendorModel Vendor { get; set; } = null!;
    public List<ReviewModel>? Reviews { get; set; }
    
    public float AvgReviews 
    { 
        get 
        {
            if(Reviews == null || Reviews.Count == 0)
                return 0;

            int avg = 0;
            Reviews.ForEach(review => avg += review.NStars);
            return MathF.Round((float)avg / Reviews.Count, 1);
        }
    }
    public int NumReviews 
    { 
        get
        {
            return (Reviews != null) 
                ? Reviews.Count
                : 0;
        }
    }
}