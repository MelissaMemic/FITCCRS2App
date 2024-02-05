using AutoMapper;
using FITCCRS2App.Models.SearchObjects;
using FITCCRS2App.Services.Database;
using FITCCRS2App.Services.Services.AgendaService;
using FITCCRS2App.Services.Services.BaseServices;
using FITCCRS2App.Services.Services.TakmicenjeService;
using FITCCRS2App.Services.Services.UserService;
using HRMS.IdentityServer.Extensions;
//using HRMS.RabbitMQ.Extensions;
using IdentityServer4.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(typeof(IAgendaService));

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<FITCCRS2v2Context>(options =>
    options.UseSqlServer(connectionString)
    .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));

builder.UseSerilog();

builder.Services.AddIdentityServer()
    .AddDeveloperSigningCredential()
    .AddInMemoryApiScopes(new List<ApiScope> { new ApiScope() })
    .AddInMemoryClients(new List<Client> { new Client() });
builder.Services.AddTransient<IService<FITCCRS2App.Models.Models.Takmicenje, BaseSearchObject>, BaseService<FITCCRS2App.Models.Models.Takmicenje
    , Takmicenje, BaseSearchObject>>();
builder.Services.AddTransient<ITakmicenjeService, TakmicenjeService>();
builder.Services.AddTransient<IAgendaService, AgendaService>();
builder.Services.AddTransient<IUserService, UserService>();

//builder.Services.AddScopedRepositories();
//builder.Services.AddScopedServices();
//builder.Services.AddScopedNotificationServices();
//builder.Services.AddScopedStates();

builder.Services.AddControllers();

var app = builder.Build();

app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.UseIdentityServer();
app.MapControllers();

app.Run();