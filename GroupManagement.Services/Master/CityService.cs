using AutoMapper;
using GroupManagement.Contracts;
using GroupManagement.DTOs;
using GroupManagement.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GroupManagement.Services
{
    public class CityService : ICityService
    {
        private readonly ICityRepository _repo;
        private readonly IMapper _mapper;
        public CityService(ICityRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<IList<CityDTO>> GetAll()
        {
            var cities = await _repo.GetAll();
            var retValue = _mapper.Map<IList<CityDTO>>(cities);
            return retValue;

        }

        public async Task<CityDTO> GetById(int id)
        {
            var city = await _repo.GetById(id);
            var retValue = _mapper.Map<CityDTO>(city);
            return retValue;
        }

        public async Task<CityDTO> Create(CityCreateDTO cityToCreate)
        {
            var city = _mapper.Map<City>(cityToCreate);
            var isSuccess = await _repo.Create(city);

            return isSuccess ? await GetById(city.ID) : null;
        }
    }
}
