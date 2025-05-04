namespace SachkovTech_Hakaton.WareHouse.Domain.Models.Entities;

public class Inventory : EntityBase
{
    public int Quantity { get; set; }
    public string? BatchNumber { get; set; }
    public DateTime BestbeforeDate { get; set; }
    public int WareHouseId { get; set; }
    public int ProductId { get; set; }
    public virtual Product? Product { get; set; }
    public virtual WareHouse? WareHouse { get; set; }

}