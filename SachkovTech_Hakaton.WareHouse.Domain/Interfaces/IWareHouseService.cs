namespace SachkovTech_Hakaton.WareHouse.Domain.Interfaces;

public interface IWareHouseService
{
    Task<IEnumerable<WareHouseDTOResponse>> GetAllAsync();
    Task<WareHouseDTOResponse> GetByIdAsync(int id);
    Task<WareHouseDTOResponse> CreateAsync(CreateWareHouseDTORequest createWareHouseDTORequest);
    Task UpdateAsync(UpdateWareHouseDTORequest wareHouseDTORequest);
    Task DeleteAsync(int id);

    Task<decimal> CountOccupancyAsync(int WareHouseId);
}
