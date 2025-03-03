using Microsoft.AspNetCore.Mvc;

namespace HelloApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SecondController : ControllerBase
    {


        public SecondController()
        {
        }

        [HttpGet]
        public String Get()
        {
            return "Second Contoller First Get";
        }

        [HttpGet]
        [Route("second")]
        public String Get1()
        {
            return "Second Get";
        }

    }
}
