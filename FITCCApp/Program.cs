﻿using AutoMapper;
using FITCCApp.Filters;
using FITCCRS2App.Models.SearchObjects;
using FITCCRS2App.Services.Database;
using FITCCRS2App.Services.Services.AgendaService;
using FITCCRS2App.Services.Services.BaseServices;
using FITCCRS2App.Services.Services.TakmicenjeService;
using FITCCApp.Extensions;
using Microsoft.EntityFrameworkCore;
using FITCCRS2App.Services.Services.UserService;
using Serilog;
using FITCCRS2App.Services;
using FITCCRS2App.Services.Services.KriterijService;
using FITCCRS2App.Services.Services.KomisijaService;
using FITCCRS2App.Services.Services.KategorijaService;
using FITCCRS2App.Services.Services.ProjekatService;
using FITCCRS2App.Services.Services.RezultatService;
using FITCCRS2App.Services.Services.DogadjajService;
using FITCCRS2App.Services.Services.TimService;
using FITCCRS2App.Services.Services.SponzorService;
using FITCCRS2App.Services.Services.RabbitMQ;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<IService<FITCCRS2App.Models.Models.Takmicenje, BaseSearchObject>, BaseService<FITCCRS2App.Models.Models.Takmicenje
   , Takmicenje, BaseSearchObject>>();
builder.Services.AddTransient<ITakmicenjeService, TakmicenjeService>();
builder.Services.AddTransient<IAgendaService, AgendaService>();
builder.Services.AddTransient<IKriterijService, KriterijService>();
builder.Services.AddTransient<IKomisijaService, KomisijaService>();
builder.Services.AddTransient<IKategorijaService, KategorijaService>();
builder.Services.AddTransient<IProjekatService, ProjekatService>();
builder.Services.AddTransient<IRezultatService, RezultatService>();
builder.Services.AddTransient<IDogadjajService, DogadjajService>();
builder.Services.AddTransient<ISponzorService, SponzorService>();
builder.Services.AddTransient<ITimService, TimService>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddScoped<IRabbitMQProducer, RabbitMQProducer>();


builder.Services.AddControllers(x =>
{
    x.Filters.Add<ErrorFilter>();
});


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(MappingProfile));

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<FITCCRS2v2Context>(options =>
   options.UseSqlServer(connectionString));




Log.Logger = new LoggerConfiguration()
           .ReadFrom
           .Configuration(builder.Configuration)
           .CreateLogger();

builder.Host.UseSerilog();

builder.Services.AddMemoryCache();

builder.Services.AddAuthentication(builder.Configuration);

//builder.Services.Configure<ApiBehaviorOptions>(options => options.SuppressModelStateInvalidFilter = true);

var app = builder.Build();

app.UseSwaggerUI();
app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseAuthentication();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var dataContext = scope.ServiceProvider.GetRequiredService<FITCCRS2v2Context>();
    var conn = dataContext.Database.GetConnectionString();
    await dataContext.Database.MigrateAsync();
    dataContext.Database.EnsureCreated();

}

app.Run();