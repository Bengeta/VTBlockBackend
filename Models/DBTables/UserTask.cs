using System.ComponentModel.DataAnnotations.Schema;

namespace VTBlockBackend.Models.DBTables;

[Table("UserTask")]
public class UserTask
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [ForeignKey("User")] public int UserId { get; set; }
    public UserModel User { get; set; }

    [ForeignKey("Task")] public int TaskId { get; set; }
    public TaskModel Task { get; set; }
}