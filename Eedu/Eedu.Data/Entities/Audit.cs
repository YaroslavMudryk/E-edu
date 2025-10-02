using System.ComponentModel.DataAnnotations.Schema;

namespace Eedu.Data.Entities;

public class Audit
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public string CreatedBy { get; set; }
    public string ActionName { get; set; }
    public string ItemId { get; set; }
    public string ItemType { get; set; }
    public string TransactionId { get; set; }
    public ICollection<PropertyItem> Changes { get; set; } = [];
}

public class PropertyItem(string name, string oldValue, string newValue)
{
    public string Name { get; set; } = name;
    public string OldValue { get; set; } = oldValue;
    public string NewValue { get; set; } = newValue;

    public bool IsChanged => OldValue != NewValue;
}

public class ActionConstants
{
    public const string Create = nameof(Create);
    public const string Update = nameof(Update);
    public const string SoftDelete = nameof(SoftDelete);
    public const string Delete = nameof(Delete);
}
