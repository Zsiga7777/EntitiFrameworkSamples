
namespace Vehicles.Database;

public class ApplicationDbContext : DbContext
    { 
    public DbSet<VehicleEntity> Vehicles { get; set; }
    public ApplicationDbContext() : base()
    { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=VehicleDB;Trusted_Connection=True;MultipleActiveResultSets=True;TrustServerCertificate=True;");
    }


    protected override void OnModelCreating(ModelBuilder builder)
    {

        //    UNIQUE constraint beallitasa(vagy osztaly szinten index, vagy itt az alabbi koddal)
        //        builder.Entity<VehicleEntity>()
        //        .HasIndex(x => x.LicencePlate)
        //        .IsUnique();
        builder.Entity<ColorEntity>()
                .HasData(new ColorEntity
                {
                    Id = 1,
                    Name = "White",
                    Code = "ffffff"
                });
        builder.Entity<ColorEntity>()
                .HasData(new ColorEntity
                {
                    Id = 2,
                    Name = "Black",
                    Code = "000000"
                });
        builder.Entity<ManufacturerEntity>()
                .HasData(new ManufacturerEntity
                {
                    Id = 1,
                    Name = "Audi",
                    FoundationYear = 1944,
                    Ceo = "Német Béla"
                });
        builder.Entity<ModelEntity>()
                .HasData(new ModelEntity
                {
                    Id = 1,
                    ModelName = "Rs6",
                    ChassisType = "sedan",
                    EngineType = "3l-v6"
                });
    }
}

