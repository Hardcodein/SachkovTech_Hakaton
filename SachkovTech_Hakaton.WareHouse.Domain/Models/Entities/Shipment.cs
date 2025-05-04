
namespace SachkovTech_Hakaton.WareHouse.Domain.Models.Entities;

public  class Shipment : EntityBase
{
    public string? TrackingNumber { get; set; }
    public string? Transporter { get; set; }
    public DateTime DeliveryDate { get; set; }
    public ShipmentStatus ShipmentStatus { get; set; }  = ShipmentStatus.Preparing;
    public int WareHouseId { get; set; }

    public virtual WareHouse? WareHouse { get; set; }

    public virtual ICollection<ShipmentItem> Items { get; set; } = [];
}
