namespace SachkovTech_Hakaton.WareHouse.Domain.Models.Entities;

public  class Provider : EntityBase
{
    public string? Name { get; set; }
    public string? Member { get; set; }
    public string? Phone { get; set; }

    public virtual ICollection<Product> Products { get; set; } = [];
}
