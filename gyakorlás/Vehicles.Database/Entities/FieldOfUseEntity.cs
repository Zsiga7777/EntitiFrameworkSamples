namespace Vehicles.Database.Entities;

[Table("FieldOfUse")]
[Index(nameof(Name), IsUnique = true)]
public class FieldOfUseEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public uint Id { get; set; }
    [Required]
    [StringLength(30)]
    public string Name { get; set; }

    public virtual IReadOnlyCollection<VehicleEntity> Vehicles { get; set; }
}
