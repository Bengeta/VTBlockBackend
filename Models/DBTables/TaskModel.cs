using System.ComponentModel.DataAnnotations.Schema;

namespace VTBlockBackend.Models.DBTables;

[Table("Task")]
public class TaskModel
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public string Name { get; set; }
    public string Description { get; set; }
    public int Reward { get; set; }
    public string CreatedBy { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime DeadLine { get; set; }
    public List<TaskTagModel> TaskTags { get; set; }

    public List<UserTask> UserTasks { get; set; }
    public List<TaskImage> TaskImages { get; set; }
}