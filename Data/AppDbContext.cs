using Microsoft.EntityFrameworkCore;
using practicaUno.Models;

namespace practicaUno.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    // Unique fields
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Client>()
            .HasIndex(c => c.DocNumber)
            .IsUnique();

        modelBuilder.Entity<Client>()
            .HasIndex(c => c.Email)
            .IsUnique();

        modelBuilder.Entity<Branch>()
            .HasIndex(b => b.BranchCode)
            .IsUnique();
            
        base.OnModelCreating(modelBuilder);
    }


    // To create the tables.
    public DbSet<Client> clients_tb { get; set; }
    public DbSet<Pet> pets_tb { get; set; }
    public DbSet<Branch> branches_tb { get; set; }
    public DbSet<Appointment> appointments_tb { get; set; }
    
}