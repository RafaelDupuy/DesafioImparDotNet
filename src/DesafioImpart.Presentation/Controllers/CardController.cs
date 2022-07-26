using DesafioImpar.Application.Requests.Card;
using DesafioImpar.Application.ViewModels.Card;
using DesafioImpart.Presentation.Configurations;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DesafioImpart.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardController : ImparBaseController
    {
        public CardController(IMediator mediator)
            : base(mediator) { }

        [HttpGet]
        [ODataQuery]
        public async Task<IQueryable<CardWithPhotoViewModel>> GetFromQuery()
            => await _mediator.Send(new GetAllCardsODataRequest());

        [HttpPost]
        public async Task<ActionResult> PostCardWithImage([FromForm] PostCardRequest request, IFormFile file)
        {
            if (file is null || file.Length == 0)
                return BadRequest();

            var fileAsString = IFormFileToString(file);
            return await SendCommand(new PostCardWithImageRequest(request.Name, request.Status, fileAsString));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCard([FromForm] PostCardRequest request, IFormFile file, int id)
        {
            if (file is null || file.Length == 0)
                return BadRequest();

            var fileAsString = IFormFileToString(file);
            return await SendCommand(new UpdateCardWithPhotoRequest(id, request.Name, request.Status, fileAsString));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
            => await SendCommand(new DeleteCardRequest(id));

    }
}
