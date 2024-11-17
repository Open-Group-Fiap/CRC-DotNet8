using CRC.Api.Repository;
using CRC.Api.Resource;
using CRC.Api.Service;
using CRC.Data;
using CRC.Domain.Entities;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region Database

builder.Services.AddDbContext<CrcDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("AzureConnection"));
});

#endregion

#region Repositories_Services

builder.Services.AddScoped<AuthRepository>();
builder.Services.AddScoped<CondominioRepository>();
builder.Services.AddScoped<MoradorRepository>();
builder.Services.AddScoped<FaturaRepository>();
builder.Services.AddScoped<BonusRepository>();
builder.Services.AddScoped<MoradorBonusRepository>();

builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<CondominioService>();
builder.Services.AddScoped<MoradorService>();
builder.Services.AddScoped<FaturaService>();
builder.Services.AddScoped<BonusService>();
builder.Services.AddScoped<MoradorBonusService>();

#endregion


var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI();

#region Rotas_alternativas_de_servico

app.MapGet("/consumo/{idMorador:int}", async (CrcDbContext db, int idMorador) =>
{
    var faturaAtual = await db.Faturas
        .Where(f => f.Morador.Id == idMorador)
        .OrderByDescending(f => f.DtGeracao)
        .FirstOrDefaultAsync();
    
    var faturaAnterior = await db.Faturas
        .Where(f => f.Morador.Id == idMorador)
        .Skip(1)
        .OrderByDescending(f => f.DtGeracao)
        .FirstOrDefaultAsync();
    
    if(faturaAtual == null || faturaAnterior == null)
    {
        return Results.NotFound("Morador não possui faturas suficientes para calcular o consumo");
    }
    
    var porcentagemConsumo = (faturaAtual.QtdConsumida - faturaAnterior.QtdConsumida) / faturaAnterior.QtdConsumida;
    
    return Results.Ok(porcentagemConsumo);
})
.WithDescription("Calcula a porcentagem de consumo em relação à ultima fatura de luz do morador")
.Produces<int>()
.ProducesProblem(StatusCodes.Status404NotFound)
.WithTags("Utils")
.WithName("GetConsumo")
.WithOpenApi(generatedOperation =>
{
    var parameter = generatedOperation.Parameters[0];
    parameter.Description = "Id do morador a qual o consumo será calculado";
    parameter.Required = true;
    return generatedOperation;
});


app.MapGet("/randomFatura/{idMorador:int}", async (CrcDbContext db, int idMorador) =>
{
    var morador = await db.Moradores.FindAsync(idMorador);
    
    if(morador == null)
    {
        return Results.BadRequest("Morador não encontrado");
    }
    
    var fatura = new Fatura
    {
        Morador = morador,
        DtGeracao = DateTime.Now - TimeSpan.FromDays(new Random().Next(1, 366)),
        QtdConsumida = new Random().Next(1, 100),
    };
    
    await db.Faturas.AddAsync(fatura);
    await db.SaveChangesAsync();
    
    return Results.Ok(fatura);
})
.WithDescription("Cria uma fatura aleatória para um morador")
.Produces<Fatura>()
.ProducesProblem(StatusCodes.Status400BadRequest)
.WithTags("Utils")
.WithName("CreateRandomFatura")
.WithOpenApi(generatedOperation =>
{
    var parameter = generatedOperation.Parameters[0];
    parameter.Description = "Id do morador a qual a fatura será gerada";
    parameter.Required = true;
    return generatedOperation;
});

#endregion


app.MapCondominioEndpoints();
app.MapAuthEndpoints();
app.MapMoradorEndpoints();
app.MapFaturaEndpoints();
app.MapBonusEndpoints();
app.MapMoradorBonusEndpoints();
app.MapPrevisaoEndpoints();

app.Run();