using BHGovernment.FireDepartment.API.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BHGovernment.FireDepartment.API.Contracts
{
    public interface ISensorService
    {
        Task<List<Sensor>> GetSensors();
    }
}
