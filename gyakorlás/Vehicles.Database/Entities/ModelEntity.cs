namespace Vehicles.Database.Entities;

[Table("Model")] //tábla név
[Index(nameof(ModelName), IsUnique = true)]
public class ModelEntity
{
    [Key]//elsődleges kulcs
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]//autoincrement
    public uint Id { get; set; }

    [Required]
    [StringLength(14)]
    public string ModelName { get; set; }

    [Required]
    [StringLength(17)]
    public string ChassisType { get; set; }

    [Required]
    [StringLength(20)]
    public string EngineType { get; set; }

    public virtual IReadOnlyCollection<VehicleEntity> Vehicles { get; set; }

    [ForeignKey("Manufacturer")]
    public uint ManufacturerId { get; set; }
    public virtual ManufacturerEntity Manufacturer { get; set; }
}
