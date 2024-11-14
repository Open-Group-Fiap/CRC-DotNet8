using System.Data;
using System.Net;
using CRC.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;

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
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Morador>()
            .HasOne(m => m.Auth)
            .WithOne(a => a.Morador)
            .OnDelete(DeleteBehavior.Cascade); 

        modelBuilder.Entity<Morador>()
            .HasMany(m => m.MoradorBonus)
            .WithOne(mb => mb.Morador)
            .OnDelete(DeleteBehavior.Cascade); 

        modelBuilder.Entity<Morador>()
            .HasMany(m => m.Faturas)
            .WithOne(f => f.Morador)
            .OnDelete(DeleteBehavior.Cascade); 

        modelBuilder.Entity<Bonus>()
            .HasMany(b => b.MoradorBonus)
            .WithOne(mb => mb.Bonus)
            .OnDelete(DeleteBehavior.NoAction); 

        modelBuilder.Entity<Condominio>()
            .HasMany(c => c.Moradores)
            .WithOne(m => m.Condominio)
            .OnDelete(DeleteBehavior.Cascade); 

        modelBuilder.Entity<Condominio>()
            .HasMany(b => b.Bonus)
            .WithOne(b => b.Condominio)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Morador>()
            .Property(m => m.Pontos)
            .HasDefaultValue(0); 
    }
    
    // Procedure para criar Auth
    public async Task<int> CreateAuthAsync(string email, string hashSenha)
    {
        var paramEmail = new OracleParameter("p_email", OracleDbType.Varchar2) { Value = email };
        var paramHashSenha = new OracleParameter("p_hash_senha", OracleDbType.Varchar2) { Value = hashSenha };
        var paramIdOut = new OracleParameter("p_id_out", OracleDbType.Decimal) { Direction = ParameterDirection.Output };

        await Database.ExecuteSqlRawAsync(
            "BEGIN pkg_insert_condominio.create_auth(:p_email, :p_hash_senha, :p_id_out); END;",
            paramEmail, paramHashSenha, paramIdOut);

        // Conversão do tipo OracleDecimal para int
        return Convert.ToInt32(((Oracle.ManagedDataAccess.Types.OracleDecimal)paramIdOut.Value).Value);
    }

    // Procedure para criar Condomínio
    public async Task<int> CreateCondominioAsync(string nome, string endereco)
    {
        var paramNome = new OracleParameter("p_nome", OracleDbType.Varchar2) { Value = nome };
        var paramEndereco = new OracleParameter("p_endereco", OracleDbType.Varchar2) { Value = endereco };
        var paramIdOut = new OracleParameter("p_id_out", OracleDbType.Decimal) { Direction = ParameterDirection.Output };

        await Database.ExecuteSqlRawAsync(
            "BEGIN pkg_insert_condominio.create_condominio(:p_nome, :p_endereco, :p_id_out); END;",
            paramNome, paramEndereco, paramIdOut);

        // Conversão do tipo OracleDecimal para int
        return Convert.ToInt32(((Oracle.ManagedDataAccess.Types.OracleDecimal)paramIdOut.Value).Value);
    }

    // Procedure para criar Morador
    public async Task<int> CreateMoradorAsync(int idCondominio, int idAuth, string cpf, string nome, int qtdMoradores, string identificadorRes)
    {
        var paramIdCondominio = new OracleParameter("p_id_condominio", OracleDbType.Int32) { Value = idCondominio };
        var paramIdAuth = new OracleParameter("p_id_auth", OracleDbType.Int32) { Value = idAuth };
        var paramCpf = new OracleParameter("p_cpf", OracleDbType.Varchar2) { Value = cpf };
        var paramNome = new OracleParameter("p_nome", OracleDbType.Varchar2) { Value = nome };
        var paramQtdMoradores = new OracleParameter("p_qtd_moradores", OracleDbType.Int32) { Value = qtdMoradores };
        var paramIdentificadorRes = new OracleParameter("p_identificador_res", OracleDbType.Varchar2) { Value = identificadorRes };
        var paramIdOut = new OracleParameter("p_id_out", OracleDbType.Decimal) { Direction = ParameterDirection.Output };

        await Database.ExecuteSqlRawAsync(
            "BEGIN pkg_insert_condominio.create_morador(:p_id_condominio, :p_id_auth, :p_cpf, :p_nome, :p_qtd_moradores, :p_identificador_res, :p_id_out); END;",
            paramIdCondominio, paramIdAuth, paramCpf, paramNome, paramQtdMoradores, paramIdentificadorRes, paramIdOut);

        // Conversão do tipo OracleDecimal para int
        return Convert.ToInt32(((Oracle.ManagedDataAccess.Types.OracleDecimal)paramIdOut.Value).Value);
    }

    // Procedure para criar Fatura
    public async Task<int> CreateFaturaAsync(int idMorador, int qtdConsumida, DateTime dtGeracao)
    {
        var paramIdMorador = new OracleParameter("p_id_morador", OracleDbType.Int32) { Value = idMorador };
        var paramQtdConsumida = new OracleParameter("p_qtd_consumida", OracleDbType.Int32) { Value = qtdConsumida };
        var paramDtGeracao = new OracleParameter("p_dt_geracao", OracleDbType.Date) { Value = dtGeracao };
        var paramIdOut = new OracleParameter("p_id_out", OracleDbType.Decimal) { Direction = ParameterDirection.Output };

        await Database.ExecuteSqlRawAsync(
            "BEGIN pkg_insert_condominio.create_fatura(:p_id_morador, :p_qtd_consumida, :p_dt_geracao, :p_id_out); END;",
            paramIdMorador, paramQtdConsumida, paramDtGeracao, paramIdOut);

        // Conversão do tipo OracleDecimal para int
        return Convert.ToInt32(((Oracle.ManagedDataAccess.Types.OracleDecimal)paramIdOut.Value).Value);
    }

    // Procedure para criar Bônus
    public async Task<int> CreateBonusAsync(int idCondominio, string nome, string descricao, decimal custo, int qtdMax)
    {
        var paramIdCondominio = new OracleParameter("p_id_condominio", OracleDbType.Int32) { Value = idCondominio };
        var paramNome = new OracleParameter("p_nome", OracleDbType.Varchar2) { Value = nome };
        var paramDescricao = new OracleParameter("p_descricao", OracleDbType.Varchar2) { Value = descricao };
        var paramCusto = new OracleParameter("p_custo", OracleDbType.Decimal) { Value = custo };
        var paramQtdMax = new OracleParameter("p_qtd_max", OracleDbType.Int32) { Value = qtdMax };
        var paramIdOut = new OracleParameter("p_id_out", OracleDbType.Decimal) { Direction = ParameterDirection.Output };

        await Database.ExecuteSqlRawAsync(
            "BEGIN pkg_insert_condominio.create_bonus(:p_id_condominio, :p_nome, :p_descricao, :p_custo, :p_qtd_max, :p_id_out); END;",
            paramIdCondominio, paramNome, paramDescricao, paramCusto, paramQtdMax, paramIdOut);

        // Conversão do tipo OracleDecimal para int
        return Convert.ToInt32(((Oracle.ManagedDataAccess.Types.OracleDecimal)paramIdOut.Value).Value);
    }

    // Procedure para criar Morador_Bonus
    public async Task<int> CreateMoradorBonusAsync(int idMorador, int idBonus, int qtd)
    {
        var paramIdMorador = new OracleParameter("p_id_morador", OracleDbType.Int32) { Value = idMorador };
        var paramIdBonus = new OracleParameter("p_id_bonus", OracleDbType.Int32) { Value = idBonus };
        var paramQtd = new OracleParameter("p_qtd", OracleDbType.Int32) { Value = qtd };
        var paramIdOut = new OracleParameter("p_id_out", OracleDbType.Decimal) { Direction = ParameterDirection.Output };

        await Database.ExecuteSqlRawAsync(
            "BEGIN pkg_insert_condominio.create_morador_bonus(:p_id_morador, :p_id_bonus, :p_qtd, :p_id_out); END;",
            paramIdMorador, paramIdBonus, paramQtd, paramIdOut);

        // Conversão do tipo OracleDecimal para int
        return Convert.ToInt32(((Oracle.ManagedDataAccess.Types.OracleDecimal)paramIdOut.Value).Value);
    }
}