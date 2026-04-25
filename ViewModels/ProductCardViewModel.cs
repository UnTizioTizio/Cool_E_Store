using CoolEStore.Models;

namespace CoolEStore.ViewModels;

public class ProductCardViewModel
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public decimal BasePrice { get; set; }
    public byte Discount { get; set; }
    public decimal FinalPrice { get; set; }
    public string? Description { get; set; }
    public ProductCategory Category { get; set; }
    
    public VendorModel? Vendor { get; set; }

    public List<ReviewModel>? Reviews { get; set; }

    public float AvgReviews 
    { 
        get 
        {
            if(Reviews == null || Reviews.Count == 0)
                return 0;

            int avg = 0;
            foreach(ReviewModel rev in Reviews)
                avg += rev.NStars;
            return (float)avg / Reviews.Count;
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