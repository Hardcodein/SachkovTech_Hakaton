namespace SachkovTech_Hakaton.WareHouse.Infrastructure.Repository;

public class WareHousesRepository : RepositoryBase<Domain.Models.Entities.WareHouse>, IWareHouseRepository
{
    public WareHousesRepository(WareHouseDbContext wareHouseDbContext) : base(wareHouseDbContext)
    {
        
    }

    public async Task<bool> ExistsByCodeAsync(string UniqueCode)
    {
        if (string.IsNullOrEmpty(UniqueCode))
            throw new ArgumentNullException(nameof(UniqueCode));


        var result = await _dbContext.Set<Domain.Models.Entities.WareHouse>()
            .AnyAsync(x => x.UniqueCode == UniqueCode);

        return result;
    }
}
