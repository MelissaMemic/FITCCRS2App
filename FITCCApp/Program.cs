using AutoMapper;
using FITCCApp.Filters;
using FITCCRS2App.Models.SearchObjects;
using FITCCRS2App.Services.Database;
using FITCCRS2App.Services.Services.AgendaService;
using FITCCRS2App.Services.Services.BaseServices;
using FITCCRS2App.Services.Services.TakmicenjeService;
using FITCCApp.Extensions;
using Microsoft.EntityFrameworkCore;
using FITCCRS2App.Services.Services.UserService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAutoMapper(typeof(IAgendaService));

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<FITCCRS2v2Context>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddMemoryCache();


builder.Services.AddTransient<IService<FITCCRS2App.Models.Models.Takmicenje, BaseSearchObject>, BaseService<FITCCRS2App.Models.Models.Takmicenje
    , Takmicenje, BaseSearchObject>>();
builder.Services.AddTransient<ITakmicenjeService, TakmicenjeService>();
builder.Services.AddTransient<IAgendaService, AgendaService>();
builder.Services.AddTransient<IUserService, UserService>();

//builder.Services.AddScopedServices();
builder.Services.AddAuthentication(builder.Configuration);

builder.Services.AddControllers(x =>
{
    x.Filters.Add<ErrorFilter>();
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwaggerUI();

app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var dataContext = scope.ServiceProvider.GetRequiredService<FITCCRS2v2Context>();
    dataContext.Database.Migrate();
}

app.Run();

