namespace Eedu.Data.Entities.Structure;

public class University : VersionableBaseModel<Guid>
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string EdboId { get; set; }
    public ICollection<Faculty> Faculties { get; set; } = [];
}
