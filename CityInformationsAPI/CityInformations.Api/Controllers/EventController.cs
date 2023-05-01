using Microsoft.AspNetCore.Mvc;

namespace CityInformations.Api.Controllers
{
    public class EventController : ControllerBase
    {
        [HttpGet("[action]")]
        public ActionResult<bool> test()
        {
            return true;
        }
    }
}
