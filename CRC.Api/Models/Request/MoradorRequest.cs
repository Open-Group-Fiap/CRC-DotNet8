namespace CRC.Api.Models.Request;

public record MoradorRequest(
    int IdCondominio,
    string? Email,
    string? HashSenha,
    string Cpf,
    string Nome,
    int QtdMoradores,
    string IdentificadorRes
    );