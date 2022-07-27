using DesafioImpar.Application.Shared;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DesafioImpar.Presentation.Controllers
{
    public abstract class ImparBaseController : ControllerBase
    {
        protected readonly IMediator _mediator;

        public ImparBaseController(IMediator mediator)
            => _mediator = mediator;

        protected async Task<ActionResult> SendCommand(IRequest<OperationResult> request)
        {
            var result = await _mediator.Send(request);

            if (result.Content is not null)
                return StatusCode((int)result.StatusCode, result.Content);

            return StatusCode((int)result.StatusCode);
        }

        protected async Task<IQueryable<T>> SendODataCommand<T>(IRequest<IQueryable> request)
        {
            var result = await _mediator.Send(request);
            return result as IQueryable<T>;
        }

        protected async Task<ActionResult> SendFileCommand(IRequest<OperationResult> request)
        {
            var result = await _mediator.Send(request);
            if (result.Content is null)
                return StatusCode((int)result.StatusCode);
    
            var file = result.Content as FileRequestResult;
            return File(file.Content, file.MimeType, false);
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
