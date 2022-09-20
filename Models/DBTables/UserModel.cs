using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace VecoBackend.Models;

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
}