using GroupManagement.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GroupManagement.Contracts
{
    public interface ICountryService
    {
        Task<IList<CountryDTO>> GetAll();
        Task<CountryDTO> GetById(int id);
    }
}
