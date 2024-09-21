using Microsoft.EntityFrameworkCore;
using System.Runtime.ConstrainedExecution;
using Vehicles.Database;
using Vehicles.Database.Entities;


    using var dbContext = new ApplicationDbContext();


    //ha kell id
    //await AddFirstVehicleToDB();
    //await AddSecondVehicleToDB();
    //  await dbContext.Vehicles.AddAsync(opel new VehicleEntity
    //{
    //    ChassisNumber = "jjjjjjjjjjjjjjjjj",
    //    EngineNumber = "de",
    //    LicencePlate = "sajt25",
    //    NumberOfDoors = 3,
    //    Power = 140,
    //    Weight = 1500
    //}); ha nem kell id

    //adat kiolvasás
    //var vehicles = await dbContext.Vehicles.Include(x => x.Model).ThenInclude(x => x.Manufacturer).Include(x => x.Color ).ToListAsync();//gyűjteményben tárolja, tolist nélkül csak lekérdezés
    //PrintVehiclesOnConsole(vehicles);
//    var vehicle = await dbContext.Vehicles.Include(x => x.Model).ThenInclude(x => x.Manufacturer).Include(x => x.Color).FirstAsync(x => x.Id == 1);
//PrintVehicleOnConsole(vehicle);

    //rekord módosítás

    


    //rekord törlés


    // package manager consolba add-migration "init" (első lépés a szerver csináláshoz)
    // update-database szerver tényleges létrehozása


async Task AddFirstVehicleToDB()
{ 
    ManufacturerEntity mazda = new ManufacturerEntity()
    {
        Name = "MAZDA",
        FoundationYear = 1899,
        Ceo = "Béla"
    };

    await dbContext.Manufacturers.AddAsync(mazda);
    await dbContext.SaveChangesAsync();

    ModelEntity mazda2de = new ModelEntity()
    {
        ModelName = "2 DE",
        ChassisType = "sedan",
        EngineType = "v6",
        ManufacturerId = mazda.Id
    };
   
    await dbContext.Models.AddAsync(mazda2de);
    await dbContext.SaveChangesAsync();

    VehicleEntity vehicle = new VehicleEntity()
    {
           ChassisNumber = "12222222222222222",
           ColorId =1,
           EngineNumber = "22",
           LicencePlate = "sajt33",
           ModelId = 1,
           NumberOfDoors = 5,
           Power = 150,
           Weight = 1000,
           FieldOfUseId = 1
           
    };
    await dbContext.Vehicles.AddAsync(vehicle);
    await dbContext.SaveChangesAsync();
}
async Task AddSecondVehicleToDB() 
{
    VehicleEntity vehicle = new VehicleEntity()
    {
        ChassisNumber = "gazwifoeouhu44444",
        EngineNumber = "66",
        LicencePlate = "valami",
        NumberOfDoors = 5,
        Power = 270,
        Weight = 2000,
        FieldOfUseId = 2,
        Color = new ColorEntity 
        {
            Name = "piros",
            Code = "ff0000"
        },
        Model = new ModelEntity 
        {
            ModelName = "Civic 2.2",
            ChassisType = "sedan",
            EngineType = "v6",
            Manufacturer = new ManufacturerEntity
            {
                Name = "Honda",
                FoundationYear = 2012,
                Ceo = "Géza"
            }
        }

    };
    await dbContext.Vehicles.AddAsync(vehicle);
    await dbContext.SaveChangesAsync();
}
void PrintVehiclesOnConsole(ICollection<VehicleEntity> vehicles)
{
    foreach (var vehicle in vehicles)
    {
        PrintVehicleOnConsole(vehicle);
    }
}
void PrintVehicleOnConsole(VehicleEntity vehicle)
{
        Console.WriteLine($"{vehicle?.LicencePlate} " +
            $"{vehicle?.Model?.Manufacturer?.Name} " +
            $"{vehicle?.Model?.ModelName} " +
            $"({vehicle?.Color?.Name})");
}