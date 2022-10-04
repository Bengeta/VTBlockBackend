using System.ComponentModel.DataAnnotations.Schema;

namespace VTBlockBackend.Models.DBTables;
[Table("MarketItemTag")]
public class MarketItemTagModel
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    [ForeignKey("MarketItem")] public int MarketItemId { get; set; }
    public MarketItemModel MarketItem { get; set; }

    [ForeignKey("Tag")] public int TagId { get; set; }
    public TagModel Tag { get; set; }
}