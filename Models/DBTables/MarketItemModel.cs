using System.ComponentModel.DataAnnotations.Schema;
using VTBlockBackend.Enums;
using VTBlockBackend.Models.DBTables;

namespace VTBlockBackend.Models;

[Table("MarketItem")]
public class MarketItemModel
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int Price { get; set; }
    public int Quantity { get; set; }
    public MarketItemCategory Category { get; set; }
    public List<MarketItemImage> MarketItemImages { get; set; }
    
    public List<UserMarketItem> UserMarketItems { get; set; }
    public List<MarketItemTagModel> MarketItemTags { get; set; }
}