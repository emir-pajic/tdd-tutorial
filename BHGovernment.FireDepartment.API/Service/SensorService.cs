using BHGovernment.FireDepartment.API.Contracts;
using BHGovernment.FireDepartment.API.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BHGovernment.FireDepartment.API.Service
{
    public class SensorService : ISensorService
    {
        public async Task<List<Sensor>> GetSensors()
        {
            // Returned from DB
            return new List<Sensor>()
            {
                new Sensor()
                {
                    SensorId = "BHGOV_MO_0123",
                    SensorFriendlyName = "Mostar Ortiješ Sensor",
                    SensorLocation = "Mostar",
                    Active = true
                },
                new Sensor()
                {
                    SensorId = "BHGOV_KO_GHGHF23",
                    SensorFriendlyName = "Konjic Center Sensor",
                    SensorLocation = "Konjic",
                    Active = false
                },
            };

        }
    }
}
