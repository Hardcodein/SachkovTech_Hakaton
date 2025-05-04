namespace SachkovTech_Hakaton.WareHouse.Infrastructure.Data.Context;

public class WareHouseDbContext : DbContext
{
    private readonly IConfiguration _configuration;

    public DbSet<Product> Products => Set<Product>();
    public DbSet<Inventory> Inventories => Set<Inventory>();
    public DbSet<Provider> Providers => Set<Provider>();
    public DbSet<Shipment> Shipments => Set<Shipment>();
    public DbSet<ShipmentItem> ShipmentItems => Set<ShipmentItem>();
    public DbSet<Domain.Models.Entities.WareHouse> WareHouses => Set<Domain.Models.Entities.WareHouse>();

    public WareHouseDbContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var s = _configuration.GetConnectionString("LocalPostgresConnectionString");
        optionsBuilder.UseNpgsql(_configuration.GetConnectionString("LocalPostgresConnectionString"));

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(WareHouseDbContext).Assembly);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        foreach (var entry in ChangeTracker.Entries<EntityBase>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedDate = DateTime.UtcNow;
                    entry.Entity.CreatedBy = Constansts.MyName;
                    break;
                case EntityState.Modified:
                    entry.Entity.LastModificateDate = DateTime.UtcNow;
                    entry.Entity.LastModificateBy = Constansts.MyName;
                    break;

                default:
                    break;
            }
        }
        return base.SaveChangesAsync(cancellationToken);
    }
}
