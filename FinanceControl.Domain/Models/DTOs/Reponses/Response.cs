namespace FinanceControl.Domain.Models.DTOs.BaseDtos;

public class Response<TResponse>
{
    public ResponseHttpCode Code { get; set; }
    public required string Message { get; set; }
    public TResponse? Payload { get; set; }
}
