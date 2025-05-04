namespace SachkovTech_Hakaton.WareHouse.Domain.Models.Entities;

public class Product : EntityBase
{
    // Поля
    public string? Name { get; set; }
    public string? Desckription { get; set; }
    public string? BarCode { get; set; }
    public decimal? Price { get; set; }
    public bool IsActive { get; set; }

    //Связи
    public virtual ICollection<WareHouse> WareHouses { get; set; } = [];
    public virtual ICollection<Inventory> InventoryHistory { get; set; } = [];
    public virtual ICollection<ShipmentItem> Items { get; set; } = [];
}
