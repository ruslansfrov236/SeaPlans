namespace seaplan.data.Context;

public class AppDbContext : IdentityDbContext<AppUser, AppRole, string>
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Header> Headers { get; set; }
    public DbSet<About> Abouts { get; set; }
    public DbSet<ProductFacilities> ProductFacilities { get; set; }
    public DbSet<AboutHeader> AboutHeaders { get; set; }
    public DbSet<PaymentDetails> PaymentDetails { get; set; }
    public DbSet<ProductImages> ProductImages { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Products> Products { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<Contact> Contacts { get; set; }
    public DbSet<Messages> Messages { get; set; }
    public DbSet<Reservation> Reservations { get; set; }
    public DbSet<ExtraServices> ExtraServices { get; set; }
    public DbSet<GeoLocation> GeoLocations { get; set; }
    public DbSet<Facilities> Facilities { get; set; }
    public DbSet<Slider> Sliders { get; set; }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var datas = ChangeTracker
            .Entries<BaseEntity>();

        foreach (var data in datas)
            _ = data.State switch
            {
                EntityState.Added => data.Entity.CreatedDate = DateTime.Now,
                EntityState.Modified => data.Entity.UpdatedDate = DateTime.Now,
                _ => DateTime.UtcNow
            };

        return await base.SaveChangesAsync(cancellationToken);
    }
}