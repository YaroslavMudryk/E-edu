namespace Eedu.Data.Entities.Identity;

public class App : VersionableBaseModel<int>
{
    public string Name { get; set; }
    public string ShortName { get; set; }
    public string Description { get; set; }
    public string Image { get; set; }
    public string ClientId { get; set; } // should be generated on backend side
    public bool ClientSecretRequired { get; set; }
    public bool IsActive { get; set; }
    public DateTime ActiveFrom { set; get; }
    public DateTime? ActiveTo { set; get; }
    public string[] RedirectUris { get; set; } = ["*"];
    public List<ClientPermission> ClientClaims { get; set; } = [];
}
