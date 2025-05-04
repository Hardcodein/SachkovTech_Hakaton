namespace SachkovTech_Hakaton.WareHouse.Domain.DTOs.Requests.WareHouse;

public record CreateWareHouseDTORequest(string Name, string UniqueCode, string Address, decimal Capacity);
