namespace BTL.Application.Web.Infrastructure.Security.Authentications.Contexts
{
    public enum AuthRequestType
    {
        Google = 1,
        Yahoo = 2,
        Facebook = 3,
        Twitter = 4,
        Linkedin = 5,
        WindowsLive = 6
    }

    public enum ProcessType
    {
        Processing = 1,
        Processed = 2
    }
}