using System.ComponentModel.DataAnnotations.Schema;

namespace VTBlockBackend.Models.DBTables;

[Table("User")]
public class UserModel
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int id { get; set; }

    public string email { get; set; }
    public string token { get; set; }

    public string password { get; set; }

    public string salt { get; set; }

    public string username { get; set; }
    
    public List<UserTask> UserTasks { get; set; }
    public List<UserMarketItem> UserMarketItems { get; set; }
    public List<Check> Checks { get; set; }
}