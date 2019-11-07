using BTL.Infrastructure;

namespace BTL.Application.Web.Infrastructure
{
    public interface IWebSetting : ISetting
    {
        string DefaultLocale { get; set; }

        int RecordPerPage { get; set; }
    }
}