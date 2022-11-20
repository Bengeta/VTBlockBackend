using Microsoft.EntityFrameworkCore;
using VTBlockBackend.Interfaces;
using VTBlockBackend.Models;
using VTBlockBackend.Models.DBTables;

namespace VTBlockBackend.Data;

public class ApplicationContext : DbContext
{
    private IConfiguration _configuration;

    public ApplicationContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public DbSet<UserModel> Users { get; set; }

    public DbSet<ImageStorage> ImageStorage { get; set; }
    public DbSet<WalletModel> Wallet { get; set; }
    public DbSet<UserStocks> UserStocks { get; set; }
    public DbSet<TransactionHistoryModel> Transaction { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserModel>().HasIndex(u => u.email).IsUnique();
        modelBuilder.Entity<UserModel>().HasIndex(u => u.token).IsUnique();


        modelBuilder.Entity<WalletModel>().HasOne(x => x.User)
            .WithMany(x => x.WalletModels).HasForeignKey(x => x.UserId);
        modelBuilder.Entity<UserStocks>().HasOne(x => x.Wallet).WithMany(x => x.UserStocks)
            .HasForeignKey(x => x.WalletId);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = _configuration.GetConnectionString("MainDB");
        optionsBuilder.UseNpgsql(connectionString);
    }
}