namespace SachkovTech_Hakaton.WareHouse.Domain.Models.Entities.Items;

public  class ShipmentItem : EntityBase
{
    public int ShipmentId { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public int BatchNumber { get; set; }

    public virtual Shipment? Shipment { get; set; }
    public virtual Product? Product { get; set; }


}
