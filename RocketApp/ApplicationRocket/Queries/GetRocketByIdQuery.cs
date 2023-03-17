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
    public class GetRocketByIdQuery : IRequest<Rocket>
    {
        public Guid Id { get; set; }
        public GetRocketByIdQuery(Guid id)
        {
            Id = id;
        }

        public class GetRocketByIdQueryHandler : IRequestHandler<GetRocketByIdQuery, Rocket>
        {
            private readonly IRocketRepository _repository;

            public GetRocketByIdQueryHandler(IRocketRepository repository)
            {
                _repository = repository;
            }

            public async Task<Rocket> Handle(GetRocketByIdQuery request, CancellationToken cancellationToken)
            {
                return _repository.GetAll().FirstOrDefault(r => r.Id == request.Id);
            }
        }



    }
}
