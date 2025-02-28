using Microsoft.EntityFrameworkCore;
using P01DAW_2022AE650_2023A651_reservas.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<usuariosContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("parqueoDbConnection")));

builder.Services.AddDbContext<espaciosContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("parqueoDbConnection")));

builder.Services.AddDbContext<reservasContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("parquoDbConnection")));

builder.Services.AddDbContext<sucursalesContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("parqueoDbConnection")));



builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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