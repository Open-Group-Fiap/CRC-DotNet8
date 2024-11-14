using CRC.Data;
using Microsoft.EntityFrameworkCore;

namespace CRC.Api.Script;

public class ProcScript
{
    private readonly IConfiguration _configuration;
    private readonly CrcDbContext _context;

    public ProcScript(IConfiguration configuration, CrcDbContext context)
    {
        _configuration = configuration;
        _context = context;
    }


    public async Task ExecuteSqlScriptAsync()
    {
        string sqlScript = await File.ReadAllTextAsync("./Script/scriptProcHeader.sql");
        await _context.Database.ExecuteSqlRawAsync(sqlScript);
        
        string sqlScript2 = await File.ReadAllTextAsync("./Script/scriptProcBody.sql");
        await _context.Database.ExecuteSqlRawAsync(sqlScript2);
    }
}