using System.Net;
using CRC.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CRC.Data;

public class CrcDbContext : DbContext
{
    public DbSet<Bonus> Bonus { get; set; }
    public DbSet<Auth> Auths { get; set; }
    public DbSet<Condominio> Condominios { get; set; }
    public DbSet<Morador> Moradores { get; set; }
    public DbSet<MoradorBonus> MoradorBonus { get; set; }
    public DbSet<Fatura> Faturas { get; set; }
    
    public CrcDbContext(DbContextOptions<CrcDbContext> options) : base(options)
    {
    }
    
}