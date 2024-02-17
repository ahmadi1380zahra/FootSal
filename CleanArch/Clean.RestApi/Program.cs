using Clean.Contracts;
using Clean.Persistance.EF;
using Clean.Persistance.EF.Players;
using Clean.Persistance.EF.Teams;
using Clean.Services.Players;
using Clean.Services.Players.Contracts;
using Clean.Services.Teams;
using Clean.Services.Teams.Contracts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<EFDataContext>();
builder.Services.AddScoped<UnitOfWork, EFUnitOfWork>();
builder.Services.AddScoped<TeamService, TeamAppService>();
builder.Services.AddScoped<TeamRepository, EFTeamRepository>();
builder.Services.AddScoped<PlayerService, PlayerAppService>();
builder.Services.AddScoped<PlayerRepository, EFPlayerRepository>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
