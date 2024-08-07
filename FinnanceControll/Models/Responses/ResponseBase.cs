namespace FinnanceControll.Models.Responses
{
    public abstract class ResponseBase<TPayload>
    {
        public string? Message { get; set; }
        public TPayload? Payload { get; set; }
    }
}