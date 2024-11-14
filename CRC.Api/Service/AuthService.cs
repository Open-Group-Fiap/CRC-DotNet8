using CRC.Api.Models.Request;
using CRC.Api.Repository;
using CRC.Domain.Entities;
using CRC.Api.Utils;

namespace CRC.Api.Service;

public class AuthService 
{
    private AuthRepository _repo;
    
    public AuthService(AuthRepository repo)
    {
        _repo = repo;
    }
    
    
    public async Task<bool> Login(AuthRequest request)
    {
        var entity = MapToEntity(request);
        
        var auth = await _repo.GetAuth(entity);
        if (auth == null)
        {
            return false;
        }

        return true;
    }
    
    public Auth MapToEntity(AuthRequest entity)
    {
        return new Auth()
        {
            Email = entity.Email,
            HashSenha = UtilsService.QuickHash(entity.HashSenha)
        };
    }
    
    
    
}