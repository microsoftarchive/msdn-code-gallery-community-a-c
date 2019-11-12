namespace BTL.Application.Web.Infrastructure
{
    public class ErrorMessage
    {
        public string Message { get; set; }

        public ErrorMessageType ErrorMessageType { get; set; }
    }

    public enum ErrorMessageType
    {
        Info,
        Error
    }
}