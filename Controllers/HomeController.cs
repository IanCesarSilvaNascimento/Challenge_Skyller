using Microsoft.AspNetCore.Mvc;

namespace DesafioSky.Controllers
{

    [ApiController]
    
    public class HomeController : ControllerBase
    {

        [HttpGet("")]
        public IActionResult Get()
            => Ok();
    }
}