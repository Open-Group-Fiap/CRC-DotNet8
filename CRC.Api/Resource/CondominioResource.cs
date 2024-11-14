using CRC.Api.Models.Request;
using CRC.Api.Models.Response;
using CRC.Api.Service;
using CRC.Domain.Entities;

namespace CRC.Api.Resource;

public static class CondominioResource
{
    
    public static void MapCondominioEndpoints(this WebApplication app)
    {
        var condominioGroup = app.MapGroup("/condominio");
        
        condominioGroup.MapGet("/list", async (CondominioService _service, int pageNumber = 1, int pagesize = 30) =>
        {
            var result = await _service.GetAllAsync(pageNumber, pagesize);
            return result != null ? Results.Ok(result) : Results.NotFound();
        });
        
        condominioGroup.MapGet("/{id}", async (CondominioService _service, int id) =>
        {
            var result = await _service.GetByIdAsync(id);
            return result != null ? Results.Ok(result) : Results.NotFound();
        });
        
        condominioGroup.MapPost("/", async (CondominioRequest request, CondominioService _service) =>
        {
            var result = await _service.AddAsync(request);
            return Results.Created($"/condominio/{result.Id}", result);
        });
        
        condominioGroup.MapPut("/{id}", async (CondominioRequest request, CondominioService _service, int id) =>
        {
            var result = await _service.UpdateAsync(id, request);
            return result != null ? Results.Ok(result) : Results.NotFound();
        });
        
        condominioGroup.MapDelete("/delete/{id}", async (CondominioService _service, int id) =>
        {
            var result = await _service.DeleteAsync(id);
            return result != null ? Results.NoContent() : Results.NotFound();
        });
        
    } 
    
}