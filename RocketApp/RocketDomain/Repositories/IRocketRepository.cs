using RocketDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RocketDomain.Repositories
{
    public interface IRocketRepository
    {
        Task<Rocket> Create(Rocket model);
        IQueryable<Rocket> GetAll();
        Task<Rocket> Update(Rocket model);
        Task<bool> Delete(Guid id);
    }
}
