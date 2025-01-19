using Microsoft.AspNetCore.Mvc;
using WebApi.ExternalApis.WebApiFail;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {

        private readonly IWebApiFail _webApiFail;
        private readonly ILogger<TestController> _logger;

        public TestController(ILogger<TestController> logger, IWebApiFail webApiFail)
        {
            _logger = logger;
            _webApiFail = webApiFail;
        }

        [HttpGet(Name = "GetTest")]
        public async Task<string> GetTest()
        {
            return await _webApiFail.GetTestAsync();
        }
    }
}
