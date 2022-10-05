using System.ComponentModel.DataAnnotations.Schema;

namespace VTBlockBackend.Models.DBTables;

[Table("Check")]
public class Check
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    [ForeignKey("User")] public int UserId { get; set; }
    public UserModel User { get; set; }
    
    public string CheckHash { get; set; }
    
    public double Amount { get; set; }
}