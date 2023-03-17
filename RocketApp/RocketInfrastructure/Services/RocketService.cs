using Microsoft.EntityFrameworkCore;
using RocketDomain.Entities;
using RocketDomain.Repositories;
using RocketDomain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RocketInfrastructure.Services
{
    public class RocketService : IRocketService
    {
        private readonly IRocketRepository _rocketRepository;

        public RocketService(IRocketRepository rocketRepository)
        {
            _rocketRepository = rocketRepository;
        }

        public async Task<Rocket> Create(Rocket model) => await _rocketRepository.Create(model);

        public async Task<bool> Delete(Guid id) => await _rocketRepository.Delete(id);

        public async Task<IEnumerable<Rocket>> GetAll() => await _rocketRepository.GetAll().ToListAsync();

        public async Task<Rocket> GetById(Guid id) => await _rocketRepository.GetAll().FirstOrDefaultAsync(c => c.Id == id);
        public async Task<Rocket> Update(Rocket model) => await _rocketRepository.Update(model);
    }
}
