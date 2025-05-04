namespace SachkovTech_Hakaton.WareHouse.Domain.Models.Entities;

// Склад

public class WareHouse : EntityBase
{
    // Поля
    public string? Name { get; set; }
    public string? UniqueCode { get; set; }
    public bool IsActive { get; set; } = true;
    public string? Address { get; set; }
    public decimal Capacity { get; set; }
    public decimal Occupancy { get; set; }

    //Связи
    public virtual ICollection<Product> Products { get; set; } = [];
    public virtual ICollection<Inventory> Inventories { get; set; } = [];
    public virtual ICollection<Shipment> Shipments { get; set; } = [];
}
