using System.ComponentModel.DataAnnotations.Schema;

namespace Eedu.Data.Entities;

public class Translation
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    public string LanguageCode { get; set; } //iso 639-2
    public string ItemId { get; set; }
    public string ItemType { get; set; }
    public string Value { get; set; }
    public string Category { get; set; }
}
