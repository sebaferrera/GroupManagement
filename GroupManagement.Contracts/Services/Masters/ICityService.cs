using GroupManagement.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GroupManagement.Contracts
{
    public interface ICityService
    {
        Task<IList<CityDTO>> GetAll();
        Task<CityDTO> GetById(int id);
    }
}
