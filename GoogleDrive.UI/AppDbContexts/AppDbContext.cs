using GoogleDrive.Models.UserModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace GoogleDrive.UI.AppDbContexts;

public class AppDbContext:DbContext
{
    DbSet<UserModel> users { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Server=dpg-cngviua0si5c73blm71g-a.oregon-postgres.render.com;Database=airportdb;" +
     "User Id=javohir03;Password=cIKLeyAx4NGBPfMujI252EpIkCSsySPq;");
    }
}
