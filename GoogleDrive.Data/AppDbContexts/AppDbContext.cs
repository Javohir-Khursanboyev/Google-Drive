using GoogleDrive.Domain.Configurationss;
using GoogleDrive.Domain.Entities.Albums;
using GoogleDrive.Domain.Entities.Contents;
using GoogleDrive.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;

namespace GoogleDrive.Data.AppDbContexts;

public class AppDbContext:DbContext
{
    public DbSet<User> users { get; set; }
    public DbSet<Album> albums { get; set; }
    public DbSet<Content> contents { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(Constants.ConnectionString);
    } 
}
