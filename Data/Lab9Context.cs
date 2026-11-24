using Lab9.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab9.Data;

public class Lab9Context(DbContextOptions<Lab9Context> options) : DbContext(options)
{
    public DbSet<UniversityCampus> Campuses => Set<UniversityCampus>();
    public DbSet<Student> Students => Set<Student>();
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<Product> Products => Set<Product>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>()
            .HasOne(student => student.Campus)
            .WithMany(campus => campus.Students)
            .HasForeignKey(student => student.CampusID)
            .OnDelete(DeleteBehavior.Restrict);
        modelBuilder.Entity<Product>()
            .HasOne(product => product.Category)
            .WithMany(category => category.Products)
            .HasForeignKey(product => product.CategoryID)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
