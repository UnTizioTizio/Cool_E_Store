using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoolEStore.Models;

public class ReviewModel
{
    public int Id { get; set; }
    [Range(1, 5)]
    public required byte NStars { get; set; }
    public string? Title { get; set; }
    public string? Comment { get; set;}

    public required int UserId { get; set; }
    public required UserModel User { get; set; }

    public required int ProductId { get; set; }
    public required ProductModel Product { get; set; }
}