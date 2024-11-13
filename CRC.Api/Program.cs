using System.Runtime.Intrinsics.X86;
using CRC.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region Database

builder.Services.AddDbContext<CrcDbContext>(options =>
{
    options.UseOracle(builder.Configuration.GetConnectionString("FiapOracleConnection"));
});

#endregion


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/user/{id:int}", async (CrcDbContext db, int id) =>
{
    var user = await db.Moradores.Include(m=>m.Condominio).Include(m=>m.Auth).FirstOrDefaultAsync(m => m.Id == id);
    if (user == null)
    {
        return Results.NotFound();
    }

    return Results.Ok(user);
});

app.MapGet("/bonus/user/{id:int}", async (CrcDbContext db, int id) =>
{
    
    // return a list of bonus for a user
    var bonus = await db.MoradorBonus.Where(m => m.IdMorador == id).ToListAsync();
    
    if (bonus == null)
    {
        return Results.NotFound();
    }
    
    return Results.Ok(bonus);
});

app.Run();