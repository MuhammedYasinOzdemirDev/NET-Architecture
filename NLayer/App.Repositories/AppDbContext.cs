using System.Reflection;
using App.Repositories.Entity;
using Microsoft.EntityFrameworkCore;

namespace App.Repositories;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options) //dotnet 8 beraber gelen ozellik
{
    public DbSet<Product> Products { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //icerisine ayri classlar configration ile yapilmali
        // modelBuilder.ApplyConfiguration(new ProductConfiguration());// bu product tarafi icin olur ama bunun yerine
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly
            .GetExecutingAssembly()); //Bu kod mevcut calisan repository dizininde yer alan tum configrasyonlari yukler
        base.OnModelCreating(modelBuilder);
    }
}