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

    }
}
