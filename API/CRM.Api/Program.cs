using CRM.Api.Middleware;
using CRM.Application.Activities.Queries;
using CRM.Application.Activities.Validators;
using CRM.Application.Core;
using CRM.Domain;
using CRM.Persistence;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "CRM Pro API",
        Version = "v1",
        Description = "REST API for CRM Pro (activities, tenants, identity, etc.)"
    });
});

// Link with the DB
builder.Services.AddDbContext<AppDbContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
//Cross-origin requests (CORS) - allow any origin for dev/testing purposes
//CORS (Cross-Origin Resource Sharing) est un mécanisme de sécurité HTTP
// qui permet à un navigateur d'autoriser une application web sur un domaine (origine) à accéder à des ressources restreintes
// sur un autre domaine
builder.Services.AddCors();

builder.Services.AddMediatR(cfg => {    
    cfg.RegisterServicesFromAssemblyContaining<GetActivityList.Handler>();
    cfg.AddOpenBehavior(typeof(ValidationBehavior<,>));
});
builder.Services.AddAutoMapper(typeof(MappingProfiles).Assembly);
builder.Services.AddValidatorsFromAssemblyContaining<CreateActivityValidator>();

builder.Services.AddTransient<ExceptionMiddleware>();

builder.Services.AddIdentityApiEndpoints<User>(opt =>
{
    opt.User.RequireUniqueEmail = true;
})
.AddRoles<IdentityRole>()
.AddEntityFrameworkStores<AppDbContext>();


var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();


// Apply migrations + seed data (dev-friendly defaults)
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "CRM Pro API v1");
        options.RoutePrefix = "swagger";
    });

    using var scope = app.Services.CreateScope();
    var services = scope.ServiceProvider;
    try
    {
        var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();

        await db.Database.MigrateAsync();
        await new DbInitializer().SeedData(db);
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occured during migration.");
    }
}

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();


app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.MapGroup("api/Login").MapIdentityApi<User>(); // api/login


app.Run();
