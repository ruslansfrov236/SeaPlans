using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using seaplan.business.Validators.AbstractValidator;
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
        services.AddScoped<IProductImagesService, ProductImagesService>();
        services.AddScoped<IReservationServices, ReservationServices>();
        services.AddScoped<IFacilitiesService, FacilitiesService>();
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<IMessageService, MessageService>();
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IAboutService, AboutService>();
        services.AddScoped<IHeaderService, HeaderService>();
        services.AddScoped<ISliderService, SliderService>();
        services.AddScoped<IRolesService, RolesService>();
        services.AddScoped<IAuthService, AuthService>();
        services.AddTransient<IFileService, FileService>();
        services.AddTransient<IEmailService, EmailService>();
        services.AddTransient<ITokenHandler, TokenHandler>();
    }


    public static void AddValidatorRegistrationFluent(this IServiceCollection service)
    {
        // Yeni FluentValidation metodu ilə validatorları qeydiyyatdan keçirmək
        service.AddFluentValidationAutoValidation();
        service.AddFluentValidationClientsideAdapters();

// Bütün validatorları əlavə etmək üçün
        service.AddValidatorsFromAssemblyContaining<CreateProductImagesValidator>();
        service.AddValidatorsFromAssemblyContaining<CreateRegistrationValidator>();
        service.AddValidatorsFromAssemblyContaining<CreateFacilitiesValidator>();
        service.AddValidatorsFromAssemblyContaining<CreateCategoryValidator>();
        service.AddValidatorsFromAssemblyContaining<CreateMessagesValidator>();
        service.AddValidatorsFromAssemblyContaining<CreateProductsValidator>();
        service.AddValidatorsFromAssemblyContaining<CreateSliderValidator>();
        service.AddValidatorsFromAssemblyContaining<CreateHeaderValidator>();
        service.AddValidatorsFromAssemblyContaining<CreateRolesValidator>();
        service.AddValidatorsFromAssemblyContaining<CreateAboutValidator>();
        service.AddValidatorsFromAssemblyContaining<CreateLoginValidator>();
        service.AddValidatorsFromAssemblyContaining<UpdateFacilitiesValidator>();
        service.AddValidatorsFromAssemblyContaining<UpdateCategoryValidator>();
        service.AddValidatorsFromAssemblyContaining<UpdateMessagesValidator>();
        service.AddValidatorsFromAssemblyContaining<UpdateProductsValidator>();
        service.AddValidatorsFromAssemblyContaining<UpdateSliderValidator>();
        service.AddValidatorsFromAssemblyContaining<UpdateHeaderValidator>();
        service.AddValidatorsFromAssemblyContaining<UpdateRolesValidator>();
        service.AddValidatorsFromAssemblyContaining<UpdateAboutValidator>();
    }
}