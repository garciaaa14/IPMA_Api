using Microsoft.AspNetCore.Mvc;

namespace IPMA_Api.Controllers
{
    [ApiController]
    [Route("api/ping")]
    public class PingController : ControllerBase
    {
        [HttpGet]
        public IActionResult Ping()
        {
            return Ok(new
            {
                status = "OK",
                message = "Servidor a funcionar",
                time = DateTime.UtcNow
            });
        }
    }
}
