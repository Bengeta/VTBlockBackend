using Microsoft.EntityFrameworkCore;
using VTBlockBackend.Models;
using VTBlockBackend.Models.DBTables;

namespace VTBlockBackend.Data;

public class ApplicationContext : DbContext
{
    private IConfiguration _configuration;

    public ApplicationContext(DbContextOptions<ApplicationContext> options, IConfiguration configuration) :
        base(options)
    {
        _configuration = configuration;
    }

    public DbSet<UserModel> Users { get; set; }
    public DbSet<MarketItemModel> MarketItem { get; set; }
    public DbSet<TaskModel> Task { get; set; }
    public DbSet<TagModel> Tag { get; set; }
    public DbSet<ImageStorage> ImageStorage { get; set; }
    public DbSet<TaskImage> TaskImage { get; set; }
    public DbSet<MarketItemImage> MarketItemImage { get; set; }
    public DbSet<MarketItemTagModel> MarketItemTag { get; set; }
    public DbSet<TaskTagModel> TaskTag { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserModel>().HasIndex(u => u.email).IsUnique();
        modelBuilder.Entity<UserModel>().HasIndex(u => u.token).IsUnique();

        modelBuilder.Entity<UserTask>().HasOne(x => x.User)
            .WithMany(x => x.UserTasks).HasForeignKey(x => x.UserId);
        modelBuilder.Entity<UserTask>().HasOne(x => x.Task)
            .WithMany(x => x.UserTasks).HasForeignKey(x => x.TaskId);

        modelBuilder.Entity<TaskImage>().HasOne(x => x.Task)
            .WithMany(x => x.TaskImages).HasForeignKey(x => x.TaskId);
        modelBuilder.Entity<TaskImage>().HasOne(x => x.Image)
            .WithMany(x => x.TaskImages).HasForeignKey(x => x.ImageId);

        modelBuilder.Entity<MarketItemImage>().HasOne(x => x.Image)
            .WithMany(x => x.MarketItemImages).HasForeignKey(x => x.MarketItemId);
        modelBuilder.Entity<MarketItemImage>().HasOne(x => x.MarketItem)
            .WithMany(x => x.MarketItemImages).HasForeignKey(x => x.ImageId);
        

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = _configuration.GetConnectionString("MainDB");
        optionsBuilder.UseNpgsql(connectionString);
    }
}