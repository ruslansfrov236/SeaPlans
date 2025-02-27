using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;
using Configuration = seaplan.data.Configuration;

namespace seaplan.business;

public static class ServiceRegistration
{
    public static void AddBusinessRegistration(this IServiceCollection services)
    {
        var redisConnection = Configuration.ConnectionStringReddis;
        services.AddSingleton<IConnectionMultiplexer>(ConnectionMultiplexer.Connect(redisConnection));


        services.AddStackExchangeRedisCache(options =>
        {
            options.Configuration = redisConnection;
            options.InstanceName = "SampleInstance";
        });
        services.AddTransient<IVerificationCodeService, VerificationCodeService>();
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<IProductImagesService, ProductImagesService>();
        services.AddScoped<IReservationServices, ReservationServices>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IAboutService, AboutService>();
        services.AddScoped<IHeaderService, HeaderService>();
        services.AddScoped<IMessageService, MessageService>();
        services.AddScoped<IRolesService, RolesService>();
        services.AddScoped<IAuthService, AuthService>();

        services.AddTransient<IFileService, FileService>();
        services.AddTransient<IEmailService, EmailService>();
        services.AddTransient<ITokenHandler, TokenHandler>();
    }
}