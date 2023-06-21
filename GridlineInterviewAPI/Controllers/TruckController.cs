using Microsoft.AspNetCore.Mvc;
using GridlineInterviewAPI.Core.Models;
using GridlineInterviewAPI.DAL;
using Microsoft.EntityFrameworkCore;

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

        [HttpPost(Name = "AddTruck")]
        public void Post(Truck truck)
        {
            using var context = new GridlineContext();
            context.Trucks.Add(truck);
            context.SaveChanges();
        }

        [HttpDelete(Name = "RemoveTruck")]
        public void Delete(int id)
        {
            using var context = new GridlineContext();
            var truck = context.Trucks.Find(id);
            if (truck != null)
            {
                context.Trucks.Remove(truck);
                context.SaveChanges();
            }
        }

        [HttpPut(Name = "UpdateTruck")]
        public void Put(Truck truck)
        {
            using var context = new GridlineContext();
            context.Trucks.Update(truck);
            context.SaveChanges();
        }

        [HttpPatch(Name = "GiveDriver")]
        public void Patch(int truckId, Driver driver)
        {
            using var context = new GridlineContext();
            var truck = context.Trucks.Find(truckId);
            if (truck != null)
            {
                truck.Drivers.Add(driver);
                context.SaveChanges();
            }
        }
    }
}