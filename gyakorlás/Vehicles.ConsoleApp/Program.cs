using Microsoft.EntityFrameworkCore;
using Vehicles.Database;
using Vehicles.Database.Entities;

using var dbContext = new ApplicationDbContext();

var opel = new VehicleEntity
{
    ChassisNumber = "jjjjjjjjjjjjjjjjj",
    EngineNumber = "de",
    LicencePlate = "hgh123",
    NumberOfDoors = 3,
    Power = 140,
    Weight = 1500,
    ColorId = 2,
    ManufacturerId = 1,
    ModelId = 1
};
//ha kell id
await dbContext.Vehicles.AddAsync(opel);
await dbContext.SaveChangesAsync();
Console.WriteLine("Done");

//  await dbContext.Vehicles.AddAsync(opel new VehicleEntity
//{
//    ChassisNumber = "jjjjjjjjjjjjjjjjj",
//    EngineNumber = "de",
//    LicencePlate = "sajt25",
//    NumberOfDoors = 3,
//    Power = 140,
//    Weight = 1500
//}); ha nem kell id

//rekord módosítás
//var vehicle = await dbContext.Vehicles.FindAsync((uint)1);
//vehicle.ChassisNumber = "asdfghjkléáűíyx12";
//await dbContext.SaveChangesAsync();

//adat kiolvasás
var vehicles = await dbContext.Vehicles.Include(x => x.Color)
                                       .ToListAsync();
    PrintVehiclesOnConsole(vehicles);

//rekord törlés
//var vehicle = await dbContext.Vehicles.FindAsync((uint)1);
//dbContext.Vehicles.Remove(vehicle);
//await dbContext.SaveChangesAsync();

// package manager consolba add-migration "init" (első lépés a szerver csináláshoz)
// update-database szerver tényleges létrehozása

void PrintVehiclesOnConsole(ICollection<VehicleEntity> vehicles)
{
    foreach (var vehicle in vehicles)
    {
        Console.WriteLine($"{vehicle.LicencePlate} ({vehicle.Color.Name})");
    }
}