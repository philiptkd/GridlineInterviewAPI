using Microsoft.AspNetCore.Mvc;
using GridlineInterviewAPI.Core.Models;

namespace GridlineInterviewAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DriverController : ControllerBase
    {

        private readonly ILogger<DriverController> _logger;

        public DriverController(ILogger<DriverController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetDriver")]
        public IEnumerable<Driver> Get()
        {
            return new List<Driver>();
        }
    }
}