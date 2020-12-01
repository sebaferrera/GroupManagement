using AutoMapper;
using GroupManagement.Contracts;
using GroupManagement.DTOs;
using GroupManagement.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GroupManagement.Services
{
    public class CountryService : ICountryService
    {
        private readonly ICountryRepository _repo;
        private readonly IMapper _mapper;
        public CountryService(ICountryRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<IList<CountryDTO>> GetAll()
        {
            var countries = await _repo.GetAll();
            var retValue = _mapper.Map<IList<CountryDTO>>(countries);
            return retValue;

        }

        public async Task<CountryDTO> GetById(int id)
        {
            var country = await _repo.GetById(id);
            var retValue = _mapper.Map<CountryDTO>(country);
            return retValue;
        }

        public async Task<CountryDTO> Create(CountryCreateDTO countryToCreate)
        {
            var country = _mapper.Map<Country>(countryToCreate);
            var isSuccess = await _repo.Create(country);

            return isSuccess ? await GetById(country.ID) : null;
        }

        public async Task<CountryDTO> Update(CountryUpdateDTO countryToUpdate)
        {
            var country = _mapper.Map<Country>(countryToUpdate);
            var isSuccess = await _repo.Update(country);

            return isSuccess ? await GetById(country.ID) : null;
        }

        public async Task<bool> Exists(int id)
        {
            return await _repo.Exists(id);
        }

        public async Task<bool> Delete(int id)
        {
            var country = await _repo.GetById(id);
            return await _repo.Delete(country);
        }
    }
}
