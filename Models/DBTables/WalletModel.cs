using System.ComponentModel.DataAnnotations.Schema;
using VTBlockBackend.Interfaces;

namespace VTBlockBackend.Models.DBTables;

[Table("Wallet")]
public class WalletModel
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int id { get; set; }
    [ForeignKey("User")] public int UserId { get; set; }
    public UserModel? User { get; set; }
    public double Balance { get; set; }
    public List<UserStocks> UserStocks { get; set; }
}