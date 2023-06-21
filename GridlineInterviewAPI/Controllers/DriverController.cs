using Microsoft.AspNetCore.Mvc;
using GridlineInterviewAPI.Core.Models;
using GridlineInterviewAPI.DAL;
using Microsoft.EntityFrameworkCore;

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
            var driver = context.Drivers.Find(id);
            if (driver != null)
            {
                context.Drivers.Remove(driver);
                context.SaveChanges();
            }
        }

        [HttpPut(Name = "UpdateDriver")]
        public void Put(Driver driver)
        {
            using var context = new GridlineContext();
            context.Drivers.Update(driver);
            context.SaveChanges();
        }

        [HttpPatch(Name = "GiveTruck")]
        public void Patch(int driverId, Truck truck)
        {
            using var context = new GridlineContext();
            var driver = context.Drivers.Find(driverId);
            if (driver != null)
            {
                driver.Trucks.Add(truck);
                context.SaveChanges();
            }
        }
    }
}