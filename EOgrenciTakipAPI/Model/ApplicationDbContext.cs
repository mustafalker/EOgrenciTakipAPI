using EOgrenciTakipAPI.Model;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public DbSet<Alan> Alanlar { get; set; }
    public DbSet<Ogrenci> Ogrenciler { get; set; }
    public DbSet<DersProgrami> DersProgramlari { get; set; }
    public DbSet<KonuBilgisi> KonuBilgileri { get; set; }
    public DbSet<DersBilgisi> DersBilgileri { get; set; }
    public DbSet<MufredatDersler> MufredatDersler { get; set; }
    public DbSet<MufredatKonular> MufredatKonular { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // DersBilgisi ilişkileri
        modelBuilder.Entity<DersBilgisi>()
            .HasKey(db => new { db.DersProgramiID, db.KonuBilgisiID });

        modelBuilder.Entity<DersBilgisi>()
            .HasOne(db => db.DersProgrami)
            .WithMany(dp => dp.DersBilgileri)
            .HasForeignKey(db => db.DersProgramiID)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<DersBilgisi>()
            .HasOne(db => db.KonuBilgisi)
            .WithMany(kb => kb.DersBilgileri)
            .HasForeignKey(db => db.KonuBilgisiID)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<MufredatDersler>()
            .HasKey(md => md.MufredatDersId);
    }
}
