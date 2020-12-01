using GroupManagement.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GroupManagement.Contracts
{
    public interface ICountryService
    {
        Task<IList<CountryDTO>> GetAll();
        Task<CountryDTO> GetById(int id);
        Task<CountryDTO> Create(CountryCreateDTO countryToCreate);
        Task<CountryDTO> Update(CountryUpdateDTO cityToUpdate);
        Task<bool> Delete(int id);
        Task<bool> Exists(int id);
    }
}