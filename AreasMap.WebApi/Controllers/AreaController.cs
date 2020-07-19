using AreasMap.Application.Area.Commands.Create;
using AreasMap.Application.Area.Commands.Update;
using AreasMap.Application.Area.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AreasMap.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AreaController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AreaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateListOfAreasCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateListOfAreasCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpGet]
        [ResponseCache(Duration = 30, Location = ResponseCacheLocation.Any)]
        public async Task<IActionResult> Get()
        {
            return Ok(await _mediator.Send(new GeAreaListQuery()));
        }
    }
}