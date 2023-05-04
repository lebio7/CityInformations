using CityInformations.Api.Extensions;
using CityInformations.Application.Features.Dates.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CityInformations.Api.Controllers
{
    public class DateController : MyController
    {
        public DateController(IMediator mediator) : base(mediator) { }

        /// <summary>
        /// Get Date by Id
        /// </summary>
        [HttpGet("[action]/id")]
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


        /// <summary>
        /// Get date collection by typeDateIds
        /// </summary>
        [HttpPost("[action]")]
        public async Task<IActionResult> GetByTypeDatesId([FromBody] GetByTypeDatesIdQuery query)
        {
            try
            {
                var result = await GetMediatorInstance.Send(query);

                return result?.Count > 0
                    ? Ok(result)
                    : NotFound();
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }
    }
}
