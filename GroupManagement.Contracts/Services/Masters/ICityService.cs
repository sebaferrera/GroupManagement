using GroupManagement.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GroupManagement.Contracts
{
    public interface ICityService
    {
        Task<IList<CityDTO>> GetAll();
        Task<CityDTO> GetById(int id);
        Task<CityDTO> Create(CityCreateDTO cityToCreate);
        Task<CityDTO> Update(CityUpdateDTO cityToUpdate);
        Task<bool> Delete(int id);
        Task<bool> Exists(int id);
    }
}
