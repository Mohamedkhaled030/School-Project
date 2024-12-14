using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shcool.Core.Bases;
using System.Net;

namespace ShcoolProject.Api.Base
{

    [ApiController]
    public class AppControllerBase : ControllerBase
    {
        private IMediator _mediator;
        protected IMediator _Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        public ObjectResult NewResult<T>(Response<T> response)
        {
            switch (response.StatusCode)
            {
                case HttpStatusCode.OK:
                    return new ObjectResult(response);
                case HttpStatusCode.Created:
                    return new CreatedResult(string.Empty, response);
                case HttpStatusCode.Unauthorized:
                    return new UnauthorizedObjectResult(response);
                case HttpStatusCode.BadRequest:
                    return new BadRequestObjectResult(response);
                case HttpStatusCode.Accepted:
                    return new AcceptedResult(string.Empty, response);
                case HttpStatusCode.UnprocessableEntity:
                    return new UnprocessableEntityObjectResult(response);
                default:
                    return new BadRequestObjectResult(response);

            }
        }
    }
}
