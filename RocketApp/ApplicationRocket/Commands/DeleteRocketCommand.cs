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
    public class DeleteRocketCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }

    public class DeleteRocketCommandHandler : IRequestHandler<DeleteRocketCommand, bool> 
    {
        private readonly IRocketRepository _repository;

        public DeleteRocketCommandHandler(IRocketRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(DeleteRocketCommand request, CancellationToken cancellationToken)
        {
            return await _repository.Delete(request.Id);
        }
    }

}
