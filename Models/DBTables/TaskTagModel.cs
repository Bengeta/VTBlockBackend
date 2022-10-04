using System.ComponentModel.DataAnnotations.Schema;

namespace VTBlockBackend.Models.DBTables;
[Table("TaskTag")]
public class TaskTagModel
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    [ForeignKey("Task")] public int TaskId { get; set; }
    public TaskModel TaskModel { get; set; }

    [ForeignKey("Tag")] public int TagId { get; set; }
    public TagModel Tag { get; set; }
}