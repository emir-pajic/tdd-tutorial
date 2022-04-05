using BHGovernment.FireDepartment.API.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace BHGovernment.FireDepartment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SensorController : ControllerBase
    {
        public ISensorService sensorService { get; set; }
        public SensorController(ISensorService ss)
        {
            sensorService = ss;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSensors()
        {
            var sensors = await sensorService.GetSensors();

            if (sensors.Any())
            {
                return Ok(sensors);
            }
            return NoContent();
        }

        [HttpGet]
        [Route("active")]

        public async Task<IActionResult> GetAllActiveSensors()
        {
            var sensors = await sensorService.GetSensors();

            if (sensors.Any())
            {
                var activeSensors = sensors.Where(s => s.Active);
                return Ok(activeSensors);
            }
            return NoContent();
        }

        [HttpGet]
        [Route("getById")]

        public async Task<IActionResult> GetAllActiveSensors(string sensorId)
        {
            var sensors = await sensorService.GetSensors();

            if (sensors.Any())
            {
                var sensor = sensors.Where(s => s.SensorId == sensorId);

                if (sensor.Any())
                {
                    return Ok(sensor);
                }
            }
            return NoContent();
        }
    }
}
