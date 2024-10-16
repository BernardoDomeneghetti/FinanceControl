namespace FinanceControl.Common.Consts;

public class ErrorMessages
{
    public const string EmptyOrNullTransactionIdentifier = "A transação precisa de um nome ou identificador para ser salva";
    public const string InvalidTransactionDateTime = "A data da transação não pode ser menor que 01/01/2000";
    public const string NullTimeProvider = "O provedor de tempo não pode ser nulo";
    public const string RawException = "Exceção não tratada capturada em {0} - DateTime: {1}";
    public const string SingletonViolated = "A referência já está preenchida";
    public const string TransactionValidationValueGreaterThanZero = "O valor da transação deve ser superior a zero";
    public const string ValidationFailure = "Foram encontrados problemas no payload durante a validação";    
}
