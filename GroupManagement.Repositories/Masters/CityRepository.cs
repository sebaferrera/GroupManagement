using GroupManagement.Contracts;
using GroupManagement.Data;
using GroupManagement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupManagement.Repositories
{
    public class CityRepository : ICityRepository
    {
        private readonly ApplicationDbContext _db;
        public CityRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<IList<City>> GetAll()
        {
            var cities = await _db.Cities.Include(x => x.Country).AsNoTracking().ToListAsync();
            return cities;
        }
        public async Task<City> GetById(int id)
        {
            var city = await _db.Cities.Where(x => x.ID == id).Include(x => x.Country).AsNoTracking().FirstOrDefaultAsync();
            return city;
        }
        public async Task<bool> Create(City city)
        {
            await _db.Cities.AddAsync(city);
            return await Save();
        }
        public async Task<bool> Update(City city)
        {
            _db.Cities.Update(city);
            return await Save();
        }
        public async Task<bool> Delete(City city)
        {
            _db.Cities.Remove(city);
            return await Save();
        }
        public async Task<bool> Save()
        {
            var changes = await _db.SaveChangesAsync();
            return changes > 0;
        }
    }
}
