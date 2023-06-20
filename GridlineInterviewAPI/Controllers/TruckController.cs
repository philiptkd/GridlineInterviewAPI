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
            var truck = context.Trucks.FirstOrDefault(x => x.Id == id);
            if (truck != null)
            {
                context.Trucks.Remove(truck);
                context.SaveChanges();
            }
        }
    }
}