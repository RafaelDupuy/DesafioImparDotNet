using DesafioImpar.Application.Shared;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DesafioImpart.Presentation.Controllers
{
    public abstract class ImparBaseController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ImparBaseController(IMediator mediator)
            => _mediator = mediator;

        protected async Task<ActionResult> SendCommand(IRequest<OperationResult> request)
        {
            var result = await _mediator.Send(request);

            if (result.Content is not null)
                return StatusCode((int)result.StatusCode, result.Content);

            return StatusCode((int)result.StatusCode);
        }

        protected string IFormFileToString(IFormFile file)
        {
            using (var ms = new MemoryStream())
            {
                file.CopyTo(ms);
                var fileBytes = ms.ToArray();
                return Convert.ToBase64String(fileBytes);
            }
        }
    }
}
