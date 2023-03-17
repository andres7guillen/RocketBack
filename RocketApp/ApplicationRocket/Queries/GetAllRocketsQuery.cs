using MediatR;
using RocketDomain.Entities;
using RocketDomain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationRocket.Queries
{
    public class GetAllRocketsQuery : IRequest<IEnumerable<Rocket>>
    {
        public class GetAllRocketsQueryHandler : IRequestHandler<GetAllRocketsQuery, IEnumerable<Rocket>>
        {
            private IRocketRepository _repository;

            public GetAllRocketsQueryHandler(IRocketRepository repository)
            {
                _repository = repository;
            }

            public async Task<IEnumerable<Rocket>> Handle(GetAllRocketsQuery request, CancellationToken cancellationToken)
            {
                return _repository.GetAll().ToList();
            }
        }

    }
}
