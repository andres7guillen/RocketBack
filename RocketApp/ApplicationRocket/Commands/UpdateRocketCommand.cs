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
    public class UpdateRocketCommand : IRequest<Rocket>
    {
        public Rocket Rocket { get; set; }

        public class UpdateRocketCommandHandler : IRequestHandler<UpdateRocketCommand, Rocket>
        {
            private readonly IRocketRepository _repository;

            public UpdateRocketCommandHandler(IRocketRepository repository)
            {
                _repository = repository;
            }

            public async Task<Rocket> Handle(UpdateRocketCommand request, CancellationToken cancellationToken)
            {
                return await _repository.Update(request.Rocket);
            }
        }

    }
}
