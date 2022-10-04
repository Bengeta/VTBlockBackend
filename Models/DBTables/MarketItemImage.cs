using System.ComponentModel.DataAnnotations.Schema;

namespace VTBlockBackend.Models.DBTables;

[Table("MarketItemImage")]
public class MarketItemImage
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [ForeignKey("ImageStorage")] public int ImageId { get; set; }
    public ImageStorage Image { get; set; }

    [ForeignKey("MarketItem")] public int MarketItemId { get; set; }
    public MarketItemModel MarketItem { get; set; }
}