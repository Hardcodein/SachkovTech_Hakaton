namespace SachkovTech_Hakaton.WareHouse.Application.Contracts.Persistence;

public interface IWareHouseRepository : IRepositoryBase<Domain.Models.Entities.WareHouse>
{
    Task<bool> ExistsByCodeAsync(string UniqueCode);
}
