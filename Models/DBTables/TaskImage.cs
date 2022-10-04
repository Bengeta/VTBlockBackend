using System.ComponentModel.DataAnnotations.Schema;

namespace VTBlockBackend.Models.DBTables;

[Table("TaskImage")]
public class TaskImage
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [ForeignKey("ImageStorage")] public int ImageId { get; set; }
    public ImageStorage Image { get; set; }

    [ForeignKey("Task")] public int TaskId { get; set; }
    public TaskModel Task { get; set; }
}