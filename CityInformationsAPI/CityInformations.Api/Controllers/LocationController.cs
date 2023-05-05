using CityInformations.Api.Extensions;
using CityInformations.Application.Features.Locations.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CityInformations.Api.Controllers
{
    public class LocationController : MyController
    {
        public LocationController(IMediator mediator) : base(mediator) { }


        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllItems(int? limit,
            int? offset,
            string? search)
        {
            var result = await GetMediatorInstance.Send(new GetAllItemsQuery(limit, offset, search));

            return Ok(result);
        }

        /// <summary>
        /// Get Locations by Id
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
    }
}
