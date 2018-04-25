using Biosphere.Common.DataAccess.Repository;
using Biosphere.Common.DataAccess.UnitOfWork;
using ReviewMe.DataAccess.Models;
using ReviewMe.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace ReviewMe.Web.Controllers
{
    [Route("api/home/")]
    public class HomeController : ApiController
    {
        private readonly StatisticService _service;

        public HomeController(StatisticService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IHttpActionResult> Index()
        {
            await _service.GetVisitorsCount("player1");

            return Ok("Api started");
        }

        [HttpGet]
        [Route("add")]
        public async Task<IHttpActionResult> AddHumanVisitors(string player, int count)
        {
            await _service.AddHumanVisitors(player, count);

            return Ok();
        }

        [HttpGet]
        [Route("visitors/count")]
        public async Task<IHttpActionResult> GetVisitorsCount(string player)
        {
            var count = await _service.GetVisitorsCount(player);
            return Ok(count);
        }

        [HttpDelete]
        [Route("visitors/count")]
        public async Task<IHttpActionResult> DeleteVisitorsCount(string player)
        {
            await _service.DeleteVisitorsCount(player);
            return Ok();
        }
    }
}
