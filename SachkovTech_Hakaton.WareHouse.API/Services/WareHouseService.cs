using System.ComponentModel.DataAnnotations;


namespace SachkovTech_Hakaton.WareHouse.API.Services;
public class WareHouseService : IWareHouseService
{
    private readonly IWareHouseRepository _wareHouseRepository;
    public WareHouseService(IWareHouseRepository wareHouseRepository)
    {
        _wareHouseRepository = wareHouseRepository;
    }
    public async Task<IEnumerable<WareHouseDTOResponse>> GetAllAsync()
    {
        var wareHouses = await _wareHouseRepository.GetAllAsync() ?? throw new ArgumentNullException(nameof(WareHouseDTOResponse));

        var wareHousesDtoResponses = wareHouses.Select(x => new WareHouseDTOResponse(
           x.Id,
           x.Name,
           x.UniqueCode,
           x.Address,
           x.Capacity,
           x.Occupancy));

        return wareHousesDtoResponses ?? throw new ArgumentNullException(nameof(WareHouseDTOResponse));
    }
    public async Task<WareHouseDTOResponse> GetByIdAsync(int id)
    {
        var wareHouse = await _wareHouseRepository.GetByIdAsync(id) ?? throw new ArgumentNullException(nameof(WareHouseDTOResponse));

        var wareHouseDTOResponse = new WareHouseDTOResponse(
           wareHouse.Id,
           wareHouse.Name,
           wareHouse.UniqueCode,
           wareHouse.Address,
           wareHouse.Capacity,
           wareHouse.Occupancy);

        return wareHouseDTOResponse ?? throw new ArgumentNullException(nameof(WareHouseDTOResponse));
    }
    public async Task<WareHouseDTOResponse> CreateAsync(CreateWareHouseDTORequest createWareHouseDTORequest)
    {
        var wareHouses = await _wareHouseRepository.GetAllAsync();

        var wareHouseLastNumber = wareHouses.Count + 1;

        var warehouse = new Domain.Models.Entities.WareHouse()
        {
            Id = wareHouseLastNumber,
            Name = createWareHouseDTORequest.Name,
            UniqueCode = createWareHouseDTORequest.UniqueCode,
            Address = createWareHouseDTORequest.Address,
            Capacity = createWareHouseDTORequest.Capacity,
        };

        if (await _wareHouseRepository.ExistsByCodeAsync(createWareHouseDTORequest.UniqueCode))
        {
            throw new ValidationException(nameof(Domain.Models.Entities.WareHouse) + Constants.ExistsElementMessage);
        }

        await _wareHouseRepository.AddASync(warehouse);

        var wareHouseDTO = new WareHouseDTOResponse(warehouse.Id,
            warehouse.Name,
            warehouse.UniqueCode,
            warehouse.Address,
            warehouse.Capacity,
            warehouse.Occupancy);

        return wareHouseDTO;
    }
    public async Task UpdateAsync(UpdateWareHouseDTORequest wareHouseDTORequest)
    {
        var warehouse = await _wareHouseRepository.GetByIdAsync(wareHouseDTORequest.Id);

        if (warehouse is null)
            throw new InvalidDataException(nameof(Domain.Models.Entities.WareHouse) + Constants.ExistsElementMessage);

        warehouse.Name = warehouse.Name;

        await _wareHouseRepository.UpdateAsync(warehouse);
    }


    public async Task DeleteAsync(int id)
    {
        var warehouse = await _wareHouseRepository.GetByIdAsync(id);

        if (warehouse is null)
            throw new InvalidDataException(nameof(Domain.Models.Entities.WareHouse) + Constants.ExistsElementMessage);

        if (warehouse.Products.Any())
        {
            throw new InvalidOperationException("Warehouse with products");
        }

        await _wareHouseRepository.DeleteAsync(warehouse);
    }

    public async Task<decimal> CountOccupancyAsync(int id)
    {
        var warehouse = await _wareHouseRepository.GetByIdAsync(id);

        if (warehouse is null)
            throw new InvalidDataException(nameof(Domain.Models.Entities.WareHouse) + Constants.ExistsElementMessage);

        return warehouse.Occupancy;
    }
}

