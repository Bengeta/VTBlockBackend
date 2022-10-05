using System.ComponentModel.DataAnnotations.Schema;

namespace VTBlockBackend.Models.DBTables;
[Table("UserMarketItem")]
public class UserMarketItem
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    [ForeignKey("User")] public int UserId { get; set; }
    public UserModel User { get; set; }

    [ForeignKey("MarketItem")] public int MarketItemId { get; set; }
    public MarketItemModel MarketItem { get; set; }
}