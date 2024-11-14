using CRC.Api.Models.Request;
using CRC.Api.Models.Response;
using CRC.Api.Repository;
using CRC.Domain.Entities;

namespace CRC.Api.Service;

public class FaturaService : IService<Fatura, FaturaRequest, FaturaResponse, FaturaListResponse>
{
    
    private FaturaRepository _repo;

    public FaturaService(FaturaRepository repo)
    {
        _repo = repo;
    }
    
    public async Task<FaturaListResponse> GetAllAsync(int pageNumber, int pageSize)
    {
        var faturas = await _repo.GetAllAsync(pageNumber, pageSize);
        return MapToListResponse(faturas, pageNumber, pageSize);
    }

    public async Task<FaturaResponse> GetByIdAsync(int id)
    {
        var fatura = await _repo.GetByIdAsync(id);
        if (fatura == null)
        {
            return null;
        }
        return MapToResponse(fatura);
    }

    public async Task<FaturaResponse> AddAsync(FaturaRequest request)
    {
        
        var fatura = MapToEntity(request);
        
        var addedFatura = await _repo.AddAsync(fatura);
        return MapToResponse(addedFatura);
    }

    public async Task<FaturaResponse> UpdateAsync(int id, FaturaRequest request)
    {
        var fatura = await _repo.GetByIdAsync(id);
        if (fatura == null)
        {
            return null;
        }
        fatura.DtGeracao = request.DtGeracao;
        fatura.IdMorador = request.IdMorador;
        fatura.QtdConsumida = request.QtdConsumida;
        
        var updatedFatura = await _repo.UpdateAsync(fatura);
        return MapToResponse(updatedFatura);
    }

    public async Task<FaturaResponse> DeleteAsync(int id)
    {
        var fatura = await _repo.GetByIdAsync(id);
        if (fatura == null)
        {
            return null;
        }
        await _repo.DeleteAsync(fatura);
        return MapToResponse(fatura);
    }
    
    public async Task<FaturaListResponse> GetByMoradorAsync(int idMorador, int pageNumber, int pageSize)
    {
        var faturas = await _repo.GetByMoradorAsync(idMorador, pageNumber, pageSize);
        return MapToListResponse(faturas, pageNumber, pageSize);
    }

    public FaturaResponse MapToResponse(Fatura entity)
    {
        return new FaturaResponse(
            entity.Id,
            entity.IdMorador,
            entity.QtdConsumida,
            entity.DtGeracao
        );
    }

    public FaturaListResponse MapToListResponse(IEnumerable<Fatura> entities, int pageNumber, int pageSize)
    {
        var faturaList = entities.Select(f => MapToResponse(f));
        return new FaturaListResponse( pageNumber, pageSize, faturaList.Count(), faturaList);
    }

    public  Fatura MapToEntity(FaturaRequest entity)
    {
        return new Fatura {
            IdMorador = entity.IdMorador,
            QtdConsumida = entity.QtdConsumida,
            DtGeracao = entity.DtGeracao
        };
    }
}