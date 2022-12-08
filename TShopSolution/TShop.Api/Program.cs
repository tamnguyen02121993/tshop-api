using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text;
using System.Text.Json.Serialization;
using TShop.Api.Behaviors;
using TShop.Api.EF;
using TShop.Api.Mappings;
using TShop.Api.Models;
using TShop.Api.Repositories;
using TShop.Api.Services;
using TShop.Api.Services.Authentication;

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
    builder.Services.AddSwaggerGen(options =>
    {
        //options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        //{
        //    In = ParameterLocation.Header,
        //    Scheme = JwtBearerDefaults.AuthenticationScheme,
        //    Flows = new OpenApiOAuthFlow
        //    {
        //        TokenUrl = 'http://localhost:5087/'
        //    },
            
        //});
    });

    var jwtConfig = new JwtConfig();
    builder.Configuration.Bind(JwtConfig.JWT_SECTION, jwtConfig);
    builder.Services.AddSingleton(Options.Create(jwtConfig));

    builder.Services.AddNpgsql<TShopDbContext>(builder.Configuration.GetConnectionString(TShopDbContext.ConnectionStringSection));
    builder.Services.AddIdentity<ApplicationUser, ApplicationRole>()
                    .AddEntityFrameworkStores<TShopDbContext>()
                    .AddDefaultTokenProviders();

    builder.Services.AddAuthentication(options =>
                    {
                        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                    })
                    .AddJwtBearer(options =>
                    {
                        options.RequireHttpsMetadata = false;
                        options.TokenValidationParameters = new TokenValidationParameters()
                        {
                            ValidateIssuer = true,
                            ValidateAudience = true,
                            ValidateLifetime = true,
                            ValidateIssuerSigningKey = true,
                            ValidIssuer = jwtConfig.Issuer,
                            ValidAudience = jwtConfig.Audience,
                            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfig.Key))
                        };
                    });

    builder.Services.AddMediatR(typeof(Program));
    builder.Services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
    builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

    builder.Services.AddMapping();
    builder.Services.AddRepositories();
    builder.Services.AddServices();
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

    app.UseAuthentication();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}