namespace CRC.Api.Models.Response;

public record CondominioListResponse(
    int pageNumber,
    int pageSize,
    int total,
    IEnumerable<CondominioResponse> condominios
    );