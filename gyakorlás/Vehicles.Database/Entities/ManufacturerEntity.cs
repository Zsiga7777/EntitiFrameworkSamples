namespace Vehicles.Database.Entities;

[Table("Manufacturer")] //tábla név
[Index(nameof(Name), IsUnique = true)]
public class ManufacturerEntity
{
    [Key]//elsődleges kulcs
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]//autoincrement
    public uint Id { get; set; }

    [Required]
    [StringLength(30)]
    public string Name { get; set; }

    [Required]
    public uint FoundationYear { get; set; }

    [Required]
    [StringLength(60)]
    public string Ceo { get; set; }

    public virtual IReadOnlyCollection<ModelEntity> Models { get; set; }
}
