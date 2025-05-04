namespace SachkovTech_Hakaton.WareHouse.Domain.Common;

public abstract class EntityBase
{
    public int Id { get;  set; }
    public string? CreatedBy { get; set; }
    public string? LastModificateBy { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime LastModificateDate { get; set; }

}
