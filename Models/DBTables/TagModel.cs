using System.ComponentModel.DataAnnotations.Schema;

namespace VTBlockBackend.Models.DBTables;
[Table("Tag")]
public class TagModel
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Name { get; set; }
    public List<TaskTagModel> TaskTag { get; set; }
    public List<MarketItemTagModel> MarketItemTag { get; set; }
  }