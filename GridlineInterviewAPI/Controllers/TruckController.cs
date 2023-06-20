using Microsoft.AspNetCore.Mvc;
using GridlineInterviewAPI.Core.Models;

namespace GridlineInterviewAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TruckController : ControllerBase
    {

        private readonly ILogger<TruckController> _logger;

        public TruckController(ILogger<TruckController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetTruck")]
        public IEnumerable<Truck> Get()
        {
            return new List<Truck>();
        }
    }
}