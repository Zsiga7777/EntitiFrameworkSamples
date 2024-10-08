﻿
namespace Vehicles.Database;

public class ApplicationDbContext : DbContext
    { 
    public DbSet<ManufacturerEntity> Manufacturers {  get; set; }

    public DbSet<ModelEntity> Models { get; set; }
    public DbSet<VehicleEntity> Vehicles { get; set; }
    public DbSet<ColorEntity> Colors { get; set; }
    public DbSet<OwnerEntity> Owners { get; set; }
    public DbSet<StreetEntity> Streets { get; set; }
    public DbSet<CityEntity> Cities { get; set; }

    public DbSet<FieldOfUseEntity> FieldOfUses { get; set; }
    public DbSet<TypeEntity> Types { get; set; }
    public ApplicationDbContext() : base()
    { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=VehicleDB;Trusted_Connection=True;MultipleActiveResultSets=True;TrustServerCertificate=True;");
        //.LogTo(Console.WriteLine);
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
        builder.Entity<FieldOfUseEntity>()
                    .HasData(new FieldOfUseEntity
                    {
                        Id = 1,
                        Name = "Normal"
                    });
        builder.Entity<FieldOfUseEntity>()
                    .HasData(new FieldOfUseEntity
                    {
                        Id = 2,
                        Name = "Taxi"
                    });
        builder.Entity<FieldOfUseEntity>()
                    .HasData(new FieldOfUseEntity
                    {
                        Id = 3,
                        Name = "Freight transport"
                    });

        builder.Entity<TypeEntity>().HasData(
            new TypeEntity { Id = 1, Name = "Car" },
            new TypeEntity { Id = 2, Name = "Truck" },
            new TypeEntity { Id = 3, Name = "Bus" },
            new TypeEntity { Id = 4, Name = "Motorcycle" }
            );

    }
}

