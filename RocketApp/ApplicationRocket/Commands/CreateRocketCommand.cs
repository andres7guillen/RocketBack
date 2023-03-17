using MediatR;
using RocketDomain.Entities;
using RocketDomain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationRocket.Commands
{
    public class CreateRocketCommand : IRequest<Rocket>
    {
        public Rocket? Rocket { get; set; }

        public class CreateRocketCommandHandler : IRequestHandler<CreateRocketCommand, Rocket>
        {
            private readonly IRocketRepository _repository;

            public CreateRocketCommandHandler(IRocketRepository repository)
            {
                _repository = repository;
            }

            public Task<Rocket> Handle(CreateRocketCommand request, CancellationToken cancellationToken)
            {
                return _repository.Create(request.Rocket);
            }
        }

    }
}
