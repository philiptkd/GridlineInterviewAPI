using Microsoft.AspNetCore.Mvc;
using GridlineInterviewAPI.Core.Models;
using GridlineInterviewAPI.DAL;

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

        [HttpGet(Name = "GetTrucks")]
        public IEnumerable<Truck> Get()
        {
            using var context = new GridlineContext();
            var trucks = context.Trucks.ToList();
            return trucks;
        }
    }
}