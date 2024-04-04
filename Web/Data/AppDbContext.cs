using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NpgsqlTypes;
using Microsoft.EntityFrameworkCore;

namespace Web.Data;

[Table("Restaurants")]
public class Resto
{
    [Key]
    public int Id { get; set; }

    [Column(TypeName = "varchar(255)")]
    public string Category { get; set; }

    [Column(TypeName = "varchar(255)")]
    public string Name { get; set; }

    [Column(TypeName = "varchar(255)")]
    public string? Address { get; set; }

    public bool HalalCertification { get; set; }

    [Column(TypeName = "varchar(50)")]
    public string? HalalCertificationNumber { get; set; }

    public DateTime? CertificationValidity { get; set; }

    public bool? HalalClaim { get; set; }

    [Column(TypeName = "text")]
    public string? HalalClaimDetails { get; set; }

    public NpgsqlTsVector? SearchVector { get; set; }

    public string Status { get; set; }

    public Logic.Resto ToDomainResto()
    {
        string validUntil =  CertificationValidity?.ToShortDateString() ?? string.Empty;
        return new Logic.Resto(Status,Name,Address,HalalClaimDetails, validUntil,Category);
    }
}

public partial class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    // Define your DbSets (tables)
    public DbSet<Resto> Restos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Resto>()
            .HasGeneratedTsVectorColumn(
                p => p.SearchVector,
                "simple",  // Text search config
                p => new
                {
                    p.Name,
                    p.Address,
                    p.Category,
                    p.HalalClaimDetails,
                    p.HalalCertificationNumber
                })  // Included properties
            .HasIndex(p => p.SearchVector)
            .HasMethod("GIN"); // Index method on the search vector (GIN or GIST)
    }
}


