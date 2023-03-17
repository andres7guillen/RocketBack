using Microsoft.EntityFrameworkCore;
using RocketData.Context;
using RocketDomain.Entities;
using RocketDomain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace RocketInfrastructure.Repositories
{
    public class RocketRepository : IRocketRepository
    {
        private readonly RocketContext _context;

        public RocketRepository(RocketContext context)
        {
            _context = context;
        }

        public async Task<Rocket> Create(Rocket model)
        {
            await _context.rockets.AddAsync(model);
            await _context.SaveChangesAsync();
            return model;
        }

        public async Task<bool> Delete(Guid id)
        {
            var rocket = await _context.rockets.FirstOrDefaultAsync(c => c.Id == id);
            if (rocket == null)
            {
                return false;
            }
            else 
            { 
                _context.rockets.Remove(rocket);
                return await _context.SaveChangesAsync() > 0;
            }
        }

        public IQueryable<Rocket> GetAll()
        {
            return _context.rockets.AsQueryable();   
        }

        public IQueryable<Rocket> GetById()
        {
            return _context.rockets.AsQueryable();
        }

        public async Task<Rocket> Update(Rocket model)
        {
            _context.rockets.Update(model);
            await _context.SaveChangesAsync();
            return model;
        }
    }
}
