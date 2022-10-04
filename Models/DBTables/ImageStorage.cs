using System.ComponentModel.DataAnnotations.Schema;

namespace VTBlockBackend.Models.DBTables;

[Table("ImageStorage")]
public class ImageStorage
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public string imageUrl { get; set; }
    public List<TaskImage> TaskImages { get; set; }
    public List<MarketItemImage> MarketItemImages { get; set; }
}