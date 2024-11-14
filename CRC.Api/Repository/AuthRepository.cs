using CRC.Data;
using CRC.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CRC.Api.Repository;

public class AuthRepository
{
    private readonly CrcDbContext _context;
    private readonly DbSet<Auth> _db;
    
    public AuthRepository(CrcDbContext db)
    {
        this._context = db;
        this._db = db.Set<Auth>();
    }
    
   public async Task<Auth> GetAuth(Auth entity)
   {
       return _db.FirstOrDefault(x => x.Email == entity.Email && x.HashSenha == entity.HashSenha);
   }
}