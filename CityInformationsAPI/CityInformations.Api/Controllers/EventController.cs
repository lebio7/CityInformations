using CityInformations.Api.Extensions;
using CityInformations.Application.Features.Events.Commands;
using CityInformations.Application.Features.Events.Queries;
using CityInformations.Shared.DTO;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CityInformations.Api.Controllers
{
    public class EventController : MyController
    {
        public EventController(IMediator mediator) : base(mediator) { }

        /// <summary>
        /// Get Event by Id
        /// </summary>
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var result = await GetMediatorInstance.Send(new GetQuery(id));

                return Ok(result);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllItems()
        {
            var results =  await GetMediatorInstance.Send(new GetAllItemsQuery());

            return results?.Count > 0
                ? Ok(results)
                : NoContent();
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Create(EventDto dto)
        {
            try
            {
                var result = await GetMediatorInstance.Send(new CreateCommand(dto));

                return Ok();
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }
    }
}
