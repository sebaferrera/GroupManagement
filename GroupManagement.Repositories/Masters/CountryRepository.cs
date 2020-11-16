using GroupManagement.Contracts;
using GroupManagement.Data;
using GroupManagement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GroupManagement.Repositories
{
    public class CountryRepository : ICountryRepository
    {
        private readonly ApplicationDbContext _db;
        public CountryRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<IList<Country>> GetAll()
        {
            var countries = await _db.Countries.ToListAsync();
            return countries;
        }
        public async Task<Country> GetById(int id)
        {
            var country = await _db.Countries.FindAsync(id);
            return country;
        }
        public async Task<bool> Create(Country country)
        {
            await _db.Countries.AddAsync(country);
            return await Save();
        }
        public async Task<bool> Update(Country country)
        {
            _db.Countries.Update(country);
            return await Save();
        }
        public async Task<bool> Delete(Country country)
        {
            _db.Countries.Remove(country);
            return await Save();
        }
        public async Task<bool> Save()
        {
            var changes = await _db.SaveChangesAsync();
            return changes > 0;
        }
    }
}
