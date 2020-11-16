using AutoMapper;
using GroupManagement.Contracts;
using GroupManagement.DTOs;
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
    }
}
