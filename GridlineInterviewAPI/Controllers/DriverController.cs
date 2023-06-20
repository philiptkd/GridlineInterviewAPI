using Microsoft.AspNetCore.Mvc;
using GridlineInterviewAPI.Core.Models;
using GridlineInterviewAPI.DAL;

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

        [HttpGet(Name = "GetDrivers")]
        public IEnumerable<Driver> Get()
        {
            using var context = new GridlineContext();
            var drivers = context.Drivers.ToList();
            return drivers;
        }

        [HttpPost(Name = "AddDriver")]
        public void Post(Driver driver)
        {
            using var context = new GridlineContext();
            context.Drivers.Add(driver);
            context.SaveChanges();
        }

        [HttpDelete(Name = "RemoveDriver")]
        public void Delete(int id)
        {
            using var context = new GridlineContext();
            var driver = context.Drivers.FirstOrDefault(x => x.Id == id);
            if (driver != null)
            {
                context.Drivers.Remove(driver);
                context.SaveChanges();
            }
        }
    }
}