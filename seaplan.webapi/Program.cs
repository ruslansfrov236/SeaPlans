using System.Text.Json.Serialization;
using FluentValidation.AspNetCore;
using seaplan.business;
using seaplan.business.Validators;
using seaplan.business.Validators.AbstractValidator;
using seaplan.data;
using seaplan.webapi.Filter;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers(options => { options.Filters.Add<ValidationFilter>(); })
    .AddFluentValidation(configuration =>
    {
        #region Create Validator

        configuration.RegisterValidatorsFromAssemblyContaining<CreateRegistrationValidator>();

        configuration.RegisterValidatorsFromAssemblyContaining<CreateCategoryValidator>();
        configuration.RegisterValidatorsFromAssemblyContaining<CreateMessagesValidator>();

        configuration.RegisterValidatorsFromAssemblyContaining<CreateProductsValidator>();
        configuration.RegisterValidatorsFromAssemblyContaining<CreateHeaderValidator>();
        configuration.RegisterValidatorsFromAssemblyContaining<CreateRolesValidator>();
        configuration.RegisterValidatorsFromAssemblyContaining<CreateAboutValidator>();
        configuration.RegisterValidatorsFromAssemblyContaining<CreateLoginValidator>();

        #endregion

        #region Update Validator

        configuration.RegisterValidatorsFromAssemblyContaining<UpdateCategoryValidator>();
        configuration.RegisterValidatorsFromAssemblyContaining<UpdateMessagesValidator>();
        configuration.RegisterValidatorsFromAssemblyContaining<UpdateProductsValidator>();
        configuration.RegisterValidatorsFromAssemblyContaining<UpdateHeaderValidator>();
        configuration.RegisterValidatorsFromAssemblyContaining<UpdateRolesValidator>();
        configuration.RegisterValidatorsFromAssemblyContaining<UpdateAboutValidator>();

        #endregion
    })
    .ConfigureApiBehaviorOptions(options => { options.SuppressModelStateInvalidFilter = true; }).AddJsonOptions(
        options =>
        {
            options.JsonSerializerOptions.DefaultIgnoreCondition =
                JsonIgnoreCondition.WhenWritingNull;
            options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
        });
builder.Services.AddDataServiceRegistration();
builder.Services.AddBusinessRegistration();

builder.Services.AddCors(options =>
{
    options.AddPolicy("corsPolicy", policy =>
    {
        policy.WithOrigins("http://localhost:4200")
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials();
    });
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles();
app.UseHttpsRedirection();
app.UseRouting();
app.UseCors("corsPolicy");
app.UseMiddleware<GlobalExceptionMiddleware>();
app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();


app.Run();