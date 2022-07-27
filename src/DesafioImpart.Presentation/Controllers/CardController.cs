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
        public async Task<ActionResult> PostCardWithImage(PostCardRequest request)
            => await SendCommand(request);

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCard(int id, UpdateCardWithPhotoRequest request)
        {
            request.Id = id;
            return await SendCommand(request);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
            => await SendCommand(new DeleteCardRequest(id));

    }
}
