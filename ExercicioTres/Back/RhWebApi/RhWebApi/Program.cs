using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using RhWebApi.Config;
using RhWebApi.Repositories;
using RhWebApi.Services;
using AutoMapper;

Configure(args);
static void Configure(string[] args)
{
    var builder = WebApplication.CreateBuilder(args);

    builder.Services.AddControllers();
    builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseInMemoryDatabase("RHDB"));
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "RHWebApi", Version = "v1" });
    });
    builder.Services.AddAutoMapper(cfg =>
    {
        cfg.AllowNullCollections = true;
        cfg.AllowNullDestinationValues = true;
    }, typeof(MappingProfile));
    builder.Services.AddCors(options =>
    {
        options.AddPolicy("AllowSpecificOrigin",
            builder => builder.WithOrigins("http://localhost:4200")
                              .AllowAnyHeader()
                              .AllowAnyMethod());
    });

    InjectionRepository(builder);

    InjectionServices(builder);

    var app = builder.Build();

    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "RHWebApi v1");
        });
    }

    app.UseHttpsRedirection();
    app.UseCors("AllowSpecificOrigin");
    app.UseAuthorization();
    app.MapControllers();

    using (var scope = app.Services.CreateScope())
    {
        var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        dbContext.Database.EnsureCreated();
    }

    app.Run();
}
static void InjectionRepository(WebApplicationBuilder builder)
{
    builder.Services.AddScoped<ICandidateRepository, CandidateRepository>();
    builder.Services.AddScoped<ICandidateTechnologyRepository, CandidateTechnologyRepository>();
    builder.Services.AddScoped<ITechnologyRepository, TechnologyRepository>();
    builder.Services.AddScoped<IVacancyRepository, VacancyRepository>();
    builder.Services.AddScoped<IVacancyTechnologyValueRepository, VacancyTechnologyValueRepository>();
}

static void InjectionServices(WebApplicationBuilder builder)
{
    builder.Services.AddScoped<ICandidateService, CandidateService>();
    builder.Services.AddScoped<ICandidateTechnologyService, CandidateTechnologyService>();
    builder.Services.AddScoped<ITechnologyService, TechnologyService>();
    builder.Services.AddScoped<IVacancyService, VacancyService>();
    builder.Services.AddScoped<IVacancyTechnologyValueService, VacancyTechnologyValueService>();
    builder.Services.AddScoped<IFinalReport, FinalReport>();
}


