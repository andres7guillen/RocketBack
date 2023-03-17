using ApplicationRocket.Commands;
using ApplicationRocket.Queries;
//using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RocketAPI.Converts;
using RocketAPI.Models;
using RocketDomain.Entities;
using RocketDomain.Services;

namespace RocketAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RocketController : ControllerBase
    {
        private readonly IRocketService _service;
        //private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public RocketController(IRocketService service,IMediator mediator)
        {
            _service = service;
            //_mapper = mapper;
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult> Post(RocketModel model)
        {
            try
            {
                var rocketResult = _mediator.Send(new CreateRocketCommand() { Rocket = model.toEntity() });
                return Ok(rocketResult.Result.toModel());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
                throw e;
            }
        }

        [HttpGet]
        public async Task<ActionResult> Get() 
        {
            try
            {
                var rockets = _mediator.Send(new GetAllRocketsQuery());
                return Ok(rockets.Result.toListModel());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
                throw e;
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(string id) 
        {
            try
            {
                var rocket = _mediator.Send(new GetRocketByIdQuery(Guid.Parse(id)));
                if (rocket == null)
                    return NotFound();
                return Ok(rocket.Result.toModel());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
                throw e;
            }            
        }

        [HttpPut]
        public async Task<ActionResult> Put(RocketModel model) 
        {
            try
            {
                var rocketResult = _mediator.Send(new UpdateRocketCommand() { Rocket = model.toEntity() });
                return Ok(rocketResult.Result.toModel());
            }
            catch (Exception)
            {

                throw;
            }           
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            try
            {
                var rocketResult = _mediator.Send(new DeleteRocketCommand() { Id = Guid.Parse(id) });
                return Ok(rocketResult.Result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
                throw e;
            }            
        }

    }
}
