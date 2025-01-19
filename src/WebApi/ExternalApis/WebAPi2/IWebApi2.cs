using Refit;

namespace WebApi.ExternalApis.WebAPi2
{
    public interface IWebApi2
    {
        [Get("/test")]
        Task<string> GetTestAsync();
    }
}
