using RocketDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RocketDomain.Services
{
    public interface IRocketService
    {
        Task<Rocket> Create(Rocket model);
        Task<Rocket> GetById(Guid id);
        Task<IEnumerable<Rocket>> GetAll();
        Task<Rocket> Update(Rocket model);
        Task<bool> Delete(Guid id);
    }
}
