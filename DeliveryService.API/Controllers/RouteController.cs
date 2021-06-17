using DeliveryService.Application.Commands;
using DeliveryService.Application.Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryRoute.API.Controllers
{
    [Route("api/[controller]")]
    public class RouteController : Controller
    {
        private readonly IMediator mediator;
        private readonly IRouteRepository routeRepository;

        public RouteController(
            IMediator mediator,
            IRouteRepository routeRepository
        )
        {
            this.mediator = mediator;
            this.routeRepository = routeRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {

                return Ok(routeRepository.Query());
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var result = await routeRepository.GetAsync(id);

                return Ok(result);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateRoute([FromBody] CreateRoute command)
        {
            var response = await mediator.Send(command).ConfigureAwait(false);

            if (response.Errors.Any())
            {
                return BadRequest(response.Errors);
            }

            return Ok(response.Result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateRoute([FromBody] UpdateRoute command)
        {
            var response = await mediator.Send(command).ConfigureAwait(false);

            if (response.Errors.Any())
            {
                return BadRequest(response.Errors);
            }

            return Ok(response.Result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoute(int id)
        {
            var response = await mediator.Send(new DeleteRoute(id)).ConfigureAwait(false);

            if (response.Errors.Any())
            {
                BadRequest(response.Errors);
            }

            return Ok(response.Result);
        }

    }
}
