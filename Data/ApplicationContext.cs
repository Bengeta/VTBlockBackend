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
    public DbSet<UserTask> UserTask { get; set; }
    public DbSet<Check> Check { get; set; }

    public DbSet<UserMarketItem> UserMarketItems { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserModel>().HasIndex(u => u.email).IsUnique();
        modelBuilder.Entity<UserModel>().HasIndex(u => u.token).IsUnique();
        modelBuilder.Entity<Check>().HasIndex(u => u.CheckHash).IsUnique();

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

        modelBuilder.Entity<UserMarketItem>().HasOne(x => x.User)
            .WithMany(x => x.UserMarketItems).HasForeignKey(x => x.UserId);
        modelBuilder.Entity<UserMarketItem>().HasOne(x => x.MarketItem)
            .WithMany(x => x.UserMarketItems).HasForeignKey(x => x.MarketItemId);

        modelBuilder.Entity<TaskTagModel>().HasOne(x => x.Tag)
            .WithMany(x => x.TaskTag).HasForeignKey(x => x.TagId);
        modelBuilder.Entity<TaskTagModel>().HasOne(x => x.TaskModel)
            .WithMany(x => x.TaskTags).HasForeignKey(x => x.TaskId);

        modelBuilder.Entity<MarketItemTagModel>().HasOne(x => x.Tag)
            .WithMany(x => x.MarketItemTag).HasForeignKey(x => x.TagId);
        modelBuilder.Entity<MarketItemTagModel>().HasOne(x => x.MarketItem)
            .WithMany(x => x.MarketItemTags).HasForeignKey(x => x.MarketItemId);
        
        
        modelBuilder.Entity<Check>().HasOne(x => x.User)
            .WithMany(x => x.Checks).HasForeignKey(x => x.UserId);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = _configuration.GetConnectionString("MainDB");
        optionsBuilder.UseNpgsql(connectionString);
    }
}