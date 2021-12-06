using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data;

public class MovieShopDbContext:DbContext
{
    public MovieShopDbContext(DbContextOptions<MovieShopDbContext> options): base(options)
    {
        
    }

    public DbSet<Genre> Genres { get; set; }
    public DbSet<Movie> Movies { get; set; }
    public DbSet<Cast> Cast { get; set; }
    public DbSet<Crew> Crew { get; set; }
    public DbSet<Favorite> Favorite { get; set; }
    public DbSet<Purchase> Purchase { get; set; }
    public DbSet<User> User { get; set; }
    public DbSet<MovieCast> MovieCasts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Movie>(ConfigureMovie);
        modelBuilder.Entity<Trailer>(ConfigureTrailer);
        modelBuilder.Entity<Cast>(ConfigureCast);
        modelBuilder.Entity<Crew>(ConfigureCrew);
        modelBuilder.Entity<Favorite>(ConfigureFavorite);
        modelBuilder.Entity<Purchase>(ConfigurePurchase);
        modelBuilder.Entity<User>(ConfigureUser);
        modelBuilder.Entity<Role>(ConfigureRole);
        modelBuilder.Entity<MovieCast>(ConfigureMovieCast);
    }

    private void ConfigureTrailer(EntityTypeBuilder<Trailer> builder)
    {
        builder.ToTable("Trailer");
        builder.HasKey(t => t.Id);
        builder.Property(t => t.TrailerUrl).HasMaxLength(2084);
        builder.Property(t => t.Name).HasMaxLength(2084);
    }

    private void ConfigureMovie(EntityTypeBuilder<Movie> builder)
    {
        builder.ToTable("Movie");
        builder.HasKey(m => m.Id);
        builder.Property(m => m.Title).HasMaxLength(256);
        builder.Property(m => m.Overview).HasMaxLength(4096);
        builder.Property(m => m.Tagline).HasMaxLength(512);
        builder.Property(m => m.ImdbUrl).HasMaxLength(2084);
        builder.Property(m => m.TmdbUrl).HasMaxLength(2084);
        builder.Property(m => m.PosterUrl).HasMaxLength(2084);
        builder.Property(m => m.BackdropUrl).HasMaxLength(2084);
        builder.Property(m => m.OriginalLanguage).HasMaxLength(64);
        builder.Property(m => m.Price).HasColumnType("decimal(5, 2)").HasDefaultValue(9.9m);
        builder.Property(m => m.Budget).HasColumnType("decimal(18, 4)").HasDefaultValue(9.9m);
        builder.Property(m => m.Revenue).HasColumnType("decimal(18, 4)").HasDefaultValue(9.9m);
        builder.Property(m => m.CreatedDate).HasDefaultValueSql("getdate()");
    }
    private void ConfigureCast(EntityTypeBuilder<Cast> builder)
    {
        builder.ToTable("Cast");
        builder.HasKey(t => t.Id);
        builder.Property(t => t.Name).HasMaxLength(2084);
        builder.Property(t => t.Gender).HasMaxLength(4096);
        builder.Property(t => t.TmdbUrl).HasMaxLength(4096);
        builder.Property(t => t.ProfilePath).HasMaxLength(2084);
    }

    private void ConfigureCrew(EntityTypeBuilder<Crew> builder)
    {
        builder.ToTable("Crew");
        builder.HasKey(t => t.Id);
        builder.Property(t => t.Name).HasMaxLength(2084);
        builder.Property(t => t.Gender).HasMaxLength(4096);
        builder.Property(t => t.TmdbUrl).HasMaxLength(4096);
        builder.Property(t => t.ProfilePath).HasMaxLength(2084);
    }

    private void ConfigureFavorite(EntityTypeBuilder<Favorite> builder)
    {
        builder.ToTable("Favorite");
        builder.HasKey(t => t.Id);
        builder.Property(t => t.MovieId);
        builder.Property(t => t.UserId);
        
    }

    private void ConfigurePurchase(EntityTypeBuilder<Purchase> builder)
    {
        builder.ToTable("Purchase");
        builder.HasKey(t => t.Id);
        builder.Property(t => t.UserId);
        builder.Property(t => t.PurchaseNumber);
        builder.Property(t => t.TotalPrice).HasColumnType("decimal(18, 2)").HasDefaultValue(9.9m); 
        builder.Property(t => t.PurchaseDateTime).HasDefaultValueSql("getdate()");
        builder.Property(t=>t.MovieId);
    }
    private void ConfigureUser(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("User");
        builder.HasKey(t => t.Id);
        builder.Property(t => t.FirstName).HasMaxLength(128);
        builder.Property(t => t.LastName).HasMaxLength(128);
        builder.Property(t => t.DateOfBirth).HasDefaultValueSql("getdate()");
        builder.Property(t => t.Email).HasMaxLength(256);
        builder.Property(t => t.HashedPassword).HasMaxLength(1024);
        builder.Property(t => t.Salt).HasMaxLength(1024);
        builder.Property(t => t.PhoneNumber).HasMaxLength(16);
        builder.Property(t => t.TwoFactorEnabled);
        builder.Property(t => t.LockoutEndDate).HasDefaultValueSql("getdate()");
        builder.Property(t => t.LastLoginDateTime).HasDefaultValueSql("getdate()");
        builder.Property(t => t.IsLocked);
        builder.Property(t => t.AccessFailedCount);
    }
    private void ConfigureRole(EntityTypeBuilder<Role> builder)
    {
        builder.ToTable("Role");
        builder.HasKey(t => t.Id);
        builder.Property(t => t.Name);

    }
    private void ConfigureMovieCast(EntityTypeBuilder<MovieCast> builder)
    {
        builder.ToTable("MovieCast");
        builder.HasKey(t => t.MovieId);
        builder.HasKey(t => t.CastId);
        builder.HasKey(t => t.Character);

    }
}