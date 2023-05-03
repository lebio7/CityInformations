using CityInformations.Api.Extensions;
using CityInformations.Application.Features.Newses.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CityInformations.Api.Controllers
{
    public class NewsController : MyController
    {
        public NewsController(IMediator mediator) : base(mediator) { }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllItems(int? limit,
            int? offset,
            string? search)
        {
            var result = await GetMediatorInstance.Send(new GetAllItemsQuery(limit, offset, search));

            return Ok(result);
        }

        /// <summary>
        /// Get News by Id
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
