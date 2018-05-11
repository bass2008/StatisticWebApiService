using System.Web.Http;

namespace ReviewMe.Web.Controllers
{
    public class HomeController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Index()
        {
            return Ok("Api started");
        }
    }
}
