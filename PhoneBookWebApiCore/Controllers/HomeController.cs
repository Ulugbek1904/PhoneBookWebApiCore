using Microsoft.AspNetCore.Mvc;

namespace PhoneBookWebApiCore.Controllers
{
    [ApiController]
    [Route("api/home")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public string GetMessage()
        {
            return "Message";
        }
    }
}
