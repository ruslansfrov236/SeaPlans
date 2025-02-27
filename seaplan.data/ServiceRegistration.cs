namespace seaplan.data;

public static class ServiceRegistration
{
    public static void AddDataServiceRegistration(this IServiceCollection services)
    {
        services.AddDbContext<AppDbContext>(option => { option.UseSqlServer(Configuration.ConnectionString); });


        services.AddIdentity<AppUser, AppRole>(options =>
            {
                options.Password.RequiredLength = 5;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireDigit = false;
            }).AddEntityFrameworkStores<AppDbContext>()
            .AddDefaultTokenProviders();


        services.AddScoped<IProductFacilitiesWriteRepository, ProductFacilitiesWriteRepository>();
        services.AddScoped<IProductFacilitiesReadRepository, ProductFacilitiesReadRepository>();
        services.AddScoped<IAboutHeaderReadRepository, AboutHeaderReadRepository>();
        services.AddScoped<IAboutHeaderWriteRepository, AboutHeaderWriteRepository>();
        services.AddScoped<IGeoLocationWriteRepository, GeoLocationWriteRepository>();
        services.AddScoped<IGeoLocationReadRepository, GeoLocationReadRepository>();
        services.AddScoped<IProductImagesReadRepository, ProductImagesReadRepository>();
        services.AddScoped<IProductImagesWriteRepository, ProductImagesWriteRepository>();
        services.AddScoped<IPaymentDetailsReadRepository, PaymentDetailsReadRepository>();
        services.AddScoped<IPaymentDetailsWriteRepository, PaymentDetailsWriteRepository>();
        services.AddScoped<IReservationReadRepository, ReservationReadRepository>();
        services.AddScoped<IReservationWriteRepository, ReservationWriteRepository>();
        services.AddScoped<IOrderItemReadRepository, OrderItemReadRepository>();
        services.AddScoped<IExtraServiceReadRepository, ExtraServicesReadRepository>();
        services.AddScoped<IExtraServiceWriteRepository, ExtraServicesWriteRepository>();
        services.AddScoped<IOrderItemWriteRepository, OrderItemWriteRepository>();
        services.AddScoped<ISliderReadRepository, SliderReadRepository>();
        services.AddScoped<ISliderWriteRepository, SliderWriteRepository>();
        services.AddScoped<IHeaderReadRepository, HeaderReadRepository>();
        services.AddScoped<IHeaderWriteRepository, HeaderWriteRepository>();
        services.AddScoped<IContactReadRepository, ContactReadRepository>();
        services.AddScoped<IContactWriteRepository, ContactWriteRepository>();
        services.AddScoped<IOrderReadRepository, OrderReadRepository>();
        services.AddScoped<IOrderWriteRepository, OrderWriteRepository>();

        services.AddScoped<IProductReadRepository, ProductReadRepository>();
        services.AddScoped<IProductWriteRepository, ProductWriteRepository>();
        services.AddScoped<IPaymentReadRepository, PaymentReadRepository>();
        services.AddScoped<IPaymentWriteRepository, PaymentWriteRepository>();
        services.AddScoped<IFacilitiesReadRepository, FacilitiesReadRepository>();
        services.AddScoped<IFacilitiesWriteRepository, FacilitiesWriteRepository>();
        services.AddScoped<IAboutReadRepository, AboutReadRepository>();
        services
            .AddScoped<IAboutWriteRepository,
                AboutWriteRepository>(); // services.AddScoped<IProductFacilitiesWriteRepository, ProductFacilitiesWriteRepository>();
        services.AddScoped<IProductFacilitiesReadRepository, ProductFacilitiesReadRepository>();
        services.AddScoped<IAboutHeaderReadRepository, AboutHeaderReadRepository>();
        services.AddScoped<IAboutHeaderWriteRepository, AboutHeaderWriteRepository>();
        services.AddScoped<IGeoLocationWriteRepository, GeoLocationWriteRepository>();
        services.AddScoped<IGeoLocationReadRepository, GeoLocationReadRepository>();
        services.AddScoped<IProductImagesReadRepository, ProductImagesReadRepository>();
        services.AddScoped<IProductImagesWriteRepository, ProductImagesWriteRepository>();
        services.AddScoped<IPaymentDetailsReadRepository, PaymentDetailsReadRepository>();
        services.AddScoped<IPaymentDetailsWriteRepository, PaymentDetailsWriteRepository>();
        services.AddScoped<IReservationReadRepository, ReservationReadRepository>();
        services.AddScoped<IReservationWriteRepository, ReservationWriteRepository>();
        services.AddScoped<IOrderItemReadRepository, OrderItemReadRepository>();
        services.AddScoped<IExtraServiceReadRepository, ExtraServicesReadRepository>();
        services.AddScoped<IExtraServiceWriteRepository, ExtraServicesWriteRepository>();
        services.AddScoped<IOrderItemWriteRepository, OrderItemWriteRepository>();
        services.AddScoped<ISliderReadRepository, SliderReadRepository>();
        services.AddScoped<ISliderWriteRepository, SliderWriteRepository>();
        services.AddScoped<IHeaderReadRepository, HeaderReadRepository>();
        services.AddScoped<IHeaderWriteRepository, HeaderWriteRepository>();
        services.AddScoped<IContactReadRepository, ContactReadRepository>();
        services.AddScoped<IContactWriteRepository, ContactWriteRepository>();
        services.AddScoped<IOrderReadRepository, OrderReadRepository>();
        services.AddScoped<IOrderWriteRepository, OrderWriteRepository>();

        services.AddScoped<IProductReadRepository, ProductReadRepository>();
        services.AddScoped<IProductWriteRepository, ProductWriteRepository>();
        services.AddScoped<IPaymentReadRepository, PaymentReadRepository>();
        services.AddScoped<IPaymentWriteRepository, PaymentWriteRepository>();
        services.AddScoped<IFacilitiesReadRepository, FacilitiesReadRepository>();
        services.AddScoped<IFacilitiesWriteRepository, FacilitiesWriteRepository>();
        services.AddScoped<IAboutReadRepository, AboutReadRepository>();
        services.AddScoped<IAboutWriteRepository, AboutWriteRepository>();

        services.AddScoped<ICategoryReadRepository, CategoryReadRepository>();
        services.AddScoped<ICategoryWriteRepository, CategoryWriteRepository>();
    }
}