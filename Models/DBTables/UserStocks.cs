using System.ComponentModel.DataAnnotations.Schema;
using VTBlockBackend.Models.DBTables;

namespace VTBlockBackend.Interfaces;

[Table("UserStocks")]
public class UserStocks
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int id { get; set; }
    public int WalletId { get; set; }
    public WalletModel Wallet { get; set; }
    public string SecId { get; set; }
    public int Amount { get; set; }
    
}