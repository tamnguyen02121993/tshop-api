using FluentValidation;
using MediatR;
using System.Reflection;
using System.Text.Json.Serialization;
using TShop.Api.Behaviors;
using TShop.Api.EF;
using TShop.Api.Mappings;
using TShop.Api.Repositories;
using TShop.Api.Services.Categories;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddCors(options =>
    {
        options.AddPolicy("corsPolicy", (policy) =>
        {
            policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
        });
    });

    // Add services to the container.
    builder.Services.AddControllers()
                    .AddJsonOptions(options =>
                    {
                        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                    });
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    builder.Services.AddNpgsql<TShopDbContext>(builder.Configuration.GetConnectionString(TShopDbContext.ConnectionStringSection));

    builder.Services.AddMediatR(typeof(Program));
    builder.Services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
    builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

    builder.Services.AddMapping();
    builder.Services.AddRepositories();

    builder.Services.AddScoped<ICategoryService, CategoryService>();
    
}


var app = builder.Build();
{
    app.UseExceptionHandler("/error");
    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    //app.UseHttpsRedirection();

    app.UseCors("corsPolicy");

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}