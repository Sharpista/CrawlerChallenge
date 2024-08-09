using API.Domain.Interfaces.Common;
using API.Domain.Model.API;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/v1/servidores")]
    [ApiController]
    public class ServidorController : ControllerBase
    {
        private readonly IServidorProxyService _servidorProxyService;
        private readonly ILogger<ServidorController> _logger;

        public ServidorController(IServidorProxyService servidorProxyService, ILogger<ServidorController> logger)
        {
            _servidorProxyService = servidorProxyService;
            _logger = logger;
        }

        [HttpPost("data")]
        public async Task<IActionResult> Post([FromBody] List<ServidorProxyResponse> servidorProxyResponse) => Ok(await _servidorProxyService.Post(servidorProxyResponse));
    }
}
