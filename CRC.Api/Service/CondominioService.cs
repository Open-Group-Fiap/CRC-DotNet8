﻿using CRC.Api.Models.Request;
using CRC.Api.Models.Response;
using CRC.Api.Repository;
using CRC.Domain.Entities;

namespace CRC.Api.Service;

public class CondominioService : IService<Condominio, CondominioRequest, CondominioResponse, CondominioListResponse>
{
    private CondominioRepository _repo;

    public CondominioService(CondominioRepository repo)
    {
        _repo = repo;
    }


    public async Task<CondominioListResponse> GetAllAsync(int pageNumber, int pageSize)
    {
        var condominios = await _repo.GetAllAsync(pageNumber, pageSize);

        if (!condominios.Any())
        {
            return null;
        }

        return MapToListResponse(condominios, pageNumber, pageSize);
    }

    public async Task<CondominioResponse> GetByIdAsync(int id)
    {
        var condominio = await _repo.GetByIdAsync(id);

        if (condominio == null)
        {
            return null;
        }

        return MapToResponse(condominio);
    }

    public async Task<CondominioResponse> AddAsync(CondominioRequest request)
    {
        var condominio = MapToEntity(request);

        var addedCondominio = await _repo.AddAsync(condominio);
        return MapToResponse(addedCondominio);
    }

    public async Task<CondominioResponse> UpdateAsync(int id, CondominioRequest request)
    {
        var condominio = MapToEntity(request);
        
        condominio.Id = id;

        var updatedCondominio = await _repo.UpdateAsync(condominio);
        return MapToResponse(updatedCondominio);
    }

    public async Task<CondominioResponse> DeleteAsync(int id)
    {
        var deletedCondominio = await _repo.DeleteAsync(id);
        return MapToResponse(deletedCondominio);
    }

    public CondominioResponse MapToResponse(Condominio entity)
    {
        return new CondominioResponse(entity.Id, entity.Nome, entity.Endereco);
    }
    
    public CondominioListResponse MapToListResponse(IEnumerable<Condominio> condominios, int pageNumber, int pageSize)
    {
        return new CondominioListResponse(pageNumber, pageSize, condominios.Count(), condominios.Select(MapToResponse));
    }

    public Condominio MapToEntity(CondominioRequest entity)
    {
        return new Condominio()
        {
            Nome = entity.Nome,
            Endereco = entity.Endereco
        };
    
    }
}

