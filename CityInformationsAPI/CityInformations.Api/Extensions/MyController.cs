using CityInformations.Domain.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CityInformations.Api.Extensions
{
    public class MyController : ControllerBase
    {
        public IMediator GetMediatorInstance
        {
            get
            {
                return mediator;
            }
        }

        private readonly IMediator mediator;

        public MyController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        protected IActionResult HandleException(Exception ex)
        {
            if (ex is NotFoundException)
            {
                return NotFound(ex.Message);
            }

            return Problem(ex.Message);
        }
    }
}
